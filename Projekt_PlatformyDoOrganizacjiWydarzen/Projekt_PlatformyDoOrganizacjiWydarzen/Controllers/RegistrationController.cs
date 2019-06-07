
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekt_PlatformyDoOrganizacjiWydarzen.Models;
using System;
namespace Projekt_PlatformyDoOrganizacjiWydarzen.Controllers
{
    [Route("AP/Werify")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly VerifyContext _context;

        public RegistrationController(VerifyContext context)
        {
            _context = context;

        }

        

        [HttpGet("{event}/{ticket}")]
        public string Register(int ivent, int ticket)
        {
            

            
            
                //_context.VerifyModel.Where(p => p.ticket_id == ticket)
                //     .Where(p => p.event_id == ivent)


                var result = _context.VerifyModel.SingleOrDefault(b => b.event_id == ivent);
                    result = _context.VerifyModel.SingleOrDefault(b => b.ticket_id == ticket);
            if (result != null)
            {
                if (result.Regis != "tak")

                {
                    result.Regis = "tak";
                    _context.SaveChangesAsync();
                    return "good";
                }
                else if (result.Regis == "tak")
                    return "uzytkownik juz zarejestrowany";
                else
                    return "cos poszlo nie tak";

            }
               




                //    .ToList().ForEach(p => Rcontext.VerifyModel.Remove(p));
                //Rcontext.SaveChanges();

            

           return "uzytkownik nie istnieje";


            
        }
    }
}
