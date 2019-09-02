using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Mapping;
using SIS.MvcFramework.Result;
using SULS.App.Common;
using SULS.App.Models.BindingModels.ProblemsBindingModels;
using SULS.App.Models.ViewModels.ProblemsViewModels;
using SULS.App.Models.ViewModels.SubmissionsViewModel;
using SULS.Services.Contracts;

namespace SULS.App.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;

        public ProblemsController(IProblemsService  problemsService)
        {
            this.problemsService = problemsService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(ProblemCreateInputBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Problems/Create");
            }

            var problem = this.problemsService.CreateProblem(model.Name, model.Points);

            if (problem == null)
            {
                this.ModelState.Add("Problem", GlobalConstants.ProblemExists);
                return this.Redirect("/Problems/Create");
            }

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var submissions = this.problemsService.GetDetails(id);

            if (submissions.Submissions.Count == 0)
            {
                return this.View(new ProblemDetailsViewModel());
            }

            var model = new ProblemDetailsViewModel();
            model.Name = submissions.Name;

            foreach (var s in submissions.Submissions)
            {
                model.Submissions.Add(new SubmissionDetailsViewModel
                {
                    AchievedResult = $"{s.AchievedResult[0]} / {s.AchievedResult[1]}",
                    SubmissionId = s.SubmissionId,
                    SubmittedOn = s.SubmittedOn.ToString("dd/MM/yyyy"),
                    User = s.User
                });
            }

            return this.View(model);
        }
    }
}
