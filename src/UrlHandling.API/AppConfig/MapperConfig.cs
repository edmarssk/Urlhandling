using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlHandling.API.ViewModel;
using UrlHandling.Business.Models;

namespace UrlHandling.API.AppConfig
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<UrlLink, UrlLinkResponse>().ReverseMap();

        }
    }
}