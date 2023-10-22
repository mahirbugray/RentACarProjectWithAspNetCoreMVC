using BAU_Project_RentACarPortal.App.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Entity.ViewModels
{
    public class KiralamaViewModel
    {
        public int Id { get; set; }
        public int FaturaNo { get; set; }
        public decimal ToplamTutar { get; set; }
        public DateTime KiralamaTarihi { get; set; }
        public bool IsDeleted { get; set; }
        public string Plaka { get; set; }



        //Relation
        public int MusteriId { get; set; }
        public List<KiralamaDetay> KiralamaDetaylari { get; set; }
    }
}
