using AutoMapper;
using InModeration.Backend.API.Models;
using InModeration.Backend.API.Resources;

namespace InModeration.Backend.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<SiteRule, SiteRuleResource>();
        }
    }
}
