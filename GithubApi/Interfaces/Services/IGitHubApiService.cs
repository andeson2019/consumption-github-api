using GithubApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubApi.Interfaces.Services
{
    public interface IGitHubApiService
    {
        ICollection<GitHubRepository> GetGitHubRepositories();

        GitHubRepository GetGitHubRepositoryBySearch(string search);

        ICollection<GitHubRepository> GetGitHubRepositoriesBySearch(string search);

        ICollection<GitHubRepository> GetFavorites();

        ICollection<GitHubRepository> SetFavorite(string favorites);
    }
}
