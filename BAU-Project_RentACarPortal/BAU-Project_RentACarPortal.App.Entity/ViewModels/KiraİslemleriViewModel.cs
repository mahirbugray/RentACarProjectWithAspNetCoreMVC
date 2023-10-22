using BAU_Project_RentACarPortal.App.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Entity.ViewModels
{
    public class KiraİslemleriViewModel
    {
        public UserViewModel user { get; set; }
        public List<KiralamaDetayViewModel> kiralamaIslemDetay { get; set; }
        public List<SepetDetayViewModel> sepetDetayListesi { get; set; }
        public List<KiralamaViewModel> kiralamaIslemi { get; set; }
    }
}
