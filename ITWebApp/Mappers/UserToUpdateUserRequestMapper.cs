using Auth0.ManagementApi.Models;
using AutoMapper;

namespace ITWebApp.Mappers
{
    public interface IUserToUpdateUserRequestMapper
    {
        UserUpdateRequest Map(User user);
    }

    public class UserToUpdateUserRequestMapper : IUserToUpdateUserRequestMapper
    {
        private static IMapper _mapper;
        public UserToUpdateUserRequestMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public UserUpdateRequest Map(User user)
        {
            return null;
        }
    }
}
