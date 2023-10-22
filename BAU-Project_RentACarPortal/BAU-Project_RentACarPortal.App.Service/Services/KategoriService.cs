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
    public class KategoriService : IKategoriService
    {
        private readonly IUnitOfWorks _uow;
        private readonly IMapper _mapper;

        public KategoriService(IMapper mapper, IUnitOfWorks uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task Add(KategoriViewModel model)
        {
            await _uow.GetRepository<ArabaKategori>().Add(_mapper.Map<ArabaKategori>(model));
            _uow.Commit();
        }

        public void Delete(int id)
        {
            _uow.GetRepository<ArabaKategori>().DeleteById(id);
            _uow.Commit();
        }

        public void Edit(KategoriViewModel model)
        {
            _uow.GetRepository<ArabaKategori>().Update(_mapper.Map<ArabaKategori>(model));
            _uow.Commit();
        }

        public async Task<List<KategoriViewModel>> GetAllKategoriAsync()
        {
            var list = await _uow.GetRepository<ArabaKategori>().GetAllAsync();
            return _mapper.Map<List<KategoriViewModel>>(list.ToList());
        }

        public KategoriViewModel GetById(int id)
        {
            var kategori = _uow.GetRepository<ArabaKategori>().GetByIdNoAsync(id);
            return _mapper.Map<KategoriViewModel>(kategori);
        }
    }
}
