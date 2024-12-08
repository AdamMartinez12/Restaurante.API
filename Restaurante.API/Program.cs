using Microsoft.EntityFrameworkCore;
using Restaurante.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("https://localhost:44350") // Reemplaza con la URL de tu cliente
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});



// Add services to the container.

builder.Services.AddDbContext<Restaurante.Domain.Data.RestauranteDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<DetalleOrdenService>();
builder.Services.AddScoped<MenuService>();
builder.Services.AddScoped<MesasService>();
builder.Services.AddScoped<OrdenesService>();
builder.Services.AddScoped<ReservacionesService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
