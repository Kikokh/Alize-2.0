using Alize.Platform.Api.Requests.Applications;
using Alize.Platform.Api.Requests.Companies;
using Alize.Platform.Api.Requests.Modules;
using Alize.Platform.Api.Requests.Users;
using Alize.Platform.Api.Responses;
using Alize.Platform.Api.Responses.Applications;
using Alize.Platform.Api.Responses.Companies;
using Alize.Platform.Api.Responses.Modules;
using Alize.Platform.Api.Responses.Roles;
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

            CreateMap<CreateModuleRequest, Module>();
            CreateMap<UpdateModuleRequest, Module>();
            CreateMap<Module, ModuleResponse>();

            CreateMap<CreateCompanyRequest, Company>();
            CreateMap<UpdateCompanyRequest, Company>();
            CreateMap<Company, CompanyResponse>();

            CreateMap<Role, RoleResponse>();
        }
    }
}
