using System.Collections.Generic;
using System.Threading.Tasks;
using YouTrackAPI.Models;

namespace YouTrackAPI.Services
{
    public interface IIssueService
    {
        Issue GetIssue(string cookie, string id);

        IEnumerable<Issue> GetIssues(string cookie); // IssueRequest, issueRequest
    }
}