using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GithubApi.Models
{
    public class Contributor
    {
        public string ID { get; set; }

        public string Login { get; set; }

        public int Contributions { get; set; }

        public string html_url { get; set; }
    }
}