using Aplicacion.Servicios;
using Aplicacion.ServiciosImpl;
using Infraestructura.AccesoDatos;
using Microsoft.EntityFrameworkCore;

namespace TestMateo
{
    public class Tests
    {
        private NominaDBContext _dbContext;
        private IEmpleadosServicio _empleServ;

        [SetUp] 
        public void Setup()
        {
            var opcion = new DbContextOptionsBuilder<NominaDBContext>().UseSqlServer("Data Source=DESKTOP-NCNTGBP\\MIPRIMERSQL2024;Initial Catalog=NominaPisip;Integrated Security=True;TrustServerCertificate=True;")
                .Options;
            _dbContext = new NominaDBContext(opcion);
            _empleServ = new EmpleadosServicioIMPL(_dbContext);
        }

        [Test]
        public async Task Pruebas()
        {
            
            Empleados empleados = new Empleados
            {
                Nombres = "Mateo",
                Apellidos = "Vasquez",
                Cedula = "1752779908",
                Correo = "mateoso_21@gmail.com",
                FechaIngreso = DateOnly.FromDateTime(DateTime.Today),
                Estado = true,
                FechaNacimiento = new DateOnly(2003,05,21),
                Genero = "H",
                FechaCreacion = DateTime.Now,
                Telefono = "0958882608",
                PuestoId = 3,
                
            };

            Empleados empleados2 = new Empleados
            {
                //Nombres = "Mateo",
                //Apellidos = "Vasco",
                Cedula = "1752479908",
                //Correo = "mateo_22@gmail.com",
                //FechaIngreso = DateOnly.FromDateTime(DateTime.Today),
                //Estado = true,
                //FechaNacimiento = new DateOnly(2001, 07, 21),
                //Genero = "H",
                //FechaCreacion = DateTime.Now,
                //Telefono = "0954882608",
                //PuestoId = 1,

            };

            //await _empleServ.AgregarAsync(empleados2);

            //var emplDTO = await _empleServ.ObtenerEmpleadoDTOPorCedulaAsync(empleados);

            //Console.WriteLine(emplDTO.ToString());

            Assert.Pass();
        }
        [TearDown]
        public void TearDown() { 
            _dbContext.Dispose();
        }
    }
}