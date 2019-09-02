using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Mapping;
using SIS.MvcFramework.Result;
using SULS.App.Models.ViewModels.ProblemsViewModels;
using SULS.Services.Contracts;
using System.Collections.Generic;

namespace SULS.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProblemsService problemsService;

        public HomeController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }

        public IActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                var allProblems = this.problemsService.GetAllProblems();

                var model = new AllProblemsViewModel();

                foreach (var p in allProblems.Problems)
                {
                    model.Problems.Add(new ProblemViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Count = p.Count
                    });
                }

                return this.View(model,"IndexLoggedIn");
            }

            return this.View();
        }
    }
}
