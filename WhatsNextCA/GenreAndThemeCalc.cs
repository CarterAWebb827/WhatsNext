using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace WhatsNextCA
{
    public class Weights
    {
        public Dictionary<string, double> GenreWeights { get; set; }
        public Dictionary<string, double> ThemeWeights { get; set; }
    }

    public class GenreAndThemeCalc
    {

        public static void Calculation(Dictionary<string, double> gW, Dictionary<string, double> tW)
        {
            string jsonFilePath = @"C:\Users\Carter\Desktop\Coding Projects\WhatsNext\WhatsNextCA\animeData.json";
            string weightsFilePath = @"C:\Users\Carter\Desktop\Coding Projects\WhatsNext\WhatsNextCA\weights.json";
            string json = File.ReadAllText(jsonFilePath);
            List<DataCollector.AnimeData> animeDatas = JsonConvert.DeserializeObject<List<DataCollector.AnimeData>>(json);

            Dictionary<string, double> genreWeights = gW;
            Dictionary<string, double> themeWeights = tW;

            // Calculate the genre and theme weights for each anime based on frequency
            Dictionary<string, int> genreFreq = new Dictionary<string, int>();
            Dictionary<string, int> themeFreq = new Dictionary<string, int>();
            int totalAnime = animeDatas.Count;

            foreach (var anime in animeDatas)
            {
                foreach (var genre in anime.Genres)
                {
                    if (genreFreq.ContainsKey(genre))
                    {
                        genreFreq[genre]++;
                    }
                    else
                    {
                        genreFreq.Add(genre, 1);
                    }
                }

                foreach (var theme in anime.Themes)
                {
                    if (themeFreq.ContainsKey(theme))
                    {
                        themeFreq[theme]++;
                    }
                    else
                    {
                        themeFreq.Add(theme, 1);
                    }
                }
            }

            // Update the wiehgts based on the frequency
            foreach (var genre in genreFreq.Keys.ToList())
            {
                if (genreWeights.ContainsKey(genre))
                {
                    genreWeights[genre] = 1.0 - ((double)genreFreq[genre] / totalAnime);
                }
                else
                {
                    genreWeights[genre] = 1.0;
                }
            }

            foreach (var theme in themeFreq.Keys.ToList())
            {
                if (themeWeights.ContainsKey(theme))
                {
                    themeWeights[theme] = 1.0 - ((double)themeFreq[theme] / totalAnime);
                }
                else
                {
                    themeWeights[theme] = 1.0;
                }
            }

            Console.WriteLine("Genre Weights:");
            foreach (var genre in genreWeights)
            {
                Console.WriteLine(genre.Key + ": " + genre.Value);
            }

            Console.WriteLine("\nTheme Weights:");
            foreach (var theme in themeWeights)
            {
                Console.WriteLine(theme.Key + ": " + theme.Value);
            }

            Weights weights = new Weights
            {
                GenreWeights = genreWeights,
                ThemeWeights = themeWeights
            };

            string genreWeightsJson = JsonConvert.SerializeObject(weights, Formatting.Indented);

            File.WriteAllText(weightsFilePath, genreWeightsJson);

            //return Tuple.Create(genreWeights, themeWeights);
        }
    }
}