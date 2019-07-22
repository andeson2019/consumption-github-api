using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using GithubApi.Interfaces.Repositories;
using GithubApi.Models;
using Newtonsoft.Json;

namespace GithubApi.Data.Repository
{
    public class Repository : IRepository
    {
        static string favoritesFile = HttpContext.Current.Server.MapPath("~/Files/Favorites.txt");

        public ICollection<GitHubRepository> GetFavorite()
        {
            ICollection<GitHubRepository> favorites;

            using (StreamReader file = File.OpenText(favoritesFile))
            {
                JsonSerializer serializer = new JsonSerializer();
                favorites = (ICollection<GitHubRepository>)serializer
                    .Deserialize(file, typeof(ICollection<GitHubRepository>));
            }

            return favorites;
        }

        public void SetFavorite(ICollection<GitHubRepository> favorite)
        {
            using (StreamWriter file = File.CreateText(favoritesFile))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, favorite);
            }
        }
    }
}