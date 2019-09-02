using Microsoft.EntityFrameworkCore;
using SULS.Data;
using SULS.Models;
using SULS.Services.Contracts;
using SULS.Services.Dtos.ProblemsDto;
using SULS.Services.Dtos.SubmissionsDto;
using System.Linq;

namespace SULS.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly SULSContext context;
        private readonly ISubmissionsSurvice submissionsSurvice;

        public ProblemsService(SULSContext context, ISubmissionsSurvice submissionsSurvice)
        {
            this.context = context;
            this.submissionsSurvice = submissionsSurvice;
        }

        public ProblemDto CreateProblem(string name, int points)
        {
            if (this.context.Problems.Any(x => x.Name == name))
            {
                return null;
            }

            var problem = new Problem()
            {
                Name = name,
                Points = points
            };

            this.context.Problems.Add(problem);
            this.context.SaveChanges();

            return new ProblemDto();
        }

        public AllProblemsDto GetAllProblems()
        {
            var allProblemsDto = new AllProblemsDto();

            var problemCollectionDto = this.context.Problems.ToList();

            foreach (var dto in problemCollectionDto)
            {
                int submitionsCount = this.context.Submissions
                    .Count(x => x.Problem.Id == dto.Id);

                allProblemsDto.Problems.Add(new ProblemDto
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Count = submitionsCount
                });
            }

            return allProblemsDto;
        }

        public AllsubmissionsForProjectDto GetDetails(string id)
        {
            var submissionsForProject = this.context
                 .Submissions
                 .Include(x => x.Problem)
                 .Where(x => x.Problem.Id == id)
                 .Select(x => new SubmissionDto
                 {
                     SubmittedOn = x.CreatedOn,
                     AchievedResult = new int[2] { x.AchievedResult, x.Problem.Points },
                     SubmissionId = x.Id,
                     User = x.User.Username
                 })
                 .ToList();

            var name = this.submissionsSurvice.GetProblemNameById(id);

            var dto = new AllsubmissionsForProjectDto
            {
                Submissions = submissionsForProject,
                Name = name
            };

            return dto;
        }
    }
}
