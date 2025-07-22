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
    public class NominasServicioIMPL : ServicioIMPL<Nominas>, INominasServicio
    {
        private INominasRepo _repo;
        private readonly NominaDBContext _context;

        IEmpleadosServicio empl;
        IBonificacionesServicio boni;
        IDescuentosServicio desc;

        public NominasServicioIMPL(INominasRepo repo,
            NominaDBContext context, IEmpleadosServicio empl, 
            IBonificacionesServicio boni, IDescuentosServicio desc) : base(context)
        {
            _repo = repo;
            _context = context;
            this.empl = empl;
            this.boni = boni;
            this.desc = desc;
        }

        public async Task IngresarNomionaAutomático(BusquedaDTO datos)
        {
            try 
            {
                
                var empleado = await empl.ObtenerEmpleadoPorCedulaAsync(datos.CedulaEmpleado);
                var empleContr = await empl.ObtenerEmpleadoDTOPorCedulaAsync(datos.CedulaEmpleado);
                var bonificaciones = await boni.ObtenerBonificacionesPorCedulaMesYAnio(datos);
                var descuentos = await desc.ObtenerDescuentosEmpleadoPorCedulaMesAnio(datos);

                var calcBoni = boni.CalcularDescuentosDeEmpleadoPorAnioYMes(bonificaciones);
                var calcDesc = desc.CalcularDescuentosDeEmpleadoPorAnioYMes(descuentos);

                var nomi = new Nominas
                {
                    EmpleadoId = empleado.IdEmpleado,
                    Anio = (short)datos.anio,
                    Bonificaciones = calcBoni,
                    Descuentos = calcDesc,
                    FechaEmision = DateOnly.FromDateTime(DateTime.Today),
                    Mes = (byte)datos.mes,
                    SalarioBase = empleContr.SalarioContra
                };

                await _repo.AgregarAsync(nomi);
            }
            catch (Exception ex) 
            {
                throw new Exception($"Error - NominaServicioImp : {ex.Message}");
            }
        }
    }
}
