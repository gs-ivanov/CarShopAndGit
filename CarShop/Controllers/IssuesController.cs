namespace CarShop.Controllers
{
    using CarShop.Data;
    using CarShop.Models.Issues;
    using CarShop.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;
    public class IssuesController : Controller
    {
        private readonly IUserService userService;
        private readonly CarShopDbContext data;
        public IssuesController(IUserService userService, CarShopDbContext data)
        {
            this.userService = userService;
            this.data = data;
        }

        [Authorize]
        public HttpResponse Add(string carId)
        {
            System.Console.WriteLine($"Car id is: {carId}");

            return View();
        }

        [HttpPost]
            public HttpResponse Add(IssueListingViewModel model)
        {
            return Redirect("/Cars/All");
        }

        [Authorize]
        public HttpResponse CarIssues(string carId)
        {
            if (!this.userService.IsMechanic(this.User.Id))
            {
                var userOwnsCar = this.data.Cars
                    .Any(c => c.Id == carId && c.OwnerId == this.User.Id);


                if (!userOwnsCar)
                {
                    return Error("You do not have access to this car.");
                }
            }

            var carWithIssue = this.data
                .Cars
                .Where(c => c.Id == carId)
                .Select(c => new CarIssuesViewModel
                {
                    Id = c.Id,
                    Model = c.Model,
                    Year = c.Year,
                    Issues = c.Issues.Select(i => new IssueListingViewModel
                    {
                        Id = i.Id,
                        Description = i.Description,
                        IsFixed = i.IsFixed
                    })
                })
                .FirstOrDefault();

            if (carWithIssue==null)
            {
                return Error($"Car with ID '{carId}' does not exist.");
            }

            return View(carWithIssue);
        }


    }
}
