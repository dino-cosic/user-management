using AutoMapper;

namespace UserManagement.Core.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // DTO to Entity
            CreateMap<Models.User, EF.Entities.User>();

            // Entity to DTO
            CreateMap<EF.Entities.User, Models.User>();
        }
    }
}