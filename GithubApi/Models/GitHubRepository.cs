using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GithubApi.Models
{
    public class GitHubRepository
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Full_Name { get; set; }

        public string Description { get; set; }

        public DateTime? Updated_at { get; set; }

        public Owner Owner { get; set; }

        public string Language { get; set; }

        public string Html_url { get; set; }

        public Contributor Contributor { get; set; }
    }
}