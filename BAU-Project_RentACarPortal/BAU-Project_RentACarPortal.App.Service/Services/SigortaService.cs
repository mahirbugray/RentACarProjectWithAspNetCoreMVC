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
    public class SigortaService : ISigortaService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorks _uow;

        public SigortaService(IUnitOfWorks uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task Add(SigortaViewModel model)
        {
            await _uow.GetRepository<Sigorta>().Add(_mapper.Map<Sigorta>(model));
            _uow.Commit();
        }

        public void Delete(int id)
        {
            _uow.GetRepository<Sigorta>().DeleteById(id);
            _uow.Commit();
        }

        public void Edit(SigortaViewModel model)
        {
            _uow.GetRepository<Sigorta>().Update(_mapper.Map<Sigorta>(model));
            _uow.Commit();
        }

        public async Task<List<SigortaViewModel>> GetAllSigortaAsync()
        {
            var list = await _uow.GetRepository<Sigorta>().GetAllAsync();
            return _mapper.Map<List<SigortaViewModel>>(list);
        }

        public SigortaViewModel GetById(int id)
        {
            var sigorta = _uow.GetRepository<Sigorta>().GetByIdNoAsync(id);
            return _mapper.Map<SigortaViewModel>(sigorta);
        }
    }
}
