using AdvoSecure.Application.Dtos.MatterDtos;
using AdvoSecure.Application.Interfaces.Repositories;
using AdvoSecure.Domain.Entities.Contacts;
using AdvoSecure.Domain.Entities.Matters;
using AdvoSecure.Infrastructure.Persistance.App;
using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AdvoSecure.Infrastructure.Persistance.Application.Repositories
{
    public class MatterRepository : IMatterRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public MatterRepository(IMapper mapper, ApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public IQueryable<MatterType> GetMatterTypes()
        {
            return _dbContext.MatterTypes.OrderBy(x => x.Title);
        }

        public IQueryable<MatterArea> GetMatterAreas()
        {
            return _dbContext.MatterAreas.OrderBy(x => x.AreaCode);
        }

        public IQueryable<CourtSittingInCity> GetCourtSittingInCities()
        {
            return _dbContext.CourtSittingInCities.OrderBy(x => x.Title);
        }

        public IQueryable<CourtGeographicalJurisdiction> GetCourtGeographicalJurisdictions()
        {
            return _dbContext.CourtGeographicalJurisdictions.OrderBy(x => x.Title);
        }

        public IQueryable<Matter> GetMatters()
        {
            return _dbContext.Matters;
        }

        public async Task<Matter> Create(Matter matter, string userEmail)
        {
            try
            {
                matter.CreatedBy = userEmail;

                EntityEntry<Matter> result = await _dbContext.Matters.AddAsync(matter);

                await _dbContext.SaveChangesAsync();

                Matter createdMatter = result.Entity;

                return createdMatter;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Matter> Update(MatterDto matterDto, string userEmail)
        {
            Matter existingMatter = await _dbContext.Matters.FindAsync(matterDto.Id);
            existingMatter.CreatedBy = userEmail;

            existingMatter = _mapper.Map(matterDto, existingMatter);

            EntityEntry<Matter> result = _dbContext.Update<Matter>(existingMatter);

            await _dbContext.SaveChangesAsync();

            Matter updatedMatter = result.Entity;

            return updatedMatter;
        }
    }
}
