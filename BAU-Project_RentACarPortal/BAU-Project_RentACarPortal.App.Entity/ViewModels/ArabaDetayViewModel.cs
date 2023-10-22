using BAU_Project_RentACarPortal.App.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Entity.ViewModels
{
    public class ArabaDetayViewModel
    {
        public int Id { get; set; }
        public string Renk { get; set; }
        public string Yakıt { get; set; }
        public string Vites { get; set; }
        public string Km { get; set; }
        public string Aciklama { get; set; }

        //Relation
        public int ArabaId { get; set; }
        public Araba Araba { get; set; }
    }
}
