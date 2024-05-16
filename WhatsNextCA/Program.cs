using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WhatsNextCA
{
    public class DataCollector
    {
        public class AnimeData
        {
            public int Id { get; set; }
            public string Url { get; set; }
            public string ImageUrl { get; set; }
            public string Title { get; set; }
            public string TitleEnglish { get; set; }
            //public string TitleJapanese { get; set; }
            public string Type { get; set; }
            public int Episodes { get; set; }
            //public string Status { get; set; }
            public string AgeRating { get; set; }
            public double Score { get; set; }
            public int Rank { get; set; }
            public int Year { get; set; }
            public List<string> Genres { get; set; }
            public List<string> Themes { get; set; }
        }


        public class Program
        {
            static readonly HttpClient client = new HttpClient();
            static async Task Main(string[] args)
            {
                // Download the most recent anime IDs from the GitHub repository
                string url = "https://raw.githubusercontent.com/seanbreckenridge/mal-id-cache/master/cache/anime_cache.json";
                string localFilePath = @"C:\Users\Carter\Desktop\Coding Projects\WhatsNext\WhatsNextCA\animeIds.txt";
                string jsonFilePath = @"C:\Users\Carter\Desktop\Coding Projects\WhatsNext\WhatsNextCA\animeData.json";
                await DownloadFileAsync(url, localFilePath);

                // Read the JSON file and parse it
                List<int> combinedIds = await ReadAndCombineIdsAsync(localFilePath);

                var animeIds = ReadIdsFromFile("C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextCA\\animeIds.txt");
                var processedIds = ReadProcessedIds("C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextCA\\processedIds.txt");
                var results = new List<AnimeData>();

                double averageRequestTimeMulti = 1.4;
                
                // Print out the amount of time it will take to complete the requests in minutes and in hours
                Console.WriteLine($"Estimated time to complete: {((animeIds.Count - processedIds.Count) * averageRequestTimeMulti) / 60} minutes");
                Console.WriteLine($"Estimated time to complete: {((animeIds.Count - processedIds.Count) * averageRequestTimeMulti)/ 3600} hours");

                foreach (var id in animeIds)
                {
                    // Skip IDs that have already been processed
                    if (processedIds.Contains(id.ToString()))
                    {
                        //Console.WriteLine($"Skipping ID {id} because it has already been processed");
                        continue;
                    }

                    var animeData = await GetAnimeData(id.ToString());
                    if (animeData != null)
                    {
                        results.Add(animeData);

                        File.AppendAllText("C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextCA\\processedIds.txt", id + Environment.NewLine);
                        File.AppendAllText(jsonFilePath, JsonConvert.SerializeObject(animeData, Formatting.Indented) + ",\n");

                        // Print the information to the console
                        Console.WriteLine($"ID: {id}");
                        Console.WriteLine($"Title: {animeData.Title}");
                        Console.WriteLine($"Title (English): {animeData.TitleEnglish}");
                        //Console.WriteLine($"Title (Japanese): {animeData.TitleJapanese}");
                        Console.WriteLine($"Type: {animeData.Type}");
                        Console.WriteLine($"Episodes: {animeData.Episodes}");
                        //Console.WriteLine($"Status: {animeData.Status}");
                        Console.WriteLine($"Age Rating: {animeData.AgeRating}");
                        Console.WriteLine($"Score: {animeData.Score}");
                        Console.WriteLine($"Rank: {animeData.Rank}");
                        Console.WriteLine($"Year: {animeData.Year}");
                        Console.WriteLine($"Genres: {string.Join(", ", animeData.Genres)}");
                        Console.WriteLine($"Themes: {string.Join(", ", animeData.Themes)}");
                        Console.WriteLine();
                    }

                    // Wait 1 second between requests to avoid rate limiting
                    Thread.Sleep(1000);
                }

                //AddSquareBracketsAroundJSONContents("C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextCA\\animeData.json");

                //JArray jsonArray = JArray.Parse(File.ReadAllText("C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextCA\\animeData.json"));
                //foreach (JObject obj in jsonArray)
                //{
                //    obj.Remove("TitleJapanese");
                //}
                //string updatedJson = JsonConvert.SerializeObject(jsonArray, Formatting.Indented);

                //File.WriteAllText("C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextCA\\animeData.json", updatedJson);
                File.WriteAllText("C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextCA\\animeData.json", File.ReadAllText("C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextCA\\animeData.json").TrimEnd(','));

                Console.WriteLine("All requests completed successfully!");
            }

            private static List<int> ReadIdsFromFile(string filePath)
            {
                try
                {
                    // Read the entire file content
                    string jsonContent = File.ReadAllText(filePath);

                    // Deserialize the JSON content into a dynamic object
                    dynamic jsonData = JsonConvert.DeserializeObject<dynamic>(jsonContent);

                    // Extract the "sfw" and "nsfw" lists and convert them to List<int>
                    List<int> sfwIds = jsonData.sfw.ToObject<List<int>>();
                    List<int> nsfwIds = jsonData.nsfw.ToObject<List<int>>();

                    // Combine the two lists
                    List<int> combinedIds = new List<int>(sfwIds);
                    combinedIds.AddRange(nsfwIds);

                    // Optionally sort the combined list
                    combinedIds.Sort();

                    return combinedIds;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Failed to read or parse the JSON file: {e.Message}");
                    return new List<int>(); // Return an empty list in case of failure
                }
            }

            public static async Task<AnimeData> GetAnimeData(string id)
            {
                try
                {
                    var response = await client.GetAsync($"https://api.jikan.moe/v4/anime/{id}");
                    response.EnsureSuccessStatusCode();
                    var responseBody = await response.Content.ReadAsStringAsync();

                    // Deserialize the entire response and then extract specific fields
                    var json = JsonConvert.DeserializeObject<dynamic>(responseBody);
                    var data = json.data;

                    int numId = -1;
                    try
                    {
                        numId = Int32.Parse(id);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    var anime = new AnimeData
                    {
                        Id = numId,
                        Url = data.url,
                        ImageUrl = data.imageUrl,
                        Title = data.title,
                        TitleEnglish = data.title_english,
                        //TitleJapanese = data.title_japanese,
                        Type = data.type,
                        Episodes = data.episodes != null ? (int)data.episodes : -1, // Handle null episodes
                        //Status = data.status,
                        AgeRating = data.rating,
                        Score = data.score != null ? (double)data.score : 0.0, // Handle null score
                        Rank = data.rank != null ? (int)data.rank : -1, // Handle null rank
                        Year = data.year != null ? (int)data.year : -1, // Handle null year
                        Genres = new List<string> (),
                        Themes = new List<string>()
                    };

                    foreach (var genre in data.genres)
                    {
                        anime.Genres.Add((string)genre.name);
                    }

                    foreach (var theme in data.themes)
                    {
                        anime.Themes.Add((string)theme.name);
                    }

                    return anime;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request failed for ID {id}: {e.Message}");
                    return null;
                }
            }

           private static HashSet<string> ReadProcessedIds(string filePath)
            {
                var processedIds = new HashSet<string>();
                if (File.Exists(filePath))
                {
                    var lines = File.ReadAllLines(filePath);
                    foreach (var line in lines)
                    {
                        processedIds.Add(line.Trim());
                    }
                }
                return processedIds;
            }

            private static async Task DownloadFileAsync(string url, string outputFile)
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    File.WriteAllText(outputFile, responseBody);
                    Console.WriteLine("File downloaded and saved successfully!");
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Error downloading file: {e.Message}");
                }
            }

            private static async Task<List<int>> ReadAndCombineIdsAsync(string filePath)
            {
                try
                {
                    string jsonContent = File.ReadAllText(filePath);
                    dynamic jsonData = JsonConvert.DeserializeObject<dynamic>(jsonContent);

                    List<int> sfwIds = jsonData.sfw.ToObject<List<int>>();
                    List<int> nsfwIds = jsonData.nsfw.ToObject<List<int>>();

                    List<int> combinedIds = new List<int>(sfwIds);
                    combinedIds.AddRange(nsfwIds); // Combine the two lists
                    combinedIds.Sort(); // Sort the combined list

                    return combinedIds;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Failed to read or parse the JSON file: {e.Message}");
                    return new List<int>();  // Return an empty list in case of failure
                }
            }

            private static void AddSquareBracketsAroundJSONContents(string filePath)
            {
                string jsonContent = File.ReadAllText(filePath);
                jsonContent = "[" + jsonContent + "]";
                File.WriteAllText(filePath, jsonContent);
            }
        }
    }
}
