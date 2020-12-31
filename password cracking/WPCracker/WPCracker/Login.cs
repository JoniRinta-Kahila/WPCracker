using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WPCracker
{
    public class Login
    {
        private readonly Uri _uri;
        private readonly HttpClient _client;

        public Login(Uri uri)
        {
            _client = new HttpClient();
            _uri = uri;
        }

        public async Task<bool> LogInAttemptAsync(string user, string password)
        {
            var dic = new Dictionary<string, string>
            {
                ["log"] = user,
                ["pwd"] = password
            };
            var request = new HttpRequestMessage(HttpMethod.Post, _uri);
            request.Content = new FormUrlEncodedContent(dic);

            var result = await _client.SendAsync(request);

            result.EnsureSuccessStatusCode();

            return result.Headers.First(x => x.Key.Equals("Set-Cookie", StringComparison.Ordinal)).Value
                .Any(x => x.StartsWith("wordpress_logged_in_", StringComparison.Ordinal));
        }
    }
}