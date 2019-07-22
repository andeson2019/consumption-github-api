using AutoMapper;
using GithubApi.Models;
using GithubApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GithubApi.AutoMapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Owner, OwnerViewModel>();
            Mapper.CreateMap<Contributor, ContributorViewModel>();
            Mapper.CreateMap<GitHubRepository, GitHubRepositoryViewModel>();
        }
    }
}