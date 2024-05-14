using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WhatsNextCA
{
    class DataCollector
    {
        public class AnimeData
        {
            public string Url { get; set; }
            public string imageUrl { get; set; }
            public string Title { get; set; }
            public string Type { get; set; }
            //public string Status { get; set; }
            public string AgeRating { get; set; }
            public double Score { get; set; }
            public int Rank { get; set; }
            //public int Year { get; set; }
            public List<string> Genres { get; set; }
        }


        class Program
        {
            static readonly HttpClient client = new HttpClient();
            static async Task Main(string[] args)
            {
                var animeIds = ReadIdsFromFile("C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextCA\\animeIds.txt");
                var results = new List<AnimeData>();

                // Print out the amount of time it will take to complete the requests in minutes and in hours
                Console.WriteLine($"Estimated time to complete: {animeIds.Count / 60} minutes");
                Console.WriteLine($"Estimated time to complete: {animeIds.Count / 3600} hours");

                foreach (var id in animeIds)
                {
                    var animeData = await GetAnimeData(id);
                    if (animeData != null)
                    {
                        results.Add(animeData);

                        // Print the information to the console
                        Console.WriteLine($"Title: {animeData.Title}");
                        Console.WriteLine($"Type: {animeData.Type}");
                        //Console.WriteLine($"Status: {animeData.Status}");
                        Console.WriteLine($"Age Rating: {animeData.AgeRating}");
                        Console.WriteLine($"Score: {animeData.Score}");
                        Console.WriteLine($"Rank: {animeData.Rank}");
                        //Console.WriteLine($"Year: {animeData.Year}");
                        Console.WriteLine($"Genres: {string.Join(", ", animeData.Genres)}");
                        Console.WriteLine();
                    }

                    // Wait 1 second between requests to avoid rate limiting
                    Thread.Sleep(1000);
                }

                File.WriteAllText("C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextCA\animeData.json", JsonConvert.SerializeObject(results, Formatting.Indented));
            }

            static List<string> ReadIdsFromFile(string filePath)
            {
                var ids = new List<string>();
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    ids.AddRange(JsonConvert.DeserializeObject<List<string>>(line));
                }
                return ids;
            }

            static async Task<AnimeData> GetAnimeData(string id)
            {
                try
                {
                    var response = await client.GetAsync($"https://api.jikan.moe/v4/anime/{id}");
                    response.EnsureSuccessStatusCode();
                    var responseBody = await response.Content.ReadAsStringAsync();

                    // Deserialize the entire response and then extract specific fields
                    var json = JsonConvert.DeserializeObject<dynamic>(responseBody);
                    var data = json.data;

                    var anime = new AnimeData
                    {
                        Url = data.url,
                        imageUrl = data.imageUrl,
                        Title = data.title,
                        Type = data.type,
                        //Status = data.status,
                        AgeRating = data.rating,
                        Score = data.score,
                        Rank = data.rank,
                        //Year = data.year
                        Genres = new List<string> ()
                    };

                    foreach (var genre in data.genres)
                    {
                        anime.Genres.Add((string)genre.name);
                    }

                    return anime;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request failed for ID {id}: {e.Message}");
                    return null;
                }
            }
        }
    }
}
