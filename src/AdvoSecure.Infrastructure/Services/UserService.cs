using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Interfaces.Repositories;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Infrastructure.Persistance.Repositories;
using AutoMapper;

namespace AdvoSecure.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> CreateUser(UserDto userDto)
        {
            bool isUserExisted = await _userRepository.CheckUserExisted(userDto.AzureIdentityId);
            if (isUserExisted)
            {
                return new UserDto();
            }

            User createdUser = await _userRepository.Create(userDto);

            UserDto createdUserDto = _mapper.Map<UserDto>(createdUser);

            return createdUserDto;
        }
    }
}
