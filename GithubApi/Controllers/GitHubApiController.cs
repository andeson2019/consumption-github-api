using GithubApi.Interfaces.Services;
using GithubApi.Models;
using GithubApi.ViewModels;
using System.Collections.Generic;
using AutoMapper;
using System.Web.Mvc;


namespace GithubApi.Controllers
{
    public class GitHubApiController : Controller
    {
        private readonly IGitHubApiService service;

        public GitHubApiController(IGitHubApiService _service)
        {
            service = _service;
        }

        // GET: GitHubApi
        public ActionResult Index()
        {
            ICollection<GitHubRepository> list = service.GetGitHubRepositories();
            var listVM = Mapper.Map<ICollection<GitHubRepository>,
                ICollection<GitHubRepositoryViewModel>>(list);

            return View("ListGitHubRepositories", listVM);
        }

        // GET: GitHubApi/Details/id
        public ActionResult Details(string id)
        {
            GitHubRepository item = service.GetGitHubRepositoryBySearch(id);
            var itemVM = Mapper.Map<GitHubRepository,
                 GitHubRepositoryViewModel>(item);

            return View("DetailGitHubRepository", itemVM);
        }

        [HttpGet]
        [Route("GitHubApi/Favorite")]
        public ActionResult Favorite()
        {
            ICollection<GitHubRepository> list = service.GetFavorites();
            var listVM = Mapper.Map<ICollection<GitHubRepository>,
                ICollection<GitHubRepositoryViewModel>>(list);

            return View("FavoriteGitHubRepositories", listVM);
        }

        [HttpGet]
        [Route("GitHubApi/TurnFavorite")]
        public ActionResult TurnFavorite(string id)
        {
            ICollection<GitHubRepository> list = service.SetFavorite(id);
            var listVM = Mapper.Map<ICollection<GitHubRepository>,
                ICollection<GitHubRepositoryViewModel>>(list);
            
            return View("FavoriteGitHubRepositories", listVM);
        }

        [HttpGet]
        [Route("GitHubApi/Search")]
        public ActionResult Search()
        {
            return View("SearchGitHubRepository");
        }

        [HttpPost]
        [Route("GitHubApi/Search")]
        public ActionResult Search(string id)
        {
            ICollection<GitHubRepository> list = service.GetGitHubRepositoriesBySearch(id);
            var itemVM = Mapper.Map<ICollection<GitHubRepository>,
                 ICollection<GitHubRepositoryViewModel>>(list);

            return View("SearchGitHubRepository", itemVM);
        }

    }
}
