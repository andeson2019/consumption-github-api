using GithubApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GithubApi.ViewModels
{
    public class RepositoriesDTOViewModel
    {
        [Display(Name = "Repositórios")]
        ICollection<GitHubRepository> items { get; set; }
    }
}