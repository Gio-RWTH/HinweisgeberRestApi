using AutoMapper;
using HinweigeberRestApi.Areas.Massnahmen.Mapper;
using HinweigeberRestApi.Data;
using HinweigeberRestApi.Data.ContextFactory;
using HinweigeberRestApi.Data.ContextFactory.MainContextDB;
using HinweigeberRestApi.Repository;
using HinweigeberRestApi.Services.MassnahmenService;
using HinweigeberRestApi.Services.MeldungenService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();
builder.Services.AddDbContext<MainContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

// Add services to the container.
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDbContextFactory<HinweisDbContext>, PartnerContextFactory>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IMeldungenService, MeldungenService>();
builder.Services.AddScoped<IMassnahmenServicecs, MassnahmenService>();
builder.Services.AddAutoMapper(typeof(MassnahmenProfile));


//builder.WebHost.UseKestrel(options =>
//{
//    options.Listen(IPAddress.Any, 5002); // Adjust the IP and port accordingly
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseRouting(); // 👈👈it is new line

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x
.SetIsOriginAllowed(_ => true)
.WithOrigins(
	"https://gfi-hinweisgeber.de",
	"https://gfi-Hinweisgeber.de")
	.AllowAnyMethod()
	.AllowAnyHeader()
	.AllowCredentials());

app.Run();
