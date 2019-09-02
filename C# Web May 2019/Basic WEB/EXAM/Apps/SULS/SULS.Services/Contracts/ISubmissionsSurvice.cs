using SULS.Services.Dtos.SubmissionsDto;

namespace SULS.Services.Contracts
{
    public interface ISubmissionsSurvice
    {
        string GetProblemNameById(string id);

        SubmissionDto CreateSubmission(string problemId, string code, string userId);

        bool DeleteSubmission(string id);
    }
}
