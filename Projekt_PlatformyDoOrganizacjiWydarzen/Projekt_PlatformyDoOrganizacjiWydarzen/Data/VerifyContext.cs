using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Projekt_PlatformyDoOrganizacjiWydarzen.Models
{
    public class VerifyContext : DbContext
    {
        public VerifyContext(DbContextOptions<VerifyContext> options)
            : base(options)
        {
        }

        public DbSet<VerifyModel> VerifyModel { get; set; }
    }
}
