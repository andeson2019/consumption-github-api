using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using GithubApi.Interfaces.Repositories;
using GithubApi.Interfaces.Services;
using GithubApi.Models;
using Newtonsoft.Json;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace GithubApi.Services
{
    public class GitHubApiService : IGitHubApiService
    {
        private readonly IRepository repository;

        private string UrlBase => "https://api.github.com";
        private string DefaultUser => "andeson2019";
        private string Passw => "1q2w3e!Q@W#E047327";

        
        public GitHubApiService(IRepository _repo)
        {
            repository = _repo;
        }

        public ICollection<GitHubRepository> GetFavorites()
        {
            return repository.GetFavorite();
        }

        public GitHubRepository GetGitHubRepositoryBySearch(string search)
        {

            GitHubRepository repository = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UrlBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("User-Agent", "Andeson-Morais");
                client.DefaultRequestHeaders.Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization =
                     new AuthenticationHeaderValue("Basic", Convert.ToBase64String(
                     System.Text.ASCIIEncoding.ASCII.GetBytes($"{DefaultUser}:{Passw}")));

                var response = client.GetAsync($"{ UrlBase}/repos/{DefaultUser}/{search}").Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    repository = JsonConvert.DeserializeObject<GitHubRepository>(responseString);
                }
            }

            return repository;
        }

        public ICollection<GitHubRepository> GetGitHubRepositories()
        {
            ICollection<GitHubRepository> repositories = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UrlBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("User-Agent", "Andeson-Morais");
                client.DefaultRequestHeaders.Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization =
                     new AuthenticationHeaderValue("Basic", Convert.ToBase64String(
                     System.Text.ASCIIEncoding.ASCII.GetBytes($"{DefaultUser}:{Passw}")));

                HttpResponseMessage response = client
                    .GetAsync($"{ UrlBase}/users/{DefaultUser}/repos").Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    repositories = JsonConvert
                        .DeserializeObject<ICollection<GitHubRepository>>(responseString);
                }

            }
            return repositories;
        }

        public ICollection<GitHubRepository> SetFavorite(string name)
        {

            GitHubRepository repo = GetGitHubRepositoryBySearch(name);
            ICollection<GitHubRepository> repositories = GetFavorites();
            bool exists = false;

            if (repositories != null)
            {
                foreach (var item in repositories)
                {
                    if (item.Name.Equals(name)) {
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                {
                    repositories.Add(repo);
                    repository.SetFavorite(repositories);
                }
            }
            else
            {
                repositories = new List<GitHubRepository>();
                repositories.Add(repo);
                repository.SetFavorite(repositories);
            }

            return repositories;
        }

        public ICollection<GitHubRepository> GetGitHubRepositoriesBySearch(string search)
        {
            ICollection<GitHubRepository> repositories = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UrlBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("User-Agent", "Andeson-Morais");
                client.DefaultRequestHeaders.Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization =
                     new AuthenticationHeaderValue("Basic", Convert.ToBase64String(
                     System.Text.ASCIIEncoding.ASCII.GetBytes($"{DefaultUser}:{Passw}")));

                HttpResponseMessage response = client
                    .GetAsync($"{ UrlBase}/search/repositories?q={search}").Result;

                if (response.IsSuccessStatusCode)
                {
                   
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    var result = JObject.Parse(responseString);
                    var items = result["items"].Children().ToList();

                    IList<GitHubRepository> searchResults = new List<GitHubRepository>();
                    foreach (JToken item in items)
                    {
                        GitHubRepository searchResult = item.ToObject<GitHubRepository>();
                        searchResults.Add(searchResult);
                    }

                    repositories = searchResults;
                }

            }
            return repositories;
        }
    }
}