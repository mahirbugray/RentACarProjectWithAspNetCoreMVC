using BAU_Project_RentACarPortal.App.Entity.Entities;
using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Entity.Services
{
    public interface IKiralamaService
    {
        Task<List<KiralamaDetayViewModel>> SepeteEkle(List<KiralamaDetayViewModel> sepet, KiralamaDetayViewModel siparis);
        List<KiralamaDetayViewModel> SepettenSil(List<KiralamaDetayViewModel> sepet, int id);
        int ToplamAdet(List<KiralamaDetayViewModel> sepet);
        decimal ToplamTutar(List<KiralamaDetayViewModel> sepet);
        int Add(Kiralama kiralama);
        Task<Kiralama> FindAsyncKiralama(int id);
        void Update(Kiralama kiralama);
        Task<List<KiralamaViewModel>> GetAllKiralama();
        Task <List<KiralamaViewModel>> FindKiralamaAsync(int id);
        void Update(int faturaNo);
    }
}
