using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GithubApi.Models
{
    public class Owner
    {
        public string login { get; set; }

        public string url { get; set; }

        public string avatar_url { get; set; }

        public string repos_url { get; set; }

        public string followers_url { get; set; }

        public string following_url { get; set; }
    }
}