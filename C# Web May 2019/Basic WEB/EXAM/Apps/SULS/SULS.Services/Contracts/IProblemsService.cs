using SULS.Services.Dtos.ProblemsDto;
using SULS.Services.Dtos.SubmissionsDto;

namespace SULS.Services.Contracts
{
    public interface IProblemsService
    {
        ProblemDto CreateProblem(string name, int points);

        AllProblemsDto GetAllProblems();

        AllsubmissionsForProjectDto GetDetails(string id);
    }
}
