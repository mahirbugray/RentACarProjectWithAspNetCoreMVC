using AutoMapper;
using BAU_Project_RentACarPortal.App.Entity.Entities;
using BAU_Project_RentACarPortal.App.Entity.IUnitOfWorks;
using BAU_Project_RentACarPortal.App.Entity.Services;
using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Service.Services
{
    public class KiralamaService : IKiralamaService
    {
        private readonly IArabaService _arabaService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorks _uow;
        public KiralamaService(IArabaService arabaService, IMapper mapper, IUnitOfWorks uow)
        {
            _arabaService = arabaService;
            _mapper = mapper;
            _uow = uow;
        }

        public int Add(Kiralama kiralama)
        {
            _uow.GetRepository<Kiralama>().Add(kiralama);
            _uow.Commit();
            return kiralama.Id;
        }
        public async void Update(int faturaNo)
        {
            Kiralama kiralama = await _uow.GetRepository<Kiralama>().GetById(faturaNo);
            kiralama.KiralamaBitti = true;
        }

        public async Task<Kiralama> FindAsyncKiralama(int id)
        {
            var kiralama = await _uow.GetRepository<Kiralama>().GetById(id);
            return kiralama;
        }

        public async Task<List<KiralamaViewModel>> FindKiralamaAsync(int id)
        {
            IEnumerable<Kiralama> kiralama = await _uow.GetRepository<Kiralama>().GetAll(x => x.MusteriId == id && x.KiralamaBitti == false);
            var kiralamaMap = _mapper.Map<List<KiralamaViewModel>>(kiralama);
            foreach (var item in kiralamaMap)
            {
                KiralamaDetay plaka = await _uow.GetRepository<KiralamaDetay>().Get(x => x.FaturaNo == item.FaturaNo, null, x => x.Araba);
                item.Plaka = plaka.Araba.Plaka;
            }
            return kiralamaMap;
        }

        public async Task<List<KiralamaViewModel>> GetAllKiralama()
        {
            var liste = await _uow.GetRepository<Kiralama>().GetAllAsync();
            return _mapper.Map<List<KiralamaViewModel>>(liste);
        }

        public async Task<List<KiralamaDetayViewModel>> SepeteEkle(List<KiralamaDetayViewModel> sepet, KiralamaDetayViewModel siparis)
        {
            //var araba = await _arabaService.Get(siparis.ArabaId);
            //siparis.Araba = _mapper.Map<Araba>(araba);
            if (sepet.Any(sd => sd.ArabaId == siparis.ArabaId))
            {
                //Daha önceden sepette olan bir ürün sepete eklenmişse;
                foreach (KiralamaDetayViewModel sd in sepet)
                {
                    if (sd.ArabaId == siparis.ArabaId)
                    {
                        sd.ToplamAdet += siparis.ToplamAdet;  //ürünün miktarını artır.
                    }
                }
            }
            else
            {
                sepet.Add(siparis);  //yeni siparişi sepete ekler.
            }
            return sepet;
        }
        public List<KiralamaDetayViewModel> SepettenSil(List<KiralamaDetayViewModel> sepet, int id)
        {
            sepet.RemoveAll(s => s.ArabaId == id);
            return sepet;
        }
        public int ToplamAdet(List<KiralamaDetayViewModel> sepet)
        {
            var toplamAdet = sepet.Sum(s => s.ToplamAdet);
            return toplamAdet;
        }
        public decimal ToplamTutar(List<KiralamaDetayViewModel> sepet)
        {
            var toplamTutar = sepet.Sum(s => s.ToplamAdet * s.GunlukUcret);
            return toplamTutar;
        }

        public void Update(Kiralama kiralama)
        {
            _uow.GetRepository<Kiralama>().Update(kiralama);
            _uow.Commit();
        }
    }
}
