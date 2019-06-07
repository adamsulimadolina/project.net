using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using System.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace Projekt_PlatformyDoOrganizacjiWydarzen.Models
{
    public class VerifyModel
    {
        [Key]
        [Display(Name = "ID xxx")]
        public int id { get; set; }


        [Display(Name = "id eventu")]
        public int event_id { get; set; }

        [Display(Name = "id biletu")]
        public int ticket_id { get; set; }
       // [DefaultValue("NIE")]
        [Display(Name = "Zarejestrowany")]
        public string Regis { get; set; }

        // public VerifyModel()
        //{
        // Registered = "NIE";
        // }




    }
}
