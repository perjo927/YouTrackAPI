using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using WebGrease.Css.Extensions;
using YouTrackAPI.Models;
using YouTrackAPI.Services;

namespace YouTrackAPI.Controllers
{
    public class IssuesController : ApiController
    {
        private readonly IIssueService _issueService;

        public IssuesController()
        {
               
        }

        public IssuesController(IIssueService issueService) : base()
        {
            _issueService = issueService;
        }

        [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
        public IEnumerable<Issue> Get()
        {
            var cookieString = GetAuthCookies();
            var issues = _issueService.GetIssues(cookieString);

            return issues;
        }

        [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
        public Issue Get(string id)
        {
            var cookieString = GetAuthCookies();
            var issue = _issueService.GetIssue(cookieString, id);

            return new Issue();
        }

        private string GetAuthCookies()
        {
            var cookieKeys = new[] 
            {
                "YTJSESSIONID", 
                "jetbrains.charisma.main.security.PRINCIPAL", 
            };
            var cookieString = "";

            foreach (var cookieKey in cookieKeys)
            {
                var requestCookie = Request.Headers.GetCookies(cookieKey).FirstOrDefault();
                if (requestCookie != null)
                {
                    cookieString += requestCookie[cookieKey].Value + ""; 
                }
            }
            return cookieString;
        }
        
    }
}
