using AutoMapper;
using BAU_Project_RentACarPortal.App.Entity.Entities;
using BAU_Project_RentACarPortal.App.Entity.IUnitOfWorks;
using BAU_Project_RentACarPortal.App.Entity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Service.Services
{
    public class TeslimService : ITeslimService
    {
        private readonly IUnitOfWorks _uow;
        private readonly IMapper _mapper;

        public TeslimService(IUnitOfWorks uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public void Add(Teslim teslim)
        {
            _uow.GetRepository<Teslim>().Add(teslim);
            _uow.Commit();
        }
    }
}
