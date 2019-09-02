using System;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.Models.BindingModels.SubmissionsBindingModels;
using SULS.App.Models.ViewModels.SubmissionsViewModel;
using SULS.Services.Contracts;

namespace SULS.App.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ISubmissionsSurvice submissionsSurvice;

        public SubmissionsController(ISubmissionsSurvice submissionsSurvice)
        {
            this.submissionsSurvice = submissionsSurvice;
        }

        [Authorize]
        public IActionResult Create(string id)
        {
            var name = this.submissionsSurvice.GetProblemNameById(id);

            var model = new SubmissionCreateProblemIdViewModel
            {
                ProblemId = id,
                Name = name
            };

            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(SubmissionCreateInputBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Submissions/Create");
            }

            this.submissionsSurvice.CreateSubmission(model.ProblemId, model.Code, this.User.Id);

            return this.Redirect("/");
        }



        [Authorize]
        public IActionResult Delete(string id)
        {
            this.submissionsSurvice.DeleteSubmission(id);

            return this.Redirect("/");
        }
    }
}
