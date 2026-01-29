using Contactos.Application.Interfaces;
using Contactos.Application.Mappings;
using Contactos.Application.Services;
using Contactos.Domain.Interfaces;
using Contactos.Infrastructure;
using Contactos.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("dbContactos");
builder.Services.AddSqlServer<ContactoContext>(builder.Configuration.GetConnectionString("dbContactos"));

builder.Services.AddScoped<IContactoRepository, ContactoRepository>();
builder.Services.AddScoped<IContactoService, ContactoService>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<ContactMappingProfile>();
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
