using BAU_Project_RentACarPortal.App.Entity.Entities;
using BAU_Project_RentACarPortal.App.Entity.Services;
using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Service.Services
{
    public class SepetDetayService : ISepetDetayService
    {
        public List<SepetDetayViewModel> SepeteEkle(List<SepetDetayViewModel> sepet, SepetDetayViewModel siparis)
        {
            if (sepet.Any(sd => sd.ArabaId == siparis.ArabaId))
            {
                //Daha önceden sepette olan bir ürün sepete eklenmişse;
                foreach (SepetDetayViewModel sd in sepet)
                {
                    if (sd.ArabaId == siparis.ArabaId)
                    {
                        sd.ArabaAdet += siparis.ArabaAdet;  //ürünün miktarını artır.
                    }
                }
            }
            else
            {
                sepet.Add(siparis);  //yeni siparişi sepete ekler.
            }
            return sepet;
        }
        public List<SepetDetayViewModel> SepettenSil(List<SepetDetayViewModel> sepet, int id)
        {
            sepet.RemoveAll(s => s.ArabaId == id);
            return sepet;
        }
        public int ToplamAdet(List<SepetDetayViewModel> sepet)
        {
            var toplamAdet = sepet.Sum(s => s.ArabaAdet);
            return toplamAdet;
        }
        public decimal ToplamTutar(List<SepetDetayViewModel> sepet)
        {
            var toplamTutar = sepet.Sum(s => s.ArabaAdet * s.ArabaUcret);
            return toplamTutar;
        }
    }
}
