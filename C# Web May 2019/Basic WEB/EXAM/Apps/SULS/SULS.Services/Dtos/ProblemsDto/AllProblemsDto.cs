using System.Collections.Generic;

namespace SULS.Services.Dtos.ProblemsDto
{
    public class AllProblemsDto
    {
        public AllProblemsDto()
        {
            this.Problems = new List<ProblemDto>();
        }

        public List<ProblemDto> Problems = new List<ProblemDto>();
    }
}
