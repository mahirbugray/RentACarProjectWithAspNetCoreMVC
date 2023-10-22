using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Entity.Entities
{
    public class Firma
    {
        public int Id { get; set; }
        public string FirmaAdi { get; set; }
        public string FirmaAdresi { get; set; }
        public string FirmaTel { get; set; }
        public string? Fax { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }

        //Relation
        public List<Araba> Arabalar { get; set; }
        public List<Degerlendirme> Degerlendirmelers { get; set; }
    }
}
