using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Interfaces.Repositories;
using AdvoSecure.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AdvoSecure.Infrastructure.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<User> Create(UserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);

            EntityEntry<User> createdUser = await _dbContext.Users.AddAsync(user);

            await _dbContext.SaveChangesAsync();

            return createdUser.Entity;
        }

        public async Task<bool> CheckUserExisted(string userIdentifier)
        {
            bool isExisted = await _dbContext.Users.AnyAsync(u => u.AzureIdentityId == userIdentifier);
            return isExisted;
        }
    }
}
