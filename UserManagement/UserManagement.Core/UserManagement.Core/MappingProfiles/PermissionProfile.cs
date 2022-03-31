using AutoMapper;

namespace UserManagement.Core.MappingProfiles
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            // To Entity
            CreateMap<Models.Permission, EF.Entities.Permission>();

            // From Entity
            CreateMap<EF.Entities.Permission, Models.Permission>();
        }
    }
}