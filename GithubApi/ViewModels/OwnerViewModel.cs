using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GithubApi.ViewModels
{
    public class OwnerViewModel
    {
        [Display(Name = "Login")]
        public string login { get; set; }

        [Display(Name = "URL")]
        public string url { get; set; }

        [Display(Name = "URL Avatar")]
        public string avatar_url { get; set; }

        [Display(Name = "Repositórios")]
        public string repos_url { get; set; }

        [Display(Name = "Seguidores")]
        public string followers_ulr { get; set; }

        [Display(Name = "Seguindo")]
        public string following_url { get; set; }
    }
}