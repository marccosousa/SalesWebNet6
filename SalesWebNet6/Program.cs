using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Localization; 
using MySqlConnector;
using SalesWebNet6.Data;
using SalesWebNet6.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

string mySqlConnection = builder.Configuration.GetConnectionString("SalesWebNet6Context");
builder.Services.AddDbContextPool<SalesWebNet6Context>(options =>
options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<SeedingService>();
builder.Services.AddTransient<SellerService>();
builder.Services.AddTransient<DepartmentService>(); 
// Add services to the container.
var app = builder.Build();

var enUS = new CultureInfo("en-US");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(enUS),
    SupportedCultures = new List<CultureInfo> { enUS },
    SupportedUICultures = new List<CultureInfo> { enUS }
}; 

app.UseRequestLocalization(localizationOptions);
void SeedData(IHost app)
{
    var scopedService = app.Services.GetService<IServiceScopeFactory>();
    using (var scoped = scopedService.CreateScope())
    {
        var service = scoped.ServiceProvider.GetService<SeedingService>();
        service.Seed(); 
    }
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    SeedData(app);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
