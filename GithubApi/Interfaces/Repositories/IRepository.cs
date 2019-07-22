using GithubApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubApi.Interfaces.Repositories
{
    public interface IRepository
    {
        ICollection<GitHubRepository> GetFavorite();

        void SetFavorite(ICollection<GitHubRepository> favorite);

    }
}
