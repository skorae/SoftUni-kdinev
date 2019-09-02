using System.Collections.Generic;

namespace SULS.Services.Dtos.SubmissionsDto
{
    public class AllsubmissionsForProjectDto
    {
        public AllsubmissionsForProjectDto()
        {
            this.Submissions = new List<SubmissionDto>();
        }
        public List<SubmissionDto> Submissions { get; set; }

        public string Name { get; set; }
    }
}
