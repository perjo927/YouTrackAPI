using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using YouTrackAPI.Models;

namespace YouTrackAPI.Services
{
    public interface ILoginService
    {
        IList<RestResponseCookie> Login(Credentials credentials);
    }
}
