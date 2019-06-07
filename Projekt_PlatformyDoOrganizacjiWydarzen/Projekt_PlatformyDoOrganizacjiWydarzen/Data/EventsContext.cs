using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Projekt_PlatformyDoOrganizacjiWydarzen.Models
{
    public class EventsContext : DbContext
    {
        public EventsContext (DbContextOptions<EventsContext> options)
            : base(options)
        {
        }

        public DbSet<Projekt_PlatformyDoOrganizacjiWydarzen.Models.EventsModel> EventsModel { get; set; }
    }
}
