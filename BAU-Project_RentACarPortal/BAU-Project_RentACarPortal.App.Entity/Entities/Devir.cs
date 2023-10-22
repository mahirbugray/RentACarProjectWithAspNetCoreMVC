using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Entity.Entities
{
    public class Devir
    {
        public int? Id { get; set; }
        public int? ArabaId { get; set; }
        public DateTime? Tarih { get; set; }
        public int? Km { get; set; }
        public int? HasarDurumu { get; set; }
        public string? Resimler { get; set; }
        public bool IsDeleted { get; set; }



        //Relation
        [ForeignKey("KiralamaDetay")]
        public int FaturaNo { get; set; }
        public KiralamaDetay KiralamaDetay { get; set; }
    }
}