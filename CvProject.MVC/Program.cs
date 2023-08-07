using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CvProject.BLL.DependencyResolvers.Autofac;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

//autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });

builder.Services.AddMvc();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
{
    opt.Cookie.Name = "NetCoreMvc.Auth";
    opt.LoginPath = "/Auth/Index";
    opt.AccessDeniedPath= "/Auth/Index";
});

builder.Services.AddNotyf(config => { config.DurationInSeconds = 3; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });

var app = builder.Build();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Index}/{id?}");

app.UseNotyf();

app.Run();
