using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projekt_PlatformyDoOrganizacjiWydarzen.Areas.Identity.Data;
using Projekt_PlatformyDoOrganizacjiWydarzen.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Projekt_PlatformyDoOrganizacjiWydarzen.Services;
using Projekt_PlatformyDoOrganizacjiWydarzen.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

[assembly: HostingStartup(typeof(Projekt_PlatformyDoOrganizacjiWydarzen.Areas.Identity.IdentityHostingStartup))]
namespace Projekt_PlatformyDoOrganizacjiWydarzen.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<Projekt_PlatformyDoOrganizacjiWydarzenContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Projekt_PlatformyDoOrganizacjiWydarzenContextConnection")));

                services.AddDefaultIdentity<Projekt_PlatformyDoOrganizacjiWydarzenUser>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<Projekt_PlatformyDoOrganizacjiWydarzenContext>();
            });
        }
    }
}