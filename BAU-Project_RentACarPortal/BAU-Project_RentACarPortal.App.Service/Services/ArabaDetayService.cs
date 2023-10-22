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
    public class ArabaDetayService : IArabaDetayService
    {
        private readonly IUnitOfWorks _uow;
        private readonly IMapper _mapper;

        public ArabaDetayService(IMapper mapper, IUnitOfWorks uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task Add(ArabaDetayViewModel model)
        {
            await _uow.GetRepository<ArabaDetay>().Add(_mapper.Map<ArabaDetay>(model));
            _uow.Commit();
        }

        public async Task<ArabaDetayViewModel> Get(int id)
        {
            var arabaDetay = await _uow.GetRepository<ArabaDetay>().GetById(id);
            return _mapper.Map<ArabaDetayViewModel>(arabaDetay);
        }

        public async Task<IEnumerable<ArabaDetayViewModel>> GetAll()
        {
            var list = await _uow.GetRepository<ArabaDetay>().GetAllAsync();
            return _mapper.Map<List<ArabaDetayViewModel>>(list);
        }

        public List<ArabaDetayViewModel> GetAllDetay()
        {
            var list = _uow.GetRepository<ArabaDetay>().GetAllDetay();
            return _mapper.Map<List<ArabaDetayViewModel>>(list);


        }

        public async Task<List<ArabaDetayViewModel>> GetByArabaFiltre(int id)
        {
            var list = await _uow.GetRepository<ArabaDetay>().GetAll();
            return _mapper.Map<List<ArabaDetayViewModel>>(list);
        }

        public ArabaDetayViewModel GetById(int id)
        {
            var list = _uow.GetRepository<ArabaDetay>().GetNoAsync(x => x.ArabaId == id);
            return _mapper.Map<ArabaDetayViewModel>(list);
        }

    }
}
