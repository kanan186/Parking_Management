using Microsoft.AspNetCore.Identity;
using ParkingManagement.Data;
using Microsoft.EntityFrameworkCore;
using ParkingManagement.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();

//Add session 
builder.Services.AddSession();

// Register the database context
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbcon")));

// Register the Password Hasher
//builder.Services.AddScoped<IPasswordHasher<Register>, PasswordHasher<Register>>();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
