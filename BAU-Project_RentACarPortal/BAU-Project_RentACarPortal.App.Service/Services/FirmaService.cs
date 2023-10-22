using AutoMapper;
using BAU_Project_RentACarPortal.App.Entity.Entities;
using BAU_Project_RentACarPortal.App.Entity.IUnitOfWorks;
using BAU_Project_RentACarPortal.App.Entity.Services;
using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Service.Services
{
    public class FirmaService : IFirmaService
    {
        private readonly IUnitOfWorks _uow;
        private readonly IMapper _mapper;

        public FirmaService(IUnitOfWorks uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Add(FirmaViewModel model)
        {
            await _uow.GetRepository<Firma>().Add(_mapper.Map<Firma>(model));
            _uow.Commit();
        }

        public void Edit(FirmaViewModel model)
        {
            _uow.GetRepository<Firma>().Update(_mapper.Map<Firma>(model));
            _uow.Commit();
        }

        public void Delete(int id) 
        {
            _uow.GetRepository<Firma>().DeleteById(id);
            _uow.Commit();
        }

        public async Task<List<FirmaViewModel>> GetAllFirmaAsync()
        {
            var list = await _uow.GetRepository<Firma>().GetAll();
            return _mapper.Map<List<FirmaViewModel>>(list);
        }

        public FirmaViewModel GetById(int id)
        {
            var firma = _uow.GetRepository<Firma>().GetByIdNoAsync(id);
            return _mapper.Map<FirmaViewModel>(firma);
        }
    }
}
