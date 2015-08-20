using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
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

        /// <summary>
        /// Accepts x-www-form-urlencoded string corresponding to the Credentials model
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
        public IHttpActionResult Post([FromBody] Credentials credentials)
        {
            var cookies = _loginService.Login(credentials);
            if (cookies == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(cookies);
        }
    }
}
