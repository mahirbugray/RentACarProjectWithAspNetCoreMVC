using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Entity.Entities
{
    public class Kiralama
    {
        public int Id { get; set; }
        public int FaturaNo { get; set; }
        public decimal ToplamTutar {  get; set; }
        public DateTime KiralamaTarihi { get; set; }
        public bool IsDeleted { get; set; }
        public bool KiralamaBitti {  get; set; }


        //Relation
        public int MusteriId { get; set; }
        public List<KiralamaDetay> KiralamaDetaylari { get; set; }
    }
}
