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
    public class DegerlendirmeService : IDegerlendirmeService
    {
        private readonly IUnitOfWorks _uow;
        private readonly IMapper _mapper;

        public DegerlendirmeService(IUnitOfWorks uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task Add(DegerlendirmeViewModel model)
        {
            Degerlendirme degerlendirme = new Degerlendirme();
            degerlendirme = _mapper.Map<Degerlendirme>(model);
            _uow.GetRepository<Degerlendirme>().Add(degerlendirme);
            await _uow.CommitAsync();
        }

        public async Task<List<DegerlendirmeViewModel>> GetAllArabaId(int id)
        {
            var list = await _uow.GetRepository<Degerlendirme>().GetAll(c => c.ArabaId == id);
            return _mapper.Map<List<DegerlendirmeViewModel>>(list);
        }
    }
}
