using BAU_Project_RentACarPortal.App.Entity.Entities;
using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Entity.Services
{
    public interface IKiralamaDetayService
    {
        int Add(KiralamaDetay kiralamaDetay);
        Task<List<KiralamaDetayViewModel>> GetAllKiralamaDetayAsync();
        Task<KiralamaDetayViewModel> GetKiralamaDetayAsync(int faturaNo);
    }
}
