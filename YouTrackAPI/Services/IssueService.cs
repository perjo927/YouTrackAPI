using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using RestSharp;
using YouTrackAPI.Models;

namespace YouTrackAPI.Services
{
    public class IssueService : IIssueService
    {


        // https://tracking.betsson.local/rest/issue?max=50&with=state&with=Brand&with=summary&with=description&with=Prio&with=Estimated Days&filter=Project: {Realm Backlog} sort by: Prio desc #XXX #Feature"

        public Issue GetIssue(string cookieString, string id)
        {
            var issue = new Issue();

            // TODO: pass the parameter as part of method call ()
            // TODO: Don't set the client everytime, inject?
            var client = new RestClient("https://tr*cking.b*tsson.local/");

            var request = new RestRequest("rest/issue/{id}", Method.GET);
            request.AddUrlSegment("id", id); // replaces matching token in request.Resource
            request.AddHeader("Cookie", cookieString);

            var response = client.Execute(request);
            var content = response.Content; 

            return issue;
        }

        public IEnumerable<Issue> GetIssues(string cookie) // IssueRequest issueRequest, int id)
        {
            // TODO: How to set cookie?
            //var responseString = await Task.Run(() => client.GetStringAsync("https://tr*cking.b*tsson.local/rest/issue?max=50&with=state&with=Brand&with=summary&with=description&with=Prio&with=Estimated")).ConfigureAwait(continueOnCapturedContext: false);

            throw new NotImplementedException();
        }
    }
}