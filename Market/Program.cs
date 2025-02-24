using System;
using System.Collections.Generic;
using System.Linq;


using Market.Data;
using Market.Interfaces;
using Market.Models;
using Market.Repository;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication("Cookie").AddCookie();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();   
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddDbContext<ApplicationContext>(options=> options.UseNpgsql("DefaultConnection"));

var app =  builder.Build();
app.UseAuthentication();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();