using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Entity.Services
{
    public interface IArabaDetayService
    {
        ArabaDetayViewModel GetById(int id);
        List<ArabaDetayViewModel> GetAllDetay();
        Task<IEnumerable<ArabaDetayViewModel>> GetAll();
        Task<ArabaDetayViewModel> Get(int id);
        Task<List<ArabaDetayViewModel>> GetByArabaFiltre(int id);
        Task Add(ArabaDetayViewModel model);

    }
}
