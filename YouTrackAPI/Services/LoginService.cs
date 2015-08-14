using Flurl;
using Flurl.Http;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using YouTrackAPI.Models;

namespace YouTrackAPI.Services
{
    public class LoginService: ILoginService
    {

        public async Task<IEnumerable<string>> LoginAsync(Credentials credentials)
        {
            IEnumerable<string> cookies = null;

            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                    { "login", credentials.Login },
                    { "password", credentials.Password }
                };


                var content = new FormUrlEncodedContent(values);
                var response = await Task.Run(()=>client.PostAsync(credentials.Url, content)).ConfigureAwait(continueOnCapturedContext: false);

                if (response.IsSuccessStatusCode)
                {
                    var headers = response.Headers;
                    cookies = headers.GetValues("Set-Cookie");
                }
            }
            return cookies;
        }
    }
}