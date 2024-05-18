using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using JikanDotNet;
using Newtonsoft.Json;

using WhatsNextCA; // Add reference to WhatsNextCA project

namespace WhatsNextWPF
{
    public class Recommendation
    {
        string jsonPath = @"C:\Users\Carter\Desktop\Coding Projects\WhatsNext\WhatsNextCA\animeData.json";
        //List<DataCollector.AnimeData> jRecommendations = new List<DataCollector.AnimeData>();
        List<DataCollector.AnimeData> animes = new List<DataCollector.AnimeData>();

        Weights weights;

        Dictionary<string, double> genreWeights;
        Dictionary<string, double> themeWeights;

        public Recommendation()
        {
            string jsonData = File.ReadAllText(jsonPath);
            string weightData = File.ReadAllText(@"C:\Users\Carter\Desktop\Coding Projects\WhatsNext\WhatsNextCA\weights.json");

            this.animes = JsonConvert.DeserializeObject<List<DataCollector.AnimeData>>(jsonData);

            weights = JsonConvert.DeserializeObject<Weights>(weightData);

            genreWeights = weights.GenreWeights ?? new Dictionary<string, double>();
            themeWeights = weights.ThemeWeights ?? new Dictionary<string, double>();
        }

        public DataCollector.AnimeData? GetAnimeFromTitle(string title)
        {
            foreach (var anime in animes)
            {
                if (anime.Title == title)
                {
                    return anime;
                }
            }

            return null;
        }

        /* ========== Jikan Recommendations ========== */
        public async Task<List<DataCollector.AnimeData>> JikanRecommendations(DataCollector.AnimeData anime)
        {
            IJikan jikan = new Jikan(); // Create an instance of the Jikan API

            // Get the recommendations for the specified anime using the Jikan API
            BaseJikanResponse<ICollection<JikanDotNet.Recommendation>> jikanRecommendations = await jikan.GetAnimeRecommendationsAsync(anime.Id);

            // Find the Jikan data in the JSON file
            List<DataCollector.AnimeData> jRec = await FindJikanInJson(jikanRecommendations);
            
            //ConvertJikanToAnimeData(jikanRecommendations);

            return jRec;
        }

        private async Task<List<DataCollector.AnimeData>> FindJikanInJson(BaseJikanResponse<ICollection<JikanDotNet.Recommendation>> jikanRecommendations)
        {
            //DataCollector.Program dc = new DataCollector.Program();
            List<DataCollector.AnimeData> animeData = new List<DataCollector.AnimeData>();

            foreach (var recommendation in jikanRecommendations.Data)
            {
                //animeData = dc.GetAnimeData(recommendation.Entry.MalId.ToString());
                var anime = await DataCollector.Program.GetAnimeData(recommendation.Entry.MalId.ToString());

                if (anime != null)
                {
                    animeData.Add(anime);
                }
            }

            return animeData;
        }

        /* ========== Content-Based Recommendations ========== */
        public async Task<List<DataCollector.AnimeData>> CBRecommendations(DataCollector.AnimeData anime)
        {
            const int maxYearDifference = 10;
            const int maxEpisodeDifference = 50;

            List<Tuple<DataCollector.AnimeData, double>> recommendations = new List<Tuple<DataCollector.AnimeData, double>>();

            // Search through the list of anime data
            foreach (var a in animes)
            {
                double similarityScore = 0.0;

                // Skip the anime if it is the same as the input anime
                if (anime != null && a != null)
                {
                    if (a.Title == anime.Title || AreTitlesSimilar(anime.Title, a.Title) || AreEnglishTitlesSimilar(anime.TitleEnglish, a.TitleEnglish))
                    {
                        continue;
                    }

                    // Calculate the similarity score between the input anime and the current anime
                    similarityScore = await CalculateSimilarity(anime, a, maxYearDifference, maxEpisodeDifference);
                }
                else
                {
                    continue;
                }


                // Add the anime and its similarity score to the list of recommendations
                recommendations.Add(new Tuple<DataCollector.AnimeData, double>(a, similarityScore));
            }

            // Sort the recommendations by similarity score in descending order, taking the top 10,return recommendations.OrderByDescending(r => r.Item2)
            return recommendations.OrderByDescending(r => r.Item2)
                                  .Select(r => r.Item1)
                                  .Take(27)
                                  .ToList();
        }

