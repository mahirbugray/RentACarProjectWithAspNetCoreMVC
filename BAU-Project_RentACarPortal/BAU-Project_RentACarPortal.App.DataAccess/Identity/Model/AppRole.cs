using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.DataAccess.Identity.Model
{
    public class AppRole : IdentityRole<int>
    {
        public string Description { get; set; }
    }
}
