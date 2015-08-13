using System.Threading.Tasks;
using YouTrackAPI.Models;

namespace YouTrackAPI.Services
{
    public interface ILoginService
    {
        Task<string> Login(Credentials credentials);
    }
}
