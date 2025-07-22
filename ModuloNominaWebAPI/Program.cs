using Microsoft.EntityFrameworkCore;
using Aplicacion.Servicios;
using Aplicacion.ServiciosImpl;
using Dominio.Modelos.Abstracciones;
using Infraestructura.AccesoDatos;
using Infraestructura.AccesoDatos.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });



// porque tengo un error en la line de arriba que dice que no se puede encontrar el tipo NominaDBContext

// voy hacer tres cosas

// 1. hacer que cuando se levante la aplicacion automaticamente se vaya al appsettings.json y lea la cadena de conexion y la guarde en una variable de entorno llamada "DefaultConnection" para que luego pueda ser usada por el DbContext NominaPISIBContext
// 2 Crear mi dbcontext general o global con la conection string que esta en el archivo de configuraciones
// 3. configurar mis servicios mis service para que automaticamente esten disponibles cuando arranque mi API



// 1. leer la cadena de conexion del appsettings.json y guardarla en una variable de entorno
//var connectionDB = builder.Configuration.GetConnectionString("DefaultConnection");
var connectionDB = builder.Configuration.GetConnectionString("ConnectionMateo"); // ("ConnectionMateo") es la de mateo
// 2. crear el DbContext global con la cadena de conexion
builder.Services.AddDbContext<NominaDBContext>(options =>
    options.UseSqlServer(connectionDB), ServiceLifetime.Scoped);
// 3. configurar los servicios para que esten disponibles

builder.Services.AddScoped<IDescuentosRepo, DescuentosRepositorioIMPL>();
builder.Services.AddScoped<IDescuentosServicio, DescuentosServicioIMPL>();

builder.Services.AddScoped<IAsistenciasRepo, AsistenciasRepositorioIMPL>();
builder.Services.AddScoped<IAsistenciasServicio,AsistenciasServicioIMPL>();





builder.Services.AddScoped<ISolicitudVacacionesServicio, SolicitudVacacionesServicioIMPL>();
builder.Services.AddScoped<IContratosServicio, ContratosServicioIMPL>();

// contratotipo
builder.Services.AddScoped<IContratosTipoServicio, ContratosTipoServicioIMPL>();
// aprobacionvacaciones
builder.Services.AddScoped<IAprobacionVacacionesServicio, AprobacionVacacionesServicioIMPL>();
// para empleados puestos 
builder.Services.AddScoped<IEmpleadosServicio, EmpleadosServicioIMPL>();

// puestos 
builder.Services.AddScoped<IPuestosServicio, PuestosServicioIMPL>();





builder.Services.AddScoped<IEmpleadosVacacionesTotalesServicio, EmpleadosVacacionesTotalesServicioIMPL>();








var app = builder.Build();

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
