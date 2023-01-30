namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SharedTrip.Data;
    using SharedTrip.Data.Models;
    using SharedTrip.Models.Trips;
    using SharedTrip.Services;
    public class TripsController : Controller
    {
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;
        private readonly SharedtripDbContext data;

        public TripsController(
            IValidator validator,
            IPasswordHasher passwordHasher,
            SharedtripDbContext data)
        {
            this.validator = validator;
            this.passwordHasher = passwordHasher;
            this.data = data;
        }

        public HttpResponse All()
        {
            return View();

            //return Redirect("Trips/All");
        }

        //[HttpPost]
        //public HttpResponse All(RegisterUserFormModel model)
        //{

        //}

        public HttpResponse Details(string tripId)
        {
            return View();
        }
        public HttpResponse Add()
        {
            return View();
        }
        [HttpPost]
        //[Authorize]
        public HttpResponse Add(AddTripViewModel model)
        {
            var modelErrors = this.validator.ValidateTrip(model);

            if (modelErrors==null)
            {
                return Error(modelErrors);
            }
            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                //DepartureTime=model.DepartureTime,
                ImagePath = model.ImagePath,
                Searts = model.Seats,
                Description = model.Description

            };

            if (trip==null)
            {
                return NotFound();
            }

            this.data.Trip.Add(trip);

            this.data.SaveChanges();


            return View();
        }
    }
}
