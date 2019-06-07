using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Projekt_PlatformyDoOrganizacjiWydarzen.Models
{
    public class TicketsContext : DbContext
    {
        public TicketsContext (DbContextOptions<TicketsContext> options)
            : base(options)
        {
        }

        public DbSet<Projekt_PlatformyDoOrganizacjiWydarzen.Models.TicketsModel> TicketsModel { get; set; }
    }
}
