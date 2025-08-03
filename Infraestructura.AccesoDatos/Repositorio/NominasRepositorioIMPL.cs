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
    public class NominasRepositorioIMPL : RepositorioImpl<Nominas>, INominasRepo
    {
        private readonly NominaDBContext _context;
        public NominasRepositorioIMPL(NominaDBContext context) : base(context)
        {
            _context = context;
        }

        public Task<NominasDTO> ObtenerNominaPorEmpleadoMesAnioAsync(BusquedaDTO dto)
        {

            try
            {
                var hoy = DateOnly.FromDateTime(DateTime.Today);
                var busq =
                    _context.Nominas.Include(n => n.Empleado)
                    .ThenInclude(e => e.Contratos).
                    Where(n => (n.Empleado.Estado == true) &&  && (n.Mes == dto.mes) && (n.Anio == dto.anio) && (n.FechaEmision.Month == dto.mes) 
                    && (n.FechaEmision.Year == dto.anio) && (n.Estado == true))
                    .Select(n => new NominasDTO
                    {
                        IdNomina = n.IdNomina,
                        IdEmpleado = n.EmpleadoId,
                        Descuentos = n.Descuentos,
                        NombresApellidos = n.Empleado.Nombres + " " + n.Empleado.Apellidos,
                        Cedula = n.Empleado.Cedula,
                        Bonificaciones = n.Bonificaciones,
                        FechaEmision = n.FechaEmision,
                        Mes = n.Mes,
                        Anio = n.Anio,
                        Salario = n.SalarioBase,


                       /* HorasJornada = n.Empleado.Contratos.Where(c => (c.FechaInicio <= hoy) && (c.FechaFin >= hoy)) comento esto mateo ya no existe horas jornada en contratos 

                                    .OrderByDescending(c => c.FechaInicio)
                                    .Select(c => c.HorasJornada).FirstOrDefault(),*/

                        SalarioNeto = (n.SalarioBase) + n.Bonificaciones - n.Descuentos
                    }).FirstOrDefaultAsync();

                return await busq;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error - NominaRepositorioImpl : Error al traer datos. {ex.Message}");
            }


        }

        /*
public async Task<NominasDTO> ObtenerNominaPorEmpleadoMesAnioAsync()
{/* try
   {
      var hoy = DateOnly.FromDateTime(DateTime.Today);
       var busq =
           _context.Nominas.Include(n => n.Empleado)
           .ThenInclude(e => e.Contratos).
           Where(n => (n.Empleado.Estado == true) && (n.Empleado.Cedula == dto.CedulaEmpleado) && (n.Mes == dto.mes) && (n.Anio == dto.anio) && (n.FechaEmision.Month == dto.mes) 
           && (n.FechaEmision.Year == dto.anio) && (n.Estado == true))
           .Select(n => new NominasDTO
           {
               IdNomina = n.IdNomina,
               IdEmpleado = n.EmpleadoId,
               Descuentos = n.Descuentos,
               NombresApellidos = n.Empleado.Nombres + " " + n.Empleado.Apellidos,
               Cedula = n.Empleado.Cedula,
               Bonificaciones = n.Bonificaciones,
               FechaEmision = n.FechaEmision,
               Mes = n.Mes,
               Anio = n.Anio,
               Salario = n.SalarioBase,

              /* HorasJornada = n.Empleado.Contratos.Where(c => (c.FechaInicio <= hoy) && (c.FechaFin >= hoy)) comento esto mateo ya no existe horas jornada en contratos 
                           .OrderByDescending(c => c.FechaInicio)
                           .Select(c => c.HorasJornada).FirstOrDefault(),

               SalarioNeto = (n.SalarioBase) + n.Bonificaciones - n.Descuentos
           }).FirstOrDefaultAsync();

       return await busq;
   }
   catch (Exception ex)
   {
       throw new Exception($"Error - NominaRepositorioImpl : Error al traer datos. {ex.Message}");
   }

}*/

        public async Task<List<NominasDTO>> ObtenerTodosActivosAsync()
        {
            try
            {
                var hoy = DateOnly.FromDateTime(DateTime.Today);

                var busq = await
                    _context.Nominas.Include(n => n.Empleado)
                    .ThenInclude(e => e.Contratos).Where(n => n.Empleado.Estado == true && (n.Estado == true))
                    .Select(n => new NominasDTO
                    {
                        IdNomina = n.IdNomina,
                        IdEmpleado = n.EmpleadoId,
                        NombresApellidos = n.Empleado.Nombres + " " + n.Empleado.Apellidos,
                        Cedula = n.Empleado.Cedula,
                        Bonificaciones = n.Bonificaciones,
                        Descuentos = n.Descuentos,
                        Mes = n.Mes,
                        Anio = n.Anio,
                        FechaEmision = n.FechaEmision,
                        Salario = n.SalarioBase,


                        /*HorasJornada = n.Empleado.Contratos.Where(c => (c.FechaInicio <= hoy) && (c.FechaFin >= hoy))

                                    .OrderByDescending(c => c.FechaInicio)
                                    .Select(c => c.HorasJornada).FirstOrDefault(),*/   //Ya no existe horas jornada 

                        SalarioNeto = n.SalarioBase + n.Bonificaciones - n.Descuentos
                    }).ToListAsync();

                Console.WriteLine(busq);
                return busq;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error - NominaRepositorioImpl : Error al traer datos. {ex.Message}");
            }
        }
    }
}
