using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using YouTrackAPI.Models;

namespace YouTrackAPI.Services
{
    public class LoginService: ILoginService
    {

        public async Task<string> Login(Credentials credentials)
        {
            var token = "";

            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                    { "thing1", "hello" },
                    { "thing2", "world" }
                };

                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);

                var responseString = await response.Content.ReadAsStringAsync();
            }

            return "";
        }
    }
}