using AdvoSecure.Application.Dtos.Notes;
using AdvoSecure.Application.Interfaces;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Common;
using AdvoSecure.Domain.Entities.Notes;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdvoSecure.Infrastructure.Services
{
    public class NoteService : ServiceBase, INoteService
    {
        private readonly IMapper _mapper;
        private readonly IAppUnitOfWork _unitOfWork;

        public NoteService(IMapper mapper, IAppUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResult<IEnumerable<NoteDto>>> GetNotesByMatterIdAsync(string matterId)
        {
            ServiceResult<IEnumerable<NoteDto>> result = await ExecuteAsync<IEnumerable<NoteDto>>(async () =>
            {
                _ = Guid.TryParse(matterId, out Guid parsedMatterId);

                IEnumerable<Note> notes = await _unitOfWork.NoteRepository.GetQueryable().Include(x => x.NoteMatters).Where(x => x.NoteMatters.Any(y => y.MatterId == parsedMatterId)).ToListAsync();

                IEnumerable<NoteDto> noteDtos = _mapper.Map<IEnumerable<NoteDto>>(notes);

                return new ServiceSuccessResult<IEnumerable<NoteDto>>(noteDtos);
            });

            return result;
        }
    }
}
