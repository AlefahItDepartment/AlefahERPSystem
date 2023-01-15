using AlefahERP.Repository;
using AlefahERP.Services;
using AlefahERP.WebUI.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Radzen;
using Radzen.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddDbContext<AlefahDbContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:ConStr"]));

builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

builder.Services.AddAuthorization(options =>
{

    options.AddPolicy("SuperAdminOnly", policy => policy.RequireRole("SuperAdministrator"));
    options.AddPolicy("CustomerOnly", policy => policy.RequireRole("Customer"));
    options.AddPolicy("DoctorOnly", policy => policy.RequireRole("Doctor"));
    options.AddPolicy("ReceptionerOnly", policy => policy.RequireRole("Receptioner"));
    options.AddPolicy("FinanceDepartmentOnly", policy => policy.RequireRole("FinanceDepartment"));
    options.AddPolicy("SaleDepartmentOnly", policy => policy.RequireRole("SaleDepartment"));
    options.AddPolicy("ProcurementDepartmentOnly", policy => policy.RequireRole("ProcurementDepartment"));
    options.AddPolicy("HRDepartmentOnly", policy => policy.RequireRole("HRDepartment"));
    options.AddPolicy("GuestOnly", policy => policy.RequireRole("Guest"));
});

builder.Services.AddSingleton<CustomAuthService>();


builder.Services.AddScoped<AlefahDbContext>();
IServiceCollection services = builder.Services;
services.AddScopedServiceServices();

services.AddServerSideBlazor().AddHubOptions(o =>
{
    o.MaximumReceiveMessageSize = 10 * 1024 * 1024;
});
builder.Services.AddScoped<SessionUserService>();
builder.Services.AddScoped<NavigationService>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();


var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

await app.RunAsync();
