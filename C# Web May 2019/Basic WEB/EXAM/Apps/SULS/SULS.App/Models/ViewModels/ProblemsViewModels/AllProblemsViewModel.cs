using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.Models.ViewModels.ProblemsViewModels
{
    public class AllProblemsViewModel
    {
        public AllProblemsViewModel()
        {
            this.Problems = new List<ProblemViewModel>();
        }

        public List<ProblemViewModel> Problems { get; set; }
    }
}
