using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Web.Http;

using System.Net;
using System.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt_PlatformyDoOrganizacjiWydarzen.Models;
using Projekt_PlatformyDoOrganizacjiWydarzen.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_PlatformyDoOrganizacjiWydarzen.Services;
using IEmailSender = Projekt_PlatformyDoOrganizacjiWydarzen.Services.IEmailSender;

namespace Projekt_PlatformyDoOrganizacjiWydarzen.Models
{
    public class TicketsModel
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "ID wydarzenia")]
        public int event_id { get; set; }
        [Display(Name = "Nazwa")]
        public string name { get; set; }
        [Display(Name = "Miejsce")]
        public string place { get; set; }
        [Display(Name = "Data i godzina")]
        public string hour { get; set; }
        [Display(Name = "Email")]
        public string user_mail { get; set; }
        [Display(Name = "Imię")]
        [Required]
        public string user_name { get; set; }
        [Display(Name = "Nazwisko")]
        [Required]
        public string user_surname { get; set; }
        [Display(Name = "Typ Wydarzenia")]
        public string event_type { get; set; }
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Proszę wprowadzić prawidłowy NIP.")]
        [MinLength(10)]
        [RegularExpression("[0-9]{10,10}", ErrorMessage = "Proszę wprowadzić prawidłowy NIP.")]
        public string NIP { get; set; }
        public int tickets_per_person { get; set; }
        

        public string getUser()
        {
            return user_mail;
        }

        public static bool CheckPresonTickets(TicketsContext _context, TicketsModel ticketsModel)
        {
            var ticket = from t in _context.TicketsModel
                         select t;
            ticket = _context.TicketsModel
                .Where(t => t.user_mail.Contains(ticketsModel.user_mail))
                .Where(t => t.event_id.Equals(ticketsModel.event_id));
            int i = 0;
            foreach (var tickettmp in ticket)
            {
                i++;
            }
            if (i >= ticketsModel.tickets_per_person)
            {
                return false;
            }
            return true;
        }
     /*  public  void SendGroupMail(string message,int id, TicketsContext _context)
        {
            
            
            
        }*/
    }
}
