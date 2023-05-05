using AdvoSecure.Application.Interfaces;
using AdvoSecure.Common;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvoSecure.Infrastructure.Services
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