        private async Task<double> CalculateSimilarity(DataCollector.AnimeData anime1, DataCollector.AnimeData anime2, int maxYearDifference, int maxEpisodeDifference)
        {
            double similarityScore = 0.0;

            // Calculate the similarity score based on the year the anime was released
            int yearDifference = Math.Abs(anime1.Year - anime2.Year);
            if (yearDifference <= maxYearDifference)
            {
                if (yearDifference != -1)
                {
                    similarityScore += 1.0 - (yearDifference / maxYearDifference);
                }
            }

            // int yearDiff = Math.Abs(selectedAnime.Year - anime.Year);
            //score -= Math.Min(yearDiff, maxYearDifference); // subtract the difference, capped

            // Calculate the similarity score based on the number of episodes
            int episodeDifference = Math.Abs(anime1.Episodes - anime2.Episodes);
            if (episodeDifference <= maxEpisodeDifference)
            {
                if (episodeDifference != -1)
                {
                    similarityScore += 1.0 - (episodeDifference / maxEpisodeDifference);
                }
            }

            // int episodeDiff = Math.Abs(selectedAnime.Episodes - anime.Episodes);
            // score -= Math.Min(episodeDiff, maxEpisodeDifference) / 10.0; // less penalty on episodes

            // Calculate the similarity score based on the shared genres with weights
            foreach (var genre in anime1.Genres)
            {
                if (anime2.Genres.Contains(genre))
                {
                    double weight = genreWeights.ContainsKey(genre) ? genreWeights[genre] : 0.5; // Default weight is 0.5
                    similarityScore += weight;
                }
                else
                {
                    similarityScore -= 0.2; // Small penalty for not sharing a genre
                }
            }

            // Calculate additional penalties for having genres that the other anime does not have
            foreach (var genre in anime2.Genres)
            {
                if (!anime1.Genres.Contains(genre))
                {
                    similarityScore -= 0.1; // Small penalty for not sharing a genre
                }
            }

            // Calculate the similarity score based on the shared themes with weights
            foreach (var theme in anime1.Themes)
            {
                if (anime2.Themes.Contains(theme))
                {
                    double weight = themeWeights.ContainsKey(theme) ? themeWeights[theme] : 0.5; // Default weight is 0.5
                    similarityScore += weight;
                }
                else
                {
                    similarityScore -= 0.2; // Small penalty for not sharing a theme
                }
            }

            // Calculate additional penalties for having themes that the other anime does not have
            foreach (var theme in anime2.Themes)
            {
                if (!anime1.Themes.Contains(theme))
                {
                    similarityScore -= 0.1; // Small penalty for not sharing a theme
                }
            }

            // Calculate the similarity score based on the shared age rating
            // if (anime1.AgeRating == anime2.AgeRating)
            // {
            //     similarityScore += 1.0;
            // }

            // Calculate the similarity score based on the mal rating
            if (anime1.Score != 0 && anime2.Score != 0)
            {
                double malRatingDifference = Math.Abs(anime1.Score - anime2.Score);
                similarityScore += 1.0 - (malRatingDifference / 10.0);
            }

            return similarityScore;
        }

        private bool AreTitlesSimilar(string title1, string title2)
        {
            // Remove any non-alphanumeric characters from the titles
            string cleanTitle1 = new string(title1.Where(c => char.IsLetterOrDigit(c)).ToArray());
            string cleanTitle2 = new string(title2.Where(c => char.IsLetterOrDigit(c)).ToArray());

            // Convert the titles to lowercase
            cleanTitle1 = cleanTitle1.ToLower();
            cleanTitle2 = cleanTitle2.ToLower();

            // Remove any whitespace from the titles
            cleanTitle1 = cleanTitle1.Replace(" ", "");
            cleanTitle2 = cleanTitle2.Replace(" ", "");

            // Check if one title contains the other title
            return cleanTitle1.Contains(cleanTitle2) || cleanTitle2.Contains(cleanTitle1);
        }

        private bool AreEnglishTitlesSimilar(string title1, string title2)
        {
            if (!string.IsNullOrEmpty(title1) && !string.IsNullOrEmpty(title2))
            {
                // Remove any non-alphanumeric characters from the titles
                string cleanTitle1 = new string(title1.Where(c => char.IsLetterOrDigit(c)).ToArray());
                string cleanTitle2 = new string(title2.Where(c => char.IsLetterOrDigit(c)).ToArray());

                // Convert the titles to lowercase
                cleanTitle1 = cleanTitle1.ToLower();
                cleanTitle2 = cleanTitle2.ToLower();

                // Remove any whitespace from the titles
                cleanTitle1 = cleanTitle1.Replace(" ", "");
                cleanTitle2 = cleanTitle2.Replace(" ", "");

                // Check if one title contains the other title
                return cleanTitle1.Contains(cleanTitle2) || cleanTitle2.Contains(cleanTitle1);
            }
            else
            {
                return false;
            }
        }
    }
}
