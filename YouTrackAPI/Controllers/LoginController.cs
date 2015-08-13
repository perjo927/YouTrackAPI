using System.Web.Http;
using YouTrackAPI.Models;
using YouTrackAPI.Services;

namespace YouTrackAPI.Controllers
{
    public class LoginController : ApiController
    {
        private readonly ILoginService _loginService;

        public LoginController() 
        {
        }
        public LoginController(ILoginService loginService) : base()
        {
            _loginService = loginService;
        }

        public string Post([FromBody] Credentials credentials)
        {
            var token = _loginService.Login(credentials);
            return $"Login {credentials.Login}, Password: {credentials.Password}"; // token;
        }
    }
}
