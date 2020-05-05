using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecuritySystem.Areas.Identity.Data;
using SecuritySystem.Models;

[assembly: HostingStartup(typeof(SecuritySystem.Areas.Identity.IdentityHostingStartup))]
namespace SecuritySystem.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SecurityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SecurityDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<SecurityDbContext>();
            });
        }
    }
}