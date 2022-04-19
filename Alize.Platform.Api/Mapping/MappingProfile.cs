using Alize.Platform.Api.Requests.Applications;
using Alize.Platform.Api.Requests.Users;
using Alize.Platform.Api.Responses;
using Alize.Platform.Api.Responses.Applications;
using Alize.Platform.Data.Models;
using AutoMapper;

namespace Alize.Platform.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateApplicationRequest, Application>();
            CreateMap<Application, ApplicationResponse>();

            CreateMap<RegisterRequest, User>()
                .ForMember(d => d.IsActive, o => o.MapFrom(s => true))
                .ForMember(d => d.EmailConfirmed, o => o.MapFrom(s => true));

            CreateMap<User, UserResponse>();
        }
    }
}
