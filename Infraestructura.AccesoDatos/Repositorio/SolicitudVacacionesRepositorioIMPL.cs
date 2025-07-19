using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTO.DTOs;
using Dominio.Modelos.Abstracciones;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class SolicitudVacacionesRepositorioIMPL : RepositorioImpl<SolicitudVacaciones>, ISolicitudVacacionesRepo
    {
        
        private readonly NominaDBContext _context;
        public SolicitudVacacionesRepositorioIMPL(NominaDBContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<SolicitudVacacionDTO>> ObtenerResumenSolicitudesAsync()
        {
            try
            {
                return await _context.SolicitudVacaciones
                    .Include(sv => sv.Empleado)
                    .Select(sv => new SolicitudVacacionDTO
                    {
                        IdSolicitud = sv.IdSolicitud,
                        Cedula = sv.Empleado.Cedula,
                        NombreCompleto = sv.Empleado.Nombres + " " + sv.Empleado.Apellidos,
                        FechaInicio = sv.FechaInicio.ToDateTime(TimeOnly.MinValue),
                        FechaFin = sv.FechaFin.ToDateTime(TimeOnly.MinValue),
                        Estado = sv.Estado
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR AL OBTENER RESUMEN DE SOLICITUDES", ex);
            }
        }


    }
}
