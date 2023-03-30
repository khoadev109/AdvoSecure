using AdvoSecure.Application.Dtos;

namespace AdvoSecure.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto> CreateUser(UserDto userDto);
    }
}
