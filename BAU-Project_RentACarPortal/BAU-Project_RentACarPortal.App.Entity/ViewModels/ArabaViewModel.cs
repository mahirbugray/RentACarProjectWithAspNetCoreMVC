using BAU_Project_RentACarPortal.App.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Entity.ViewModels
{
    public class ArabaViewModel
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string UretimYili { get; set; }
        public decimal SaatlikUcret { get; set; }
        public bool IsAvailable { get; set; }
        public string Resim { get; set; }
        public string Plaka { get; set; }
        public int HasarDurumu { get; set; }


        public bool IsDeleted { get; set; }

        //Relation

        public int ArabaKategoriId { get; set; }
        public ArabaKategori ArabaKategori { get; set; }


        public int FirmaId { get; set; }
        public Firma Firma { get; set; }


        public int? ArabaDetayId { get; set; }
        public ArabaDetay ArabaDetay { get; set; }

        public List<KiralamaDetay> KiralamaDetaylari { get; set; }

        public int SigortaId { get; set; }
        public Sigorta Sigorta { get; set; }
    }
}
