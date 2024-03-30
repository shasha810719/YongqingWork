using Autofac;
using Autofac.Extensions.DependencyInjection;
using YongqingWork;
using YongqingWork.Modules;

var builder = WebApplication.CreateBuilder(args);

//��l�ƨëإߤ@�ӹ��
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
//���UAutofac
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new ServiceModule()));
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new RepositoryModule()));
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new DatebaseModule()));

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
