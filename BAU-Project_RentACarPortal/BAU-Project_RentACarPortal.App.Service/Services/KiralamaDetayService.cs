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
    public class KiralamaDetayService : IKiralamaDetayService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorks _uow;

        public KiralamaDetayService(IMapper mapper, IUnitOfWorks uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public int Add(KiralamaDetay kiralamaDetay)
        {
            _uow.GetRepository<KiralamaDetay>().Add(kiralamaDetay);
            _uow.Commit();
            return kiralamaDetay.Id;
        }
        public async Task<List<KiralamaDetayViewModel>> GetAllKiralamaDetayAsync()
        {
            var list = await _uow.GetRepository<KiralamaDetay>().GetAll(null , null, x=>x.Araba);
            return _mapper.Map<List<KiralamaDetayViewModel>>(list);
        }

        public async Task<KiralamaDetayViewModel> GetKiralamaDetayAsync(int faturaNo)
        {
            var kiralama = await _uow.GetRepository<KiralamaDetay>().Get(x => x.FaturaNo == faturaNo);
            return _mapper.Map<KiralamaDetayViewModel>(kiralama);
        }
    }
}
