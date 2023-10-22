using BAU_Project_RentACarPortal.App.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Entity.ViewModels
{
    public class FirmaViewModel
    {
        public int Id { get; set; }
        public string FirmaAdi { get; set; }
        public string FirmaAdresi { get; set; }
        public string FirmaTel { get; set; }
        public string? Fax { get; set; }
        public string Email { get; set; }

        //Relation
        public List<Araba> Arabalar { get; set; }
        public List<Degerlendirme> Degerlendirmelers { get; set; }
    }
}
