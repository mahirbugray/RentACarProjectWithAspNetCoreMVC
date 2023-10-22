using BAU_Project_RentACarPortal.App.Entity.Entities;
using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Entity.Services
{
    public interface IArabaService
    {
        Task<ArabaViewModel> GetById(int id);
        List<ArabaViewModel> GetAllDetay();
        Task<IEnumerable<ArabaViewModel>> GetAll();
        Task<ArabaViewModel> Get(int id);
        Task<IEnumerable<ArabaViewModel>> GetAllArabaWithFilterKategori(int id);
        Task<IEnumerable<ArabaViewModel>> GetAllWithFiltered(Expression<Func<Araba, bool>> filter = null, params Expression<Func<Araba, object>>[] includes);
        Task Add(ArabaViewModel model);
        void Edit(ArabaViewModel model);
        Task<int> LastCar();
        void Delete(int id);
        void Update(ArabaViewModel model);
        Task UpdateAdmin(int HasarDurumu, int Id);
        Task<List<ArabaViewModel>> GetAllArabaAdmin();
    }
}
