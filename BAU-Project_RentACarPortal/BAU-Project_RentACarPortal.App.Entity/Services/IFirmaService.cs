using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Entity.Services
{
    public interface IFirmaService
    {
        FirmaViewModel GetById(int id);
        Task<List<FirmaViewModel>> GetAllFirmaAsync();
        Task Add(FirmaViewModel model);
        void Edit(FirmaViewModel model);
        void Delete(int id);
    }
}
