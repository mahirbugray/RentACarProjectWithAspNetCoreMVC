using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.DataAccess.Identity.Model
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCKNo { get; set; }
        public string? Adres { get; set; }
        public bool Cinsiyet { get; set; }
        public DateTime DogumYili { get; set; }

    }
}
