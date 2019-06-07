using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekt_PlatformyDoOrganizacjiWydarzen.Models;
using System;

namespace Projekt_PlatformyDoOrganizacjiWydarzen.Controllers
{
    [Route("api/API")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly EventsContext _context;

        public APIController(EventsContext context)
        {
            _context = context;
           
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventsModel>>> Events()
        {
            return  await _context.EventsModel.ToListAsync();
        }

        [HttpGet("{placeString}/{startdate}/{enddate}")]
        public async Task<ActionResult<IEnumerable<EventsModel>>> Events(string placeString, DateTime startdate, DateTime enddate)
        {

            var events = from e in _context.EventsModel
                         select e;
            if (!String.IsNullOrEmpty(placeString))
            {
                events = events.Where(s => s.place.Contains(placeString));
            }
            
            if (startdate.ToString("dd/MM/yyyy") != "01.01.2019" || enddate.ToString("dd/MM/yyyy") != "01.01.2019")
            {
                events = _context.EventsModel
                    .Where(e => e.hour >= startdate)
                    .Where(e => e.hour <= enddate)
                    .Where(s => s.place.Contains(placeString));
            }



            return await events.ToListAsync();
        }
    }
}