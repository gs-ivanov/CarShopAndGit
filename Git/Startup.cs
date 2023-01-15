namespace Git
{
    using Git.Data;
    using Microsoft.EntityFrameworkCore;
    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using System.Threading.Tasks;

    class Startup
    {
        public static async Task Main()
            => await HttpServer
         .WithRoutes(routes => routes
             .MapStaticFiles()
             .MapControllers())
         .WithServices(services => services
             .Add<IViewEngine, CompilationViewEngine>()     //ParserViewEngine  //ParserViewEngine
             .Add<GitDbContext>())
         .WithConfiguration<GitDbContext>(context => context
             .Database.Migrate())
         .Start();

    }
}

