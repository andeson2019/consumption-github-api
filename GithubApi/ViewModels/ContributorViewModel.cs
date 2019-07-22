using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GithubApi.ViewModels
{
    public class ContributorViewModel
    {
        [Display(Name = "ID")]
        public string ID { get; set; }

        [Display(Name = "Login")]
        public string Login { get; set; }

        [Display(Name = "Contribuições")]
        public int Contributions { get; set; }

        [Display(Name = "URL")]
        public string html_url { get; set; }
    }
}