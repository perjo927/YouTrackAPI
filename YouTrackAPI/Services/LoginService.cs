using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using YouTrackAPI.Models;

namespace YouTrackAPI.Services
{
    public class LoginService: ILoginService
    {
        public IList<RestResponseCookie> Login(Credentials credentials)
        {
            IList<RestResponseCookie> cookies = null;

            var client = new RestClient(credentials.Url)
            {
                Authenticator = new SimpleAuthenticator("login", credentials.Login,
                    "password", credentials.Password)
            };
            var request = new RestRequest("", Method.POST);

            // execute the request
            var response = client.Execute(request);
            cookies = response.Cookies;
            return cookies;
        }
    }
}