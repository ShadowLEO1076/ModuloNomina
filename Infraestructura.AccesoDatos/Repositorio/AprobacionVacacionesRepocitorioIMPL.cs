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
    public class AprobacionVacacionesRepocitorioIMPL : RepositorioImpl<AprobacionVacaciones>, IAprobacionVacacionesRepo
    {
        private readonly NominaDBContext _context;
        public AprobacionVacacionesRepocitorioIMPL(NominaDBContext context) : base(context)
        {
            _context = context;
        }
   
        public async Task<IEnumerable<VacacionesAprovadasGestionDTO>> ResumenDiasAprovadosDiasUsadosAsync(string cedula)
        {
            // VOY A APROVECHAR EL DTO PARA USAR CAMPOS DE DIFERENTES TABLAS
            try
            {
                var resumen = await _context.AprobacionVacaciones
                    .Where(av => av.Solicitud.Empleado.Cedula == cedula) // FILTRO POR CÉDULA DEL EMPLEADO
                    .Select(av => new VacacionesAprovadasGestionDTO // CREO UN DTO PARA RESUMEN
                    {
                        Cedula = av.Solicitud.Empleado.Cedula, 
                        NombreCompleto = av.Solicitud.Empleado.Nombres +" "+ av.Solicitud.Empleado.Apellidos,
                        FechaAprobacion = av.FechaAprobacion,
                        DiasOtorgados = av.Solicitud.Empleado.EmpleadosVacacionesTotales.DiasOtorgados,
                        Estado = av.Solicitud.Estado,
                        DiasUsados = av.Solicitud.Empleado.EmpleadosVacacionesTotales.DiasUsados,
                    }).ToListAsync();
                return resumen;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el resumen de vacaciones aprobadas", ex);
            }


        }
    }
}
