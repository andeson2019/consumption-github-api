using AutoMapper;
using GithubApi.Models;
using GithubApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace GithubApi.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<OwnerViewModel, Owner>();
            Mapper.CreateMap<ContributorViewModel, Contributor>();
            Mapper.CreateMap<GitHubRepositoryViewModel, GitHubRepository>();
        }
    }
}