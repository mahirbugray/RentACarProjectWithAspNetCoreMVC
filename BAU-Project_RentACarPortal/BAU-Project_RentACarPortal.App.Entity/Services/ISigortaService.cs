using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Entity.Services
{
    public interface ISigortaService
    {
        SigortaViewModel GetById(int id);
        Task<List<SigortaViewModel>> GetAllSigortaAsync();
        Task Add(SigortaViewModel model);
        void Edit(SigortaViewModel model);
        void Delete(int id);
    }
}
