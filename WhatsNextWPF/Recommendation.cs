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

        Dictionary<string, double> genreWeights = new Dictionary<string, double>
        {
            {"Action", 0.1},
            {"Adventure", 0.4},
            {"Avant Garde", 0.9},
            {"Award Winning", 0.2},
            {"Boys Love", 0.9},
            {"Comedy", 0.7},
            {"Drama", 0.7},
            {"Ecchi", 1.0},
            {"Erotica", 1.0},
            {"Fantasy", 0.3},
            {"Girls Love", 0.9},
            {"Gourmet", 0.8},
            {"Hentai", 1.0},
            {"Horror", 0.8},
            {"Mystery", 0.8},
            {"Romance", 0.6},
            {"Sci-Fi", 0.4},
            {"Slice of Life", 0.4},
            {"Sports", 0.9},
            {"Supernatural", 0.5},
            {"Suspense", 0.8}
        };
        Dictionary<string, double> themeWeights = new Dictionary<string, double>
        {
            {"Adult Cast", 0.6},
            {"Anthropomorphic", 0.7},
            {"CGDCT", 0.9},
            {"Childcare", 0.8},
            {"Combat Sports", 0.9},
            {"Crossdressing", 0.8},
            {"Delinquents", 0.8},
            {"Detective", 0.9},
            {"Educational", 1.0},
            {"Gag Humor", 0.9},
            {"Gore", 0.9},
            {"Harem", 0.4},
            {"High Stakes Game", 0.7},
            {"Historical", 0.9},
            {"Idol (Female)", 0.7},
            {"Idol (Male)", 0.7},
            {"Isekai", 0.5},
            {"Iyashikei", 0.8},
            {"Love Polygon", 0.6},
            {"Magical Sex Shift", 1.0},
            {"Mahou Shoujo", 0.8},
            {"Martial Arts", 0.8},
            {"Mecha", 0.8},
            {"Medical", 0.9},
            {"Military", 0.8},
            {"Music", 0.9},
            {"Mythology", 0.7},
            {"Organized Crime", 0.7},
            {"Otaku Culture", 0.6},
            {"Parody", 1.0},
            {"Performing Arts", 0.9},
            {"Pets", 0.6},
            {"Psychological", 0.8},
            {"Racing", 0.9},
            {"Reincarnation", 0.5},
            {"Reverse Harem", 0.5},
            {"Romantic Subtext", 0.6},
            {"Samurai", 0.8},
            {"School", 0.2},
            {"Showbiz", 0.8},
            {"Space", 0.9},
            {"Strategy Game", 0.9},
            {"Super Power", 0.4},
            {"Survival", 0.7},
            {"Team Sports", 0.9},
            {"Time Travel", 1.0},
            {"Vampire", 0.8},
            {"Video Game", 0.8},
            {"Visual Arts", 0.9},
            {"Workplace", 0.6}
        };
        public Recommendation()
        {
            string jsonData = File.ReadAllText(jsonPath);
            
            this.animes = JsonConvert.DeserializeObject<List<DataCollector.AnimeData>>(jsonData);
        }

        public void AssignValues(DataCollector.AnimeData aD, int id, string url, string imageUrl, string title, string titleEnglish, string titleJapanese, string type, int episodes, string ageRating, double malRating, int rank, int year, List<string> genres, List<string> themes)
        {
            aD.Id = id;
            aD.Url = url;
            aD.ImageUrl = imageUrl.First().ToString();
            aD.Title = title;
            aD.TitleEnglish = titleEnglish;
            //aD.TitleJapanese = titleJapanese;
            aD.Type = type;
            aD.Episodes = episodes;
            aD.AgeRating = ageRating;
            aD.Score = malRating;
            aD.Rank = rank;
            aD.Year = year;
            aD.Genres = genres;
            aD.Themes = themes;
        }

        public DataCollector.AnimeData GetAnimeFromTitle(string title)
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
                // Skip the anime if it is the same as the input anime
                if (a.Title == anime.Title)
                {
                    continue;
                }

                // Calculate the similarity score between the input anime and the current anime
                double similarityScore = CalculateSimilarity(anime, a, maxYearDifference, maxEpisodeDifference);

                // Add the anime and its similarity score to the list of recommendations
                recommendations.Add(new Tuple<DataCollector.AnimeData, double>(a, similarityScore));
            }

            // Sort the recommendations by similarity score in descending order, taking the top 10
            return recommendations.OrderByDescending(r => r.Item2)
                                  .Select(r => r.Item1)
                                  .Take(10)
                                  .ToList();
        }

        private double CalculateSimilarity(DataCollector.AnimeData anime1, DataCollector.AnimeData anime2, int maxYearDifference, int maxEpisodeDifference)
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
    }
}
