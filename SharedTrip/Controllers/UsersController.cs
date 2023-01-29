﻿namespace SharedTrip.Controllers
{
    using SharedTrip.Data;
    using SharedTrip.Data.Models;
    using SharedTrip.Models.Users;
    using SharedTrip.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;
    using static Data.DataConstants;

    public class UsersController : Controller
    {
        //private readonly IValidator validator;
        //private readonly IPasswordHasher passwordHasher;
        //private readonly SharedtripDbContext data;


        //public UsersController(
        //    IValidator validator,
        //    IPasswordHasher passwordHasher,
        //    SharedtripDbContext data)
        //{
        //    this.validator = validator;
        //    this.passwordHasher = passwordHasher;
        //    this.data = data;
        //}

        //public HttpResponse Register() => View();

        //[HttpPost]
        //public HttpResponse Register(RegisterUserFormModel model)
        //{
        //    var modelErrors = this.validator.ValidateUser(model);

        //    if (this.data.Users.Any(u => u.Username == model.Username))
        //    {
        //        modelErrors.Add($"User with '{model.Username}' username already exists.");
        //    }

        //    if (this.data.Users.Any(u => u.Email == model.Email))
        //    {
        //        modelErrors.Add($"User with '{model.Email}' e-mail already exists.");
        //    }

        //    if (modelErrors.Any())
        //    {
        //        return Error(modelErrors);
        //    }

        //    var user = new User
        //    {
        //        Username = model.Username,
        //        Password = this.passwordHasher.HashPassword(model.Password),
        //        Email = model.Email,
        //    };

        //    data.Users.Add(user);

        //    data.SaveChanges();

        //    return Redirect("/Users/login");
        //}

        //public HttpResponse Login() => View();

        //[HttpPost]
        //public HttpResponse Login(LoginUserFormModel model)
        //{
        //    var hashPassword = this.passwordHasher.HashPassword(model.Password);

        //    var userId = this.data
        //        .Users
        //        .Where(u => u.Username == model.Username && u.Password == hashPassword)
        //        .Select(u => u.Id)
        //        .FirstOrDefault();

        //    if (userId == null)
        //    {
        //        return Error("Username and password combination is not valid.");
        //    }

        //    this.SignIn(userId);

        //    return Redirect("/Cars/All");
        //}

        //public HttpResponse Logout()
        //{
        //    this.SignOut();

        //    return Redirect("/");
        //}
    }
}
