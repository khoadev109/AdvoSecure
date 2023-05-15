using AdvoSecure.Common;
using AdvoSecure.Domain.Interfaces;
using AutoMapper;

namespace AdvoSecure.Application.Services
{
    public class TaskService : ServiceBase
    {
        private readonly IMapper _mapper;
        private readonly IAppUnitOfWork _unitOfWork;

        public TaskService(IMapper mapper, IAppUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


    }
}
