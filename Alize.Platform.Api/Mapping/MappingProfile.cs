using Alize.Platform.Api.Requests.Applications;
using Alize.Platform.Api.Requests.Companies;
using Alize.Platform.Api.Requests.Modules;
using Alize.Platform.Api.Requests.Users;
using Alize.Platform.Api.Responses;
using Alize.Platform.Api.Responses.Applications;
using Alize.Platform.Api.Responses.Assets;
using Alize.Platform.Api.Responses.Blockchains;
using Alize.Platform.Api.Responses.Companies;
using Alize.Platform.Api.Responses.Modules;
using Alize.Platform.Api.Responses.Roles;
using Alize.Platform.Api.Responses.Templates;
using Alize.Platform.Core.Models;
using AutoMapper;

namespace Alize.Platform.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateApplicationRequest, Application>();
            CreateMap<UpdateApplicationRequest, Application>();
            CreateMap<Application, ApplicationResponse>();

            CreateMap<UserUpdateRequest, User>();
            CreateMap<UserCreateRequest, User>()
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.Email))
                //.ForMember(d => d.IsActive, o => o.MapFrom(s => true))
                .ForMember(d => d.EmailConfirmed, o => o.MapFrom(s => true));
            CreateMap<User, UserResponse>()
                .ForMember(d => d.CompanyName, o => o.MapFrom(s => s.Company != null ? s.Company.Name :  string.Empty))
                .ForMember(d => d.CompanyLogo, o => o.MapFrom(s => s.Company != null ? s.Company.Logo : string.Empty))
                .ForMember(d => d.RoleName, o => o.MapFrom(s => s.Role != null ? s.Role.Name : string.Empty))
                .ForMember(d => d.Modules, o => o.MapFrom(s => s.Role != null ? s.Role.Modules : Enumerable.Empty<Module>()));

            CreateMap<CreateModuleRequest, Module>();
            CreateMap<UpdateModuleRequest, Module>();
            CreateMap<Module, ModuleResponse>();

            CreateMap<CreateCompanyRequest, Company>();
            CreateMap<UpdateCompanyRequest, Company>();
            CreateMap<Company, CompanyResponse>();

            CreateMap<Role, RoleResponse>();

            CreateMap<Blockchain, BlockchainResponse>();

            CreateMap<Asset, AssetResponse>();
            CreateMap<AssetsPage, AssetsPageResponse>();

            CreateMap<TemplateField, TemplateFieldResponse>();
            CreateMap<TemplateColumn, TemplateColumnResponse>();
            CreateMap<ApplicationTemplate, ApplicationTemplateResponse>();
            CreateMap<ApplicationAssetTemplate, ApplicationAssetTemplateResponse>();
        }
    }
}
