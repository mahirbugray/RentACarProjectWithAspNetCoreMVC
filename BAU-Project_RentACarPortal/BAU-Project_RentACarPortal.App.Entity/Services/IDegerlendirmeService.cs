using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Entity.Services
{
    public interface IDegerlendirmeService
    {
        Task<List<DegerlendirmeViewModel>> GetAllArabaId(int id);
        Task Add(DegerlendirmeViewModel model);
    }
}
