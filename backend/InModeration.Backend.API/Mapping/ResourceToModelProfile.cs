using AutoMapper;
using InModeration.Backend.API.Models;
using InModeration.Backend.API.Resources;

namespace InModeration.Backend.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveSiteResource, Site>();
            CreateMap<SaveSiteRuleResource, SiteRule>();
        }
    }
}
