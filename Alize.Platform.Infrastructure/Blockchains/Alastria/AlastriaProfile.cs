using Alize.Platform.Core.Models;
using Alize.Platform.Infrastructure.Alastria.Models;
using AutoMapper;

namespace Alize.Platform.Infrastructure.Alastria
{
    public class AlastriaMappingProfile : Profile
    {
        public AlastriaMappingProfile()
        {
            CreateMap<AlastriaAsset, Asset>()
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => s.Data.ContainsKey("createdAt") ? s.Data["createdAt"] : null));

            CreateMap<AlastriaAssetHistory, AssetHistory>()
                .ForMember(d => d.TransactionId, o => o.MapFrom(s => s.TransacctionHash));

            CreateMap<Application, AlastriaApplication>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.AdminUser, o => o.MapFrom(s => "admin"))
                .ForMember(d => d.ApplicationName, o => o.MapFrom(s => s.Name.ToLower().Replace(" ", "_")))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Company != null ? s.Company.Email : string.Empty));
        }
    }
}
