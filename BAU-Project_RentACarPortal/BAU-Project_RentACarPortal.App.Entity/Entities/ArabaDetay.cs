using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Entity.Entities
{
    public class ArabaDetay
    {
        public int Id { get; set; }
        public string Renk { get; set; }
        public string Yakıt { get; set; }
        public string Vites { get; set; }
        public string Km { get; set; }
        public string Aciklama { get; set; }
        public bool IsDeleted { get; set; } 


        //Relation
        public int ArabaId { get; set; }
        public Araba Araba { get; set; }
    }
}
