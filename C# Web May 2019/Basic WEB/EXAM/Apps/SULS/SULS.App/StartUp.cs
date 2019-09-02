using SIS.MvcFramework;
using SIS.MvcFramework.DependencyContainer;
using SIS.MvcFramework.Routing;
using SULS.Data;
using SULS.Services;
using SULS.Services.Contracts;

namespace SULS.App
{

    public class StartUp : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            using (var db = new SULSContext())
            {
                db.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(IServiceProvider serviceProvider)
        {
            serviceProvider.Add<IUsersService, UsersService>();
            serviceProvider.Add<IProblemsService, ProblemsService>();
            serviceProvider.Add<ISubmissionsSurvice, SubmissionsService>();
        }
    }
}