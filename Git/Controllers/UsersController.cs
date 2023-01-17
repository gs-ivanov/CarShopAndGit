namespace Git.Controllers
{
    using Git.Models.Users;
    using Git.Services;
    using Git.Data;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly GitDbContext data;

        public UsersController(
            IValidator validator,
            GitDbContext data
            )
        {
            this.validator = validator;
            this.data = data;
        }

        public HttpResponse Register() => View();

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel model)
        {
            var modelErrors = this.validator.ValidateUser(model);

            if (this.data.Users.Any(u => u.Username == model.Username))
            {
                modelErrors.Add($"User with '{model.Username}' username already exists.");
            }

            if (this.data.Users.Any(u => u.Email == model.Email))
            {
                modelErrors.Add($"User with '{model.Username}' e-mail already exists.");
            }

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }
                return Error(modelErrors);

            //var user=data

            //return null;
        }


        public HttpResponse Login() => View();
    }
}
