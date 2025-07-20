using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Servicios;
using Dominio.Modelos.Abstracciones;
using Infraestructura.AccesoDatos;
using Infraestructura.AccesoDatos.Repositorio;

namespace Aplicacion.ServiciosImpl
{
    public class AsistenciasServicioIMPL : ServicioIMPL<Asistencias>, IAsistenciasServicio
    {
        private readonly IAsistenciasRepo _serv;
        private readonly NominaDBContext _db;

        public AsistenciasServicioIMPL(IAsistenciasRepo serv, NominaDBContext db) : base(db)
        {
            _serv = serv;
            _db = db;
        }
    }
}
