using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Projekt_PlatformyDoOrganizacjiWydarzen.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the Projekt_PlatformyDoOrganizacjiWydarzenUser class
    public class Projekt_PlatformyDoOrganizacjiWydarzenUser : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }
        [PersonalData]
        public DateTime DOB { get; set; }
    }
}
