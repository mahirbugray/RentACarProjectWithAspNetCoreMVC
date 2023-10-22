using BAU_Project_RentACarPortal.App.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Entity.ViewModels
{
    public class KategoriViewModel
    {
        public int Id { get; set; }
        public string KategoriAdi { get; set; }

        //Relation
        public List<Araba> Arabalar { get; set; }
    }
}
