using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Entities.Matters;
using AdvoSecure.Domain.Interfaces.Repositories;
using AdvoSecure.Domain.Interfaces.Requests;
using AdvoSecure.Infrastructure.Persistance.App;
using Microsoft.EntityFrameworkCore;

namespace AdvoSecure.Infrastructure.Persistance.Application.Repositories
{
    public class MatterRepository : Repository<Matter>, IMatterRepository
    {
        public MatterRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Matter> GetByIdAsync(Guid id)
        {
            Matter matter = await GetQueryable()
                .Include(x => x.BillingGroup)
                .Include(x => x.DefaultBillingRate)
                .Include(x => x.BillToContact)
                .Include(x => x.MatterType)
                .Include(x => x.MatterArea)
                .Include(x => x.CourtSittingInCity)
                .Include(x => x.CourtGeoJurisdiction)
                .FirstOrDefaultAsync(x => x.Id == id) ?? new Matter();

            return matter;
        }

        public async Task<long> GetLatestSequenceAsync()
        {
            Matter lastMatter = await GetQueryable().OrderByDescending(x => x.IdInt).FirstOrDefaultAsync();

            long sequence = (lastMatter?.IdInt ?? 0) + 1;

            return sequence;
        }

        public async Task<IEnumerable<Matter>> SearchAsync(MatterSearchRequest request)
        {
            IQueryable<Matter> matters = GetQueryable().Include(x => x.BillToContact).Include(x => x.MatterArea);

            if (!string.IsNullOrWhiteSpace(request.Status))
            {
                bool? active = GetActiveStatus(request.Status);

                matters = matters.Where(x => x.Active == active);
            }

            if (!string.IsNullOrWhiteSpace(request.ContactName))
            {
                matters = matters.Where(x => x.BillToContact.DisplayName.Contains(request.ContactName));
            }

            if (!string.IsNullOrWhiteSpace(request.Description))
            {
                matters = matters.Where(x => x.Title.Contains(request.Description));
            }

            if (!string.IsNullOrWhiteSpace(request.CaseNumber))
            {
                matters = matters.Where(x => x.CaseNumber.Contains(request.CaseNumber));
            }

            if (request.MatterAreaId.HasValue && request.MatterAreaId.Value > 0)
            {
                matters = matters.Where(x => x.MatterAreaId == request.MatterAreaId.Value);
            }

            if (request.CourtGeographicalJurisdictionId.HasValue && request.CourtGeographicalJurisdictionId.Value > 0)
            {
                matters = matters.Where(x => x.CourtGeoJurisdictionId == request.CourtGeographicalJurisdictionId.Value);
            }

            IList<Matter> atters = await matters.ToListAsync();

            return matters;
        }

        public async Task<Matter> CreateAsync(Matter matter, string userName)
        {
            matter.CreatedBy = userName;

            foreach (var matterContact in matter.MatterContacts)
            {
                matterContact.CreatedBy = userName;
            }

            Matter result = await AddAsync(matter);

            return result;
        }

        public Matter Update(Matter matter, string userName)
        {
            matter.ModifiedBy = userName;

            Matter result = Update(matter);

            return result;
        }

        private bool? GetActiveStatus(string status)
        {
            return status switch
            {
                "inactive" => false,
                "both" => null,
                _ => true,
            };
        }
    }
}
