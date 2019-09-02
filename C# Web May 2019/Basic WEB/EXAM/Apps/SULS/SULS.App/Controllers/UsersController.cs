using SULS.App.Models.BindingModels.UserBindingModels;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using SULS.Services.Contracts;
using SULS.App.Common;
using SIS.MvcFramework.Attributes.Security;

namespace SULS.App.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService userService;

        public UsersController(IUsersService userService)
        {
            this.userService = userService;
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserInputBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Users/Login");
            }

            var user = this.userService.LoginUser(model.Username, model.Password);

            if (user == null)
            {
                this.ModelState.Add("Username or Password", GlobalConstants.InvalidUsernameOrPassword);
                return this.Redirect("/Users/Login");
            }

            this.SignIn(user.Id, user.Username, user.Email);

            return this.Redirect("/");
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserInputBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Users/Register");
            }

            if (model.Password != model.ConfirmPassword)
            {
                this.ModelState.Add(nameof(model.Password), GlobalConstants.MissMatchingRegisterPasswords);
                return this.Redirect("/Users/Register");
            }

            var user = this.userService
                .RegisterUser(model.Username, model.Email, model.Password);

            if (user.Username == null || user.Email == null)
            {
                this.ModelState.Add(user.Id, string.Format(GlobalConstants.UserAlreadyExists, user.Id));
                return this.Redirect("/Users/Register");
            }

            return this.Redirect("/Users/Login");
        }

        [Authorize]
        public IActionResult Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }
    }
}
