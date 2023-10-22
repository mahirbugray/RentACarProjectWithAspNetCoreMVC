using AutoMapper;
using BAU_Project_RentACarPortal.App.Entity.Entities;
using BAU_Project_RentACarPortal.App.Entity.IUnitOfWorks;
using BAU_Project_RentACarPortal.App.Entity.Services;
using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Service.Services
{
    public class ArabaService : IArabaService
    {
        private readonly IUnitOfWorks _uow;
        private readonly IMapper _mapper;

        public ArabaService(IUnitOfWorks uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ArabaViewModel>> GetAll()
        {
            var list = await _uow.GetRepository<Araba>().GetAllAsync();

            return _mapper.Map<List<ArabaViewModel>>(list);
        }
        public void Update(ArabaViewModel model) 
        {
            _uow.GetRepository<Araba>().Update(_mapper.Map<Araba>(model));
            _uow.Commit();
        }
        public async Task UpdateAdmin(int HasarDurumu, int Id)
        {
            var araba = await _uow.GetRepository<Araba>().Get(x => x.Id == Id);
            araba.HasarDurumu = HasarDurumu;
            araba.IsAvailable = true;
            _uow.GetRepository<Araba>().Update(araba);
            await _uow.CommitAsync();
        }
        public async Task<ArabaViewModel> Get(int id)
        {
            var araba = await _uow.GetRepository<Araba>().Get(x => x.Id == id);
            return _mapper.Map<ArabaViewModel>(araba);
        }

        public async Task<ArabaViewModel> GetById(int id)
        {
            Araba araba = await _uow.GetRepository<Araba>().Get(x => x.Id == id, null, x => x.ArabaKategori, x => x.Firma, x => x.Sigorta);
            return _mapper.Map<ArabaViewModel>(araba);
        }
        public List<ArabaViewModel> GetAllDetay()
        {
            var list = _uow.GetRepository<Araba>().GetAllDetay();
            return _mapper.Map<List<ArabaViewModel>>(list);
        }

        public async Task<IEnumerable<ArabaViewModel>> GetAllArabaWithFilterKategori(int id)
        {
            IEnumerable<Araba> list = await _uow.GetRepository<Araba>().GetAll(x => x.ArabaKategoriId == id);
            return _mapper.Map<IEnumerable<ArabaViewModel>>(list);
        }

        public async Task<IEnumerable<ArabaViewModel>> GetAllWithFiltered(Expression<Func<Araba, bool>> filter = null, params Expression<Func<Araba, object>>[] includes)
        {
            var list = await _uow.GetRepository<Araba>().GetAll(filter, null, includes);
            return _mapper.Map<List<ArabaViewModel>>(list);
        }

        public async Task Add(ArabaViewModel model)
        {
            await _uow.GetRepository<Araba>().Add(_mapper.Map<Araba>(model));
            _uow.Commit();
        }

        public void Edit(ArabaViewModel model)
        {
            _uow.GetRepository<Araba>().Update(_mapper.Map<Araba>(model));
            _uow.Commit();
        }

        public void Delete(int id)
        {
            _uow.GetRepository<Araba>().DeleteById(id);
            _uow.Commit();
        }

        public async Task<int> LastCar()
        {
            IEnumerable<Araba> list = await _uow.GetRepository<Araba>().GetAll();
            return list.Max(x => x.Id);
        }

        public async Task<List<ArabaViewModel>> GetAllArabaAdmin()
        {
            var araba = await _uow.GetRepository<Araba>().GetAll(x => x.IsAvailable == false);
            return _mapper.Map<List<ArabaViewModel>>(araba);
        }
    }
}
