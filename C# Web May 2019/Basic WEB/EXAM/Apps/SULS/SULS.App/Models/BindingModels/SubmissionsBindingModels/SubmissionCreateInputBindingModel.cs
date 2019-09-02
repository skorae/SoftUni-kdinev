using SIS.MvcFramework.Attributes.Validation;

namespace SULS.App.Models.BindingModels.SubmissionsBindingModels
{
    public class SubmissionCreateInputBindingModel
    {
        private const string Error = "No code was entered.";
        private const string InvalidLenght = "Code should be between 30 and 800 symbols long.";

        public string ProblemId { get; set; }

        [RequiredSis(Error)]
        [StringLengthSis(30, 800, InvalidLenght)]
        public string Code { get; set; }
    }
}
