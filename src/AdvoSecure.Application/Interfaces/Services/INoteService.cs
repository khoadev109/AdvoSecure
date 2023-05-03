using AdvoSecure.Application.Dtos.Notes;
using AdvoSecure.Common;

namespace AdvoSecure.Application.Interfaces.Services
{
    public interface INoteService
    {
        Task<ServiceResult<IEnumerable<NoteDto>>> GetNotesByMatterIdAsync(string matterId);
    }
}
