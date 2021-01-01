using System;
using PowerArgs;

namespace WPCracker
{
    public class MyArgs
    {
        public class BruteForce
        {
            [HelpHook, ArgShortcut("-?"), ArgDescription("Shows this help")]
            public bool Help { get; set; }

            [ArgRequired(PromptIfMissing = true), ArgShortcut("u"), ArgDescription("The victim's HTTP web address")]
            public string TargetUri { get; set; }

            [ArgRequired(PromptIfMissing = true), ArgExistingFile, ArgShortcut("p"), ArgDescription("Path to wordlist")]
            public string WordlistPath { get; set; }

            [ArgRequired(PromptIfMissing = true), ArgShortcut("n"), ArgDescription("The username of the victim")]
            public string Username { get; set; }

            [ArgDefaultValue(12), ArgShortcut("t"), ArgDescription("Maximum number of threads allowed")]
            public int MaxThreads { get; set; }

            [ArgDefaultValue(1000), ArgShortcut("c"), ArgDescription("Maximum size of test batch per thread")]
            public int BatchCount { get; set; }

            public void Main()
            {
                Attacks.BruteForceAttack(TargetUri, Username, WordlistPath, MaxThreads, BatchCount);
                Console.ReadLine();
            }
        }
    }
}