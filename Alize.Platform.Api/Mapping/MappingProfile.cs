using Alize.Platform.Api.Requests.Applications;
using Alize.Platform.Api.Requests.Assets;
using Alize.Platform.Api.Requests.Companies;
using Alize.Platform.Api.Requests.Modules;
using Alize.Platform.Api.Requests.Templates;
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
            ApplicationMappings();
            UserMappings();
            ModuleMappings();
            CompanyMappings();
            RoleMappings();
            BlockchainMappings();
            AssetMappings();
            TemplateMappings();
        }

        private void BlockchainMappings()
        {
            CreateMap<Blockchain, BlockchainResponse>();
        }

        private void RoleMappings()
        {
            CreateMap<Role, RoleResponse>();
        }

        private void CompanyMappings()
        {
            CreateMap<CreateCompanyRequest, Company>();
            CreateMap<UpdateCompanyRequest, Company>();
            CreateMap<Company, CompanyResponse>();
        }

        private void ModuleMappings()
        {
            CreateMap<CreateModuleRequest, Module>();
            CreateMap<UpdateModuleRequest, Module>();
            CreateMap<Module, ModuleResponse>();
        }

        private void ApplicationMappings()
        {
            CreateMap<CreateApplicationRequest, Application>();
            CreateMap<UpdateApplicationRequest, Application>();
            CreateMap<Application, ApplicationResponse>()
                .ForMember(d => d.CompanyName, o => o.MapFrom(s => s.Company != null ? s.Company.Name : string.Empty));
        }

        private void UserMappings()
        {
            CreateMap<UserUpdateRequest, User>();
            CreateMap<UserCreateRequest, User>()
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.Email))
                //.ForMember(d => d.IsActive, o => o.MapFrom(s => true))
                .ForMember(d => d.EmailConfirmed, o => o.MapFrom(s => true));
            CreateMap<User, UserResponse>()
                .ForMember(d => d.RoleId, o => o.MapFrom(s => s.Role != null ? s.Role.Id : default))
                .ForMember(d => d.CompanyName, o => o.MapFrom(s => s.Company != null ? s.Company.Name : string.Empty))
                .ForMember(d => d.CompanyLogo, o => o.MapFrom(s => s.Company != null ? s.Company.Logo : string.Empty))
                .ForMember(d => d.RoleName, o => o.MapFrom(s => s.Role != null ? s.Role.Name : string.Empty))
                .ForMember(d => d.Modules, o => o.MapFrom(s => s.Role != null ? s.Role.Modules : Enumerable.Empty<Module>()));
        }

        private void AssetMappings()
        {
            CreateMap<Asset, AssetResponse>();
            CreateMap<AssetsPage, AssetsPageResponse>();
            CreateMap<AssetHistory, AssetHistoryResponse>();
            CreateMap<CreateAssetRequest, Asset>();
        }

        private void TemplateMappings()
        {
            CreateMap<TemplateField, TemplateFieldResponse>();
            CreateMap<TemplateColumn, TemplateColumnResponse>();
            CreateMap<ApplicationTemplate, ApplicationTemplateResponse>();
            CreateMap<AssetTemplate, AssetTemplateResponse>();
            CreateMap<TemplateStep, TemplateStepResponse>();
            CreateMap<CreateTemplateColumnRequest, TemplateColumn>();
            CreateMap<CreateTemplateRequest, ApplicationTemplate>();
            CreateMap<CreateTemplateFieldRequest, TemplateField>();
            CreateMap<CreateAssetTemplateRequest, AssetTemplate>();
            CreateMap<CreateTemplateStepRequest, TemplateStep>();
        }
    }
}
