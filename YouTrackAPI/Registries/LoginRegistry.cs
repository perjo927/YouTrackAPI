using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using YouTrackAPI.Services;


namespace YouTrackAPI.Registries
{
    public class LoginRegistry : Registry
    {
        public LoginRegistry()
        {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
            For<ILoginService>().Use<LoginService>();
            For<IIssueService>().Use<IssueService>();
        }
    }
}