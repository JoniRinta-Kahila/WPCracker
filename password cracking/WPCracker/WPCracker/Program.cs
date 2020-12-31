using System;
using PowerArgs;

namespace WPCracker
{
    public class Program
    {
        static void Main(string[] args)
        {
            PrintBanner();
            Console.WriteLine("Get help:    > WPCracker.exe -? <\n");
            try
            {
                Args.InvokeMain<MyArgs.BruteForce>(args);
            }
            catch
            {
                Console.WriteLine(ArgUsage.GenerateUsageFromTemplate<MyArgs>());
            }
        }

        private static void PrintBanner()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine(@" /$$      /$$ /$$$$$$$   /$$$$$$                               /$$                          ");
            Console.WriteLine(@"| $$  /$ | $$| $$__  $$ /$$__  $$                             | $$                          ");
            Console.WriteLine(@"| $$ /$$$| $$| $$  \ $$| $$  \__/  /$$$$$$  /$$$$$$   /$$$$$$$| $$   /$$  /$$$$$$   /$$$$$$ ");
            Console.WriteLine(@"| $$/$$ $$ $$| $$$$$$$/| $$       /$$__  $$|____  $$ /$$_____/| $$  /$$/ /$$__  $$ /$$__  $$");
            Console.WriteLine(@"| $$$$_  $$$$| $$____/ | $$      | $$  \__/ /$$$$$$$| $$      | $$$$$$/ | $$$$$$$$| $$  \__/");
            Console.WriteLine(@"| $$$/ \  $$$| $$      | $$    $$| $$      /$$__  $$| $$      | $$_  $$ | $$_____/| $$      ");
            Console.WriteLine(@"| $$/   \  $$| $$      |  $$$$$$/| $$     |  $$$$$$$|  $$$$$$$| $$ \  $$|  $$$$$$$| $$      ");
            Console.WriteLine(@"|__/     \__/|__/       \______/ |__/      \_______/ \_______/|__/  \__/ \_______/|__/      ");
            Console.WriteLine("                                Not for malicious use                      By Rintsi    v1.0 ");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}