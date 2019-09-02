using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.Services.Dtos.SubmissionsDto
{
    public class SubmissionDto
    {
        public string SubmissionId { get; set; }

        public string User { get; set; }

        public int[] AchievedResult { get; set; }

        public DateTime SubmittedOn { get; set; }
    }
}
