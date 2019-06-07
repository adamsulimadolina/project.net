﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projekt_PlatformyDoOrganizacjiWydarzen.Areas.Identity.Data;

namespace Projekt_PlatformyDoOrganizacjiWydarzen.Models
{
    public class Projekt_PlatformyDoOrganizacjiWydarzenContext : IdentityDbContext<Projekt_PlatformyDoOrganizacjiWydarzenUser>
    {
        public Projekt_PlatformyDoOrganizacjiWydarzenContext(DbContextOptions<Projekt_PlatformyDoOrganizacjiWydarzenContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}