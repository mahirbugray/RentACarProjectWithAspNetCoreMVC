using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Entity.ViewModels
{
    public class SepetDetayViewModel
    {
        public int ArabaId { get; set; }
        public string ArabaMarka { get; set; }
        public int ArabaAdet { get; set; }
        public decimal ArabaUcret { get; set; }
        public int FaturaNo { get; set; }
    }
}
