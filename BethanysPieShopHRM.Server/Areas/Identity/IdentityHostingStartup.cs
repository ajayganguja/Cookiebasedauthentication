﻿using System;
using BethanysPieShopHRM.Server.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(BethanysPieShopHRM.Server.Areas.Identity.IdentityHostingStartup))]
namespace BethanysPieShopHRM.Server.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<BethanysPieShopHRMServerContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("BethanysPieShopHRMServerContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<BethanysPieShopHRMServerContext>();
            });
        }
    }
}