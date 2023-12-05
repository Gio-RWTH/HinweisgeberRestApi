using HinweigeberRestApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HinweisDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

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

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

app.Run();
