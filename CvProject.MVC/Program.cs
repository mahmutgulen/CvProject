using Autofac;
using Autofac.Extensions.DependencyInjection;
using CvProject.BLL.DependencyResolvers.Autofac;

var builder = WebApplication.CreateBuilder(args);

//autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });

builder.Services.AddMvc();


var app = builder.Build();


app.MapControllerRoute(
    name: "Default",
    pattern: "{controller=Cv}/{action=Index}");


app.Run();
