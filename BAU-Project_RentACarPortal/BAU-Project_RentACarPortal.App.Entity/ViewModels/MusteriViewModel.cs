using BAU_Project_RentACarPortal.App.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Entity.ViewModels
{
    public class MusteriViewModel
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TcNo { get; set; }
        public bool Cinsiyet { get; set; }
        public string DogumYili { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }


        //Relation

        public List<Kiralama> Kiralamalar { get; set; }
        public List<Degerlendirme> Degerlendirmelers { get; set; }
    }
}
