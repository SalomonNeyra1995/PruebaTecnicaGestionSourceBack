using Microsoft.EntityFrameworkCore;
using Casas.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Agregar servicios ANTES de Build()
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Configurar CORS (también ANTES de Build)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")  // Vite usa puerto 5173, no 3000
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();   // <- A partir de aquí NO se pueden agregar más servicios

// 3. Usar CORS después de Build()
app.UseCors("AllowReactApp");

// Resto del pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();