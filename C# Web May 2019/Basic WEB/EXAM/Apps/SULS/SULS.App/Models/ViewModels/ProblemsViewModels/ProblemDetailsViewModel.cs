using SULS.App.Models.ViewModels.SubmissionsViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.Models.ViewModels.ProblemsViewModels
{
    public class ProblemDetailsViewModel
    {
        public ProblemDetailsViewModel()
        {
            this.Submissions = new List<SubmissionDetailsViewModel>();
        }

        public List<SubmissionDetailsViewModel> Submissions { get; set; }

        public string Name { get; set; }
    }
}
