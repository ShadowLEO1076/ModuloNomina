using Aplicacion.Servicios;
using Aplicacion.ServiciosImpl;
using Infraestructura.AccesoDatos;
using Microsoft.EntityFrameworkCore;
/*using Aplicacion.Servicios;
using Aplicacion.ServiciosImpl;
using Infraestructura.AccesoDatos;*/



namespace TestLeonardoCalvache  // no funccionsionó este test esta por revisar es interesante porque depende del test luego toca añadir nuevas implementaciones
{
    public class Tests
    {
        private NominaDBContext _context;
        private ISolicitudVacacionesServicio _solicitudvServ;
        

        [SetUp]
        public void Setup()
        {
            //esta config funciona solo en mi compu.
            var opcion = new DbContextOptionsBuilder<NominaDBContext>().UseSqlServer("Data Source=(localdb)\\leo;Initial Catalog=ModuloNomina;Integrated Security=True")
                .Options;

            _context = new NominaDBContext(opcion);
            _solicitudvServ = new SolicitudVacacionesServicioIMPL(_context);
            //_puestosServ = new PuestosServicioImpl(_context);
        }

        [Test]

        public async Task TestAprobacionVacaciones()
        {
            var SolicitudVacacionesPrueva = new SolicitudVacaciones
            {
                IdSolicitud = 1,
                EmpleadoId = 1, // Asegúrate de que este ID exista en tu base de datos
                FechaInicio = new DateOnly(2023, 10, 1),
                FechaFin = new DateOnly(2023, 10, 15),
                Estado = "Pendiente", // Cambia el estado según sea necesario
                DiasSolicitados = 10, // Asegúrate de que este valor sea válido


            };

            await _solicitudvServ.AgregarAsync(SolicitudVacacionesPrueva);// Corrected variable name
            // Assert.Pass();
        }
        // test que me copie de mateo para provar conección a la base de datos y el servicio de puestos
        /*public async Task Test1()
        {
            var puestoPrueba = new Puestos { idPuesto = 1, PuestoNombre = "INGENIERO EN SISTEMAS", PuestoSalario = (decimal)560.56, PuestoVacacionesCantidad = 40 };

            await _puestosServ.AddAsync(puestoPrueba);
            //Assert.Pass();
        }
        */
        [TearDown]
        public void Terminar()
        {
            _context.Dispose();
        }
    }
}