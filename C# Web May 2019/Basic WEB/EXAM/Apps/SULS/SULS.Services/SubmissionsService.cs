using SULS.Data;
using SULS.Models;
using SULS.Services.Contracts;
using SULS.Services.Dtos.SubmissionsDto;
using System;
using System.Linq;

namespace SULS.Services
{
    public class SubmissionsService : ISubmissionsSurvice
    {
        private readonly SULSContext context;

        public SubmissionsService(SULSContext context)
        {
            this.context = context;
        }

        public SubmissionDto CreateSubmission(string problemId, string code, string userId)
        {
            var problem = this.GetProblemById(problemId);
            var user = this.GetUserById(userId);

            var random = new Random();

            var randomResult = random.Next(0, problem.Points);

            var submission = new Submission
            {
                Code = code,
                Problem = problem,
                CreatedOn = DateTime.UtcNow,
                User = user,
                AchievedResult = randomResult
            };

            this.context.Submissions.Add(submission);
            this.context.SaveChanges();

            return new SubmissionDto();
        }

        public string GetProblemNameById(string id)
        {
            return this.context.Problems.FirstOrDefault(x => x.Id == id).Name;
        }

        public bool DeleteSubmission(string id)
        {
            var submission = this.context.Submissions.FirstOrDefault(x => x.Id == id);

            this.context.Remove(submission);
            this.context.SaveChanges();

            return true;
        }

        private Problem GetProblemById(string id)
        {
            return this.context.Problems.FirstOrDefault(x => x.Id == id);
        }

        private User GetUserById(string id)
        {
            return this.context.Users.FirstOrDefault(x => x.Id == id);
        }
    }
}
