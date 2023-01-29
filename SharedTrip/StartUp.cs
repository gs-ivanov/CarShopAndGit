namespace SharedTrip
{
    using SharedTrip.Services;
    using MyWebServer;
    using MyWebServer.Controllers;
    using System.Threading.Tasks;
    using MyWebServer.Results.Views;
    using SharedTrip.Data;
    using Microsoft.EntityFrameworkCore;

    public class Startup
    {
        public static async Task Main()
      => await HttpServer
          .WithRoutes(routes => routes
              .MapStaticFiles()
              .MapControllers())
          .WithServices(services => services
              .Add<IViewEngine, CompilationViewEngine>()     //ParserViewEngine  //ParserViewEngine
              .Add<IValidator, Valdator>()
              .Add<IPasswordHasher, PasswordHasher>()
              .Add<SharedtripDbContext>())
          .WithConfiguration<SharedtripDbContext>(context => context
              .Database.Migrate())
          .Start();
    }
}
