using SIS.MvcFramework.Attributes.Validation;

namespace SULS.App.Models.BindingModels.ProblemsBindingModels
{
    public class ProblemCreateInputBindingModel
    {
        private const string InvalidInput = "Invalid Input.";
        private const string NameError = "Problem name should be between 5 and 20 symbols long.";
        private const string PointsError = "Total points should be between 50 and 300";
            
        [RequiredSis(InvalidInput)]
        [StringLengthSis(5,20,NameError)]
        public string Name { get; set; }

        [RequiredSis(InvalidInput)]
        [RangeSis(50,300,PointsError)]
        public int Points { get; set; }
    }
}
