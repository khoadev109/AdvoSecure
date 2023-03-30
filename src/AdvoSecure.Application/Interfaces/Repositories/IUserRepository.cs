using AdvoSecure.Application.Dtos;
using AdvoSecure.Domain.Entities;

namespace AdvoSecure.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> Create(UserDto userDto);

        Task<bool> CheckUserExisted(string userIdentifier);
    }
}
