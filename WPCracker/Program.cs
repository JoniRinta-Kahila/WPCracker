﻿using System;
using System.Linq;
using System.Runtime.InteropServices;
using PowerArgs;

namespace WPCracker
{
    public class Program
    {
        static void Main(string[] args)
        {
            var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            var exe = isWindows ? "WPCracker.exe" : "WPCracker";
            PrintBanner(); 
            Console.WriteLine($"Get help:    > {exe} -? <\n");

            try
            {
                switch (args[0])
                {
                    case "--brute":
                        if (args.Length > 1 && args[1] == "-?")
                            Console.WriteLine(ArgUsage.GenerateUsageFromTemplate<MyArgs.BruteForce>());
                        else
                        {
                            args = args.Skip(1).ToArray();
                            Args.InvokeMain<MyArgs.BruteForce>(args);
                        }
                        break;
                    case "--enum":
                        if (args.Length > 1 && args[1] == "-?")
                            Console.WriteLine(ArgUsage.GenerateUsageFromTemplate<MyArgs.UserEnumeration>());
                        else
                        {
                            args = args.Skip(1).ToArray();
                            Args.InvokeMain<MyArgs.UserEnumeration>(args);
                        }
                        break;
                    default:
                        Console.WriteLine(ArgUsage.GenerateUsageFromTemplate<MyArgs.AttackArgs>());
                        Console.ReadLine();
                        break;
                }
            }
            catch
            {
                Console.WriteLine(ArgUsage.GenerateUsageFromTemplate<MyArgs.AttackArgs>());
                Console.ReadLine();
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
            Console.WriteLine($"                                Not for malicious use                 By Rintsi    v{System.Reflection.Assembly.GetEntryAssembly()?.GetName().Version}");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
