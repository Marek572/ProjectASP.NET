using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectASP.NET.Data
{
    public static class IdentitySeedData
    {
        private const string adminPassword = "zaq1@wsxC";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var userManager = (UserManager<IdentityUser>)scope.ServiceProvider.GetService(typeof(UserManager<IdentityUser>));

                IEnumerable<IdentityUser> users = new List<IdentityUser>()
                {
                    new IdentityUser()
                    {
                        Id = "1",
                        UserName = "callie.noris",
                        Email = "callie.noris@gmail.com"
                    },
                    new IdentityUser()
                    {
                        Id = "2",
                        UserName = "lillie.bruce",
                        Email = "lillie.bruce@gmail.com"
                    },
                    new IdentityUser()
                    {
                        Id = "3",
                        UserName = "daisy.diaz",
                        Email = "callie.noris@gmail.com"
                    },
                    new IdentityUser()
                    {
                        Id = "4",
                        UserName = "murphy.blender",
                        Email = "murphy.blender@gmail.com"
                    },
                    new IdentityUser()
                    {
                        Id = "5",
                        UserName = "antoni.gunn",
                        Email = "callie.noris@gmail.com"
                    }
                };

                IdentityUser user = await
                userManager.FindByIdAsync("1");
                if (user == null)
                {
                    foreach (IdentityUser x in users)
                    {
                        await userManager.CreateAsync(x, adminPassword);
                    }
                }
            }
        }
    }
}
