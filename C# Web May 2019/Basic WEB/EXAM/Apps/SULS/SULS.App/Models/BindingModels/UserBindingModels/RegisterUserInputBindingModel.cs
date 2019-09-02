using SIS.MvcFramework.Attributes.Validation;
using SULS.App.Common;

namespace SULS.App.Models.BindingModels.UserBindingModels
{
    public class RegisterUserInputBindingModel
    {
        private const string UsernameError = "Username should be between 5 and 20 symbols long.";
        private const string EmailError = "Username should be between 5 and 50 symbols long.";
        private const string PasswordError = "Password should be between 6 and 20 symbols long.";

        [RequiredSis]
        [StringLengthSis(5, 20, UsernameError)]
        public string Username { get; set; }

        [RequiredSis]
        [StringLengthSis(6, 50, PasswordError)]
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
