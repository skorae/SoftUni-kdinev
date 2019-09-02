using MishMash.App.Common;
using SIS.MvcFramework.Attributes.Validation;

namespace MishMash.App.Models.BindingModels.UserBindingModels
{
    public class RegisterUserInputBindingModel
    {
        private const string UsernameError = "Username should be between 5 and 20 symbols long.";
        private const string EmailError = "Username should be between 5 and 20 symbols long.";

        [RequiredSis]
        [StringLengthSis(5, 20, UsernameError)]
        public string Username { get; set; }

        [RequiredSis]
        [PasswordSis(nameof(ConfirmPassword))]
        public string Password { get; set; }

        [RequiredSis]
        public string ConfirmPassword { get; set; }

        [RequiredSis]
        [EmailSis(GlobalConstants.InvalidEmail)]
        [StringLengthSis(5, 50, EmailError)]
        public string Email { get; set; }
    }
}
