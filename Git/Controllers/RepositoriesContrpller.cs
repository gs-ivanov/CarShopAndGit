namespace Git.Controllers
{
    using Git.Data;
    using Git.Models.Repositories;
    using Git.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class RepositoriesController : Controller
    {
        private readonly GitDbContext data;
        private readonly IValidator validator;

        public RepositoriesController(GitDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        public HttpResponse All(RepositoryListingViewModel model)
        {
            var repositoriesQuery = this.data
                .Repositories
                .AsQueryable();

            if (this.User.IsAuthenticated)
            {
                repositoriesQuery = repositoriesQuery
                   .Where(r => r.IsPublic || r.OwnerId == this.User.Id);
            }
            else
            {
                repositoriesQuery = repositoriesQuery
                    .Where(r => r.IsPublic);
            }

            var repositories = repositoriesQuery
                .OrderByDescending(r => r.CreatedOn)
                .Select(r => new RepositoryListingViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Owner = r.Owner.Username,
                    CreatedOn = r.CreatedOn.ToLocalTime().ToString("f"),
                    Commits = r.Commits.Count()
                })
                .ToList();

            return View(repositories);
        }
    }
}