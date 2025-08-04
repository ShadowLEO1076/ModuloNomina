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
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aplicacion.ServiciosImpl
{
    public class NominasServicioIMPL : ServicioIMPL<Nominas>, INominasServicio
    {
        private INominasRepo _repo;
        private readonly NominaDBContext _context;

        IEmpleadosServicio empl;
        IBonificacionesServicio boni;
        IDescuentosServicio desc;
        IAsistenciasServicio asis;
        IInasistenciasServicio inasis;

        public NominasServicioIMPL(INominasRepo repo,
            NominaDBContext context, IEmpleadosServicio empl, 
            IBonificacionesServicio boni, IDescuentosServicio desc, IAsistenciasServicio asis, IInasistenciasServicio inasis) : base(context)
        {
            _repo = repo;
            _context = context;
            this.empl = empl;
            this.boni = boni;
            this.desc = desc;
            this.asis = asis;
            this.inasis = inasis;
        }

        public async Task IngresarNominasMesAutomatico(BusquedaDTO datos)
        {
            try 
            {
                var empleados = await empl.ObtenerTodosActivosAsync();
                foreach (var empleado in empleados) 
                {
                    NominasBusquedaDTO dato = new NominasBusquedaDTO
                    {
                        CedulaEmpleado = empleado.Cedula,
                        Mes = datos.mes,
                        Anio = datos.anio,
                    };

                    await IngresarNomionaAutomático(dato);
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Error - NominaServicioImp.IngresarNominasMesAutomatico : {ex.Message}");
            }
        }


        public async Task IngresarNomionaAutomático(NominasBusquedaDTO datos)
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
                    Anio = (short)datos.Anio,
                    Bonificaciones = calcBoni,
                    Descuentos = calcDesc,
                    FechaEmision = DateOnly.FromDateTime(DateTime.Today),
                    Mes = (byte)datos.Mes,
                    SalarioBase = empleContr.SalarioContra,
                    Estado = true
                };

                await _repo.AgregarAsync(nomi);
            }
            catch (Exception ex) 
            {
                throw new Exception($"Error - NominaServicioImp : {ex.Message}");
            }
        }

        public async Task<NominasDTO> ObtenerNominaPorEmpleadoMesAnioAsync(BusquedaDTO dto)
        {
            try 
            { 
                var busq = await _repo.ObtenerNominaPorEmpleadoMesAnioAsync(dto);             

                return busq;
            }
            catch (Exception ex) 
            {
                throw new Exception($"Error - NominasServicioImpl : no se pudo hallar datos. {ex.Message}");
            }
        }

        public async Task<List<NominasDTO>> ObtenerTodosActivosAsync()
        {
            try 
            {

                int diasIess = 30; //días que el IESS usa para dividir de manera máxima los días de trabajo
                int horasIess = 240; //horas usadas por el IEES para contabilizar el pago adecuado 


                var busq = await _repo.ObtenerTodosActivosAsync();

                foreach(NominasDTO dato in busq) 
                {
                    var busqueda = new NominasBusquedaDTO
                    {
                        CedulaEmpleado = dato.Cedula,
                        Anio = dato.Anio,
                        Mes = dato.Mes,
                    };

                    var horasTrabajadas = await asis.ObtenerAsistenciasPorCedulaMesAnio(busqueda);
                    var horasInasRemu = await inasis.ObtenerInasistenciasRemuneradasPorCedulaMesAnio(busqueda);

                    var calcHorasTrabajadas = asis.CalcularHorasTrabajadas(horasTrabajadas);
                    var calcHorasInasRemu = inasis.CalcularHorasInasistenciasRemuneradas(horasInasRemu);
                    var salarioPorHora = dato.Salario / horasIess;
                    //REDUNDANTE, pero util
                    var bonificaciones = dato.Bonificaciones;
                    var descuentos = dato.Descuentos;
                    dato.HorasLaboradas = calcHorasTrabajadas + calcHorasInasRemu;
                    //necesario para calculo por horas
                    double HorasLaboradasDouble = dato.HorasLaboradas.TotalHours;
                    decimal HorasLaboralesDecimal = (decimal)HorasLaboradasDouble;
                    dato.SalarioHorasLaboradas = salarioPorHora * HorasLaboralesDecimal;
                    //ACABA LA REDUNDANCIA

                    dato.SalarioNeto = ((dato.SalarioHorasLaboradas + bonificaciones - descuentos));
                }

                return busq;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error - NominasServicioImpl : no se pudo hallar datos. {ex.Message}");
            }
        }

       
    }
}
