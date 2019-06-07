using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projekt_PlatformyDoOrganizacjiWydarzen.Services;
using Projekt_PlatformyDoOrganizacjiWydarzen.Entities;
using Microsoft.EntityFrameworkCore;
using Projekt_PlatformyDoOrganizacjiWydarzen.Models;
using Projekt_PlatformyDoOrganizacjiWydarzen.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Projekt_PlatformyDoOrganizacjiWydarzen
{
    public class Seeds
    {
        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
        public static void SeedUsers(UserManager<Projekt_PlatformyDoOrganizacjiWydarzenUser> userManager)
        {
            if (userManager.FindByNameAsync("adam.sulimadolina@gmail.com").Result == null)
            {
                Projekt_PlatformyDoOrganizacjiWydarzenUser user = new Projekt_PlatformyDoOrganizacjiWydarzenUser();
                user.UserName = "adam.sulimadolina@gmail.com";
                user.Email = "adam.sulimadolina@gmail.com";
                user.Name = "Adam Sulima Dolina";
                user.DOB = new DateTime(1998, 6, 23);

                IdentityResult result = userManager.CreateAsync
                (user, "Aaaa????3333").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

        }
    }
}
