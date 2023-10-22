using BAU_Project_RentACarPortal.App.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Entity.ViewModels
{
    public class DegerlendirmeViewModel
    {
        public int Id { get; set; }
        public string Yorum { get; set; }
        public string MusteriAdi { get; set; }
        public DateTime YorumTarihi { get; set; }
        public int ArabaId { get; set; }
        public int MusteriId { get; set; }
        public bool IsDeleted { get; set; }


        //Relation
        public Araba Araba { get; set; }
    }
}
