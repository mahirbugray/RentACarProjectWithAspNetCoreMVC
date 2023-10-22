using BAU_Project_RentACarPortal.App.Entity.Entities;
using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Entity.Services
{
    public interface ISepetDetayService
    {
        List<SepetDetayViewModel> SepeteEkle(List<SepetDetayViewModel> sepet, SepetDetayViewModel siparis);
        List<SepetDetayViewModel> SepettenSil(List<SepetDetayViewModel> sepet, int id);
        int ToplamAdet(List<SepetDetayViewModel> sepet);
        decimal ToplamTutar(List<SepetDetayViewModel> sepet);
    }
}
