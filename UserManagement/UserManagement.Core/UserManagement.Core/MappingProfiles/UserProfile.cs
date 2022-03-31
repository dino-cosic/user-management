using AutoMapper;

namespace UserManagement.Core.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // To Entity
            CreateMap<Models.User, EF.Entities.User>();

            // From Entity
            CreateMap<EF.Entities.User, Models.User>();
        }
    }
}