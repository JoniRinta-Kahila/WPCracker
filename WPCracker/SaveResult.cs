using System;
using System.IO;

namespace WPCracker
{
    public class SaveResult
    {
        public async void UsersToFileAsync(string uri, string outFilePath, WpUserInfo res, bool firstLineOfResult)
        {
            var url = new Uri(uri).Host;
            var fLine = firstLineOfResult ? 
                @$"{Environment.NewLine}$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$${Environment.NewLine}Username(s) to {url}" : "\n";

            await File.AppendAllTextAsync(Path.Combine(outFilePath, "WP-Users.txt"), @$"{fLine}
ID:.............{res.Id}
NAME:...........{res.Name}
DESCRIPTION:....{res.Description}
LINK:...........{res.Link}
LINK:...........{res.Link}
URL:............{url}
SLUG:...........{res.Slug}");
        }

        public async void LoginCredentialsToFileAsync(string uri, string outFilePath, string user, string pwd)
        {
            var url = new Uri(uri).Host;

            await File.AppendAllTextAsync(Path.Combine(outFilePath, "WP-Logins.txt"), $@"Login Credentials to {url}
Username: {user}
Password: {pwd}{Environment.NewLine}
");
        }
    }
}
