using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Entity.Entities
{
    public class Sigorta
    {
        public int Id { get; set; }
        public string SigortaAdi { get; set; }
        public DateTime SigortaBaslangic { get; set; }
        public DateTime SigortaBitis { get; set; }
        public decimal SigortaUcret { get; set; }
        public bool IsDeleted { get; set; }

    }
}
