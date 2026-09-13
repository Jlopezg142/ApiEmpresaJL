using ApiEmpresa.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ======================================================
// CONTROLADORES
// ======================================================

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ======================================================
// CONEXIÓN A MYSQL
// ======================================================

//var connectionString =
//    builder.Configuration.GetConnectionString("ConexionMySql")
//    ?? throw new InvalidOperationException(
//        "No se encontró la cadena de conexión ConexionMySql."
//    );
//
//builder.Services.AddDbContext<Conexiones>(options =>
//{
//    options.UseMySQL(connectionString);
//});

// ======================================================
// CONEXIÓN A AZURE SQL SERVER
// ======================================================

var connectionString =
    builder.Configuration.GetConnectionString("ConexionSqlServer")
    ?? throw new InvalidOperationException(
        "No se encontró la cadena de conexión ConexionSqlServer."
    );

builder.Services.AddDbContext<Conexiones>(options =>
{
    options.UseSqlServer(connectionString);
});


// ======================================================
// CREAR APLICACIÓN
// ======================================================

var app = builder.Build();


// ======================================================
// SWAGGER
// ======================================================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// ======================================================
// HTTPS
// ======================================================

app.UseHttpsRedirection();


// ======================================================
// CONTROLADORES
// ======================================================

app.MapControllers();


// ======================================================
// EJECUTAR
// ======================================================

app.Run();