using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTO.DTOs;
using Aplicacion.Servicios;
using Dominio.Modelos.Abstracciones;
using Infraestructura.AccesoDatos;
using Infraestructura.AccesoDatos.Repositorio;

namespace Aplicacion.ServiciosImpl
{
    public class SolicitudVacacionesServicioIMPL : ServicioIMPL<SolicitudVacaciones>, ISolicitudVacacionesServicio
    {

        private ISolicitudVacacionesRepo _repo;
        private readonly NominaDBContext _context;
 

        public SolicitudVacacionesServicioIMPL(NominaDBContext context) : base(context)
        {
            _context = context;
            _repo = new SolicitudVacacionesRepositorioIMPL(context);
        }

        public async  Task<List<SolicitudVacacionDTO>> ObtenerResumenSolicitudesAsync()
        {
            try
            {
                return await _repo.ObtenerResumenSolicitudesAsync();

            }
            catch (Exception ex)
            {
                // Manejo de excepciones, logging, etc.
                throw new NotImplementedException("ERROR AL OBTENER RESUMEN DE SOLICITUDES DE VACACIONES", ex);

            }
        }
    }
}
