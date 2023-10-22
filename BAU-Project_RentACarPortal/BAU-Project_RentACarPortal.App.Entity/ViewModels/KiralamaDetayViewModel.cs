using BAU_Project_RentACarPortal.App.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Entity.ViewModels
{
    public class KiralamaDetayViewModel
    {

        public int Id { get; set; }
        public string ArabaIsmi { get; set; }
        public int FaturaNo { get; set; }
        public bool IsDeleted { get; set; }
        public decimal GunlukUcret { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public int ToplamAdet { get; set; }



        //Relation
        //public string FaturaNo { get; set; }

        public int KiralamaId { get; set; }
        public Kiralama Kiralama { get; set; }

        public int ArabaId { get; set; }
        public Araba Araba { get; set; }


        public Devir Devir { get; set; }

        public Teslim? Teslim { get; set; }
    }
}
