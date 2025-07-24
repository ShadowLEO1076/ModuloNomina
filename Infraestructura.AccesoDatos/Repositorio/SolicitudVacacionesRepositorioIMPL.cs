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
                        IdEmpleado = sv.EmpleadoId,
                        NombreCompleto = sv.Empleado.Nombres + " " + sv.Empleado.Apellidos,
                        Cedula = sv.Empleado.Cedula, 
                        FechaInicio = sv.FechaInicio,
                        // arreglado de esta forma :
                        FechaFin = sv.FechaFin,
                        DiasSolicitados = sv.DiasSolicitados,
                        Estado = sv.Estado,
                        FechaCreacion = sv.FechaCreacion
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR AL OBTENER RESUMEN DE SOLICITUDES", ex);
            }
        }

        public  async Task<List<SolicitudVacacionDTO>> ObtenerSolicitudesPorEstadoAsync(string estado)
        {
            try
            {
                return await _context.SolicitudVacaciones
                    .Include(sv => sv.Empleado)
                    .Where(sv => sv.Estado == estado)
                    .Select(sv => new SolicitudVacacionDTO
                    {
                        IdSolicitud = sv.IdSolicitud,
                        IdEmpleado = sv.EmpleadoId,
                        NombreCompleto = sv.Empleado.Nombres + " " + sv.Empleado.Apellidos,
                        Cedula = sv.Empleado.Cedula,
                        FechaInicio = sv.FechaInicio, // ultima modificacion
                        FechaFin = sv.FechaFin, // ultima modificacion
                        DiasSolicitados = sv.DiasSolicitados,
                        Estado = sv.Estado,
                        FechaCreacion = sv.FechaCreacion

                    })
                    .ToListAsync();


            }
            catch(Exception ex) 
            {
                throw new NotImplementedException($"ERROR AL OBTENER SOLICITUDES POR ESTADO: {estado}", ex);

            }
        }
    }
}
