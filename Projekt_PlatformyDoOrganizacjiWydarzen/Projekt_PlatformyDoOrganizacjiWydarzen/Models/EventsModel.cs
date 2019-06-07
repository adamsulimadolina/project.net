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

namespace Projekt_PlatformyDoOrganizacjiWydarzen.Models
{
    public class EventsModel
    {
        [Key]
        [Display(Name = "ID wydarzenia")]
        public int id { get; set; }
        [Display(Name = "Nazwa")]
        public string name { get; set; }
        [Display(Name = "Miejsce")]
        public string place { get; set; }
        [Display(Name = "Typ Wydarzenia")]
        public string event_type { get; set; }
        [Display(Name = "Data i godzina")]
        public DateTime hour { get; set; }
        [Display(Name = "Ilość miejsc")]
        public int tickets { get; set; }
        [Display(Name = "Bilety na osobę")]
        public int tickets_per_person { get; set; }
        [Display(Name = "Organizator")]
        public string organizer { get; set; }


        public string getUser()
        {
            return organizer;
        }

    }
}
