using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using GithubApi.Models;

namespace GithubApi.ViewModels
{
    public class GitHubRepositoryViewModel
    {
        [Display(Name = "ID")]
        public string ID { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Nome Completo")]
        public string Full_Name { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Atualizado em")]
        public DateTime? Updated_at { get; set; }

        [Display(Name = "Dono")]
        public OwnerViewModel Owner { get; set; }

        [Display(Name = "Linguagem")]
        public string Language { get; set; }

        [Display(Name = "URL")]
        public string Html_url { get; set; }

        [Display(Name = "Contribuidor(es)")]
        public ContributorViewModel Contributor { get; set; }
    }
}