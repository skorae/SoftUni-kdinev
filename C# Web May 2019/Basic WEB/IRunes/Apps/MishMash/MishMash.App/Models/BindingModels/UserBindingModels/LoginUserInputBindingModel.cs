using MishMash.App.Common;
using SIS.MvcFramework.Attributes.Validation;

namespace MishMash.App.Models.BindingModels.UserBindingModels
{
    public class LoginUserInputBindingModel
    {
        private const string UsernameError = "Username should be between 5 and 20 symbols long.";

        [RequiredSis(GlobalConstants.InvalidUsernameOrPassword)]
        [StringLengthSis(5, 20, UsernameError)]
        public string Username { get; set; }

        [RequiredSis(GlobalConstants.InvalidUsernameOrPassword)]
        public string Password { get; set; }
    }
}
