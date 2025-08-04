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
    public class SaldoVacacionesServicioIMPL : ServicioIMPL<SaldoVacaciones>, ISaldoVacacionesServicio
    {
        private ISaldoVacacionesRepo _repo;
        private readonly NominaDBContext _context;
        private readonly IEmpleadosRepo _empleadoRepo;
        public SaldoVacacionesServicioIMPL(NominaDBContext context) : base(context)
        {
            _context = context;
            _repo = new SaldoVacacionesRepositorioIMPL(context);
            _empleadoRepo = new EmpleadosRepositorioIMPL(context);
        }
        public async Task AsignarDiasVacacionesAutomaticamenteAsync()
        {
            // Obtiene todos los empleados del sistema
            var empleados = await _empleadoRepo.ObtenerTodosAsync();
            var hoy = DateOnly.FromDateTime(DateTime.Now); // Fecha actual sin la parte de la hora

            foreach (var empleado in empleados)
            {
                // Obtiene el saldo de vacaciones actual del empleado.
                // Si no existe, significa que es la primera vez que se procesa a este empleado.
                var saldo = await _repo.BuscarPorEmpleadoIdAsync(empleado.IdEmpleado);

                // Obtiene el mes y día de la fecha de ingreso del empleado para calcular los aniversarios.
                DateOnly baseAniversario = empleado.FechaIngreso;

                // CORRECCIÓN: Determina el último año para el que se asignaron vacaciones.
                int ultimoAnioAsignado;
                if (saldo != null)
                {
                    // Para empleados existentes, usa el último año asignado o año anterior al ingreso
                    ultimoAnioAsignado = saldo?.FechaUltimaAsignacion?.Year ?? baseAniversario.Year - 1;
                }
                else
                {
                    // Para empleados nuevos, comienza desde el año de ingreso (no asignará vacaciones hasta el siguiente año)
                    ultimoAnioAsignado = baseAniversario.Year;
                }

                // Itera desde el año siguiente al último asignado hasta el año actual.
                for (int anioAProcesar = ultimoAnioAsignado + 1; anioAProcesar <= hoy.Year; anioAProcesar++)
                {
                    DateOnly aniversarioEsteAnio;
                    try
                    {
                        // Calcula la fecha exacta del aniversario para el año actual en iteración.
                        aniversarioEsteAnio = new DateOnly(anioAProcesar, baseAniversario.Month, baseAniversario.Day);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        // Manejo de caso especial para el 29 de febrero en años no bisiestos.
                        if (baseAniversario.Month == 2 && baseAniversario.Day == 29 && !DateTime.IsLeapYear(anioAProcesar))
                        {
                            aniversarioEsteAnio = new DateOnly(anioAProcesar, 3, 1);
                        }
                        else
                        {
                            continue;
                        }
                    }

                    // Solo asigna vacaciones si el aniversario para 'anioAProcesar' ha pasado o es hoy.
                    if (aniversarioEsteAnio <= hoy)
                    {
                        if (saldo == null)
                        {
                            // Solo creará el saldo cuando realmente corresponda asignar vacaciones (después de 1 año)
                            saldo = new SaldoVacaciones
                            {
                                IdEmpleado = empleado.IdEmpleado,
                                DiasAcumulados = 15, // Asigna los primeros 15 días
                                FechaUltimaAsignacion = aniversarioEsteAnio,
                                DiasUsadosAnioActual = 0,
                                AnioActual = hoy.Year
                            };
                            await _repo.AgregarAsync(saldo);
                        }
                        else
                        {
                            if (anioAProcesar > saldo.FechaUltimaAsignacion.Value.Year)
                            {
                                saldo.DiasAcumulados = Math.Min(saldo.DiasAcumulados + 15, 45);
                                saldo.FechaUltimaAsignacion = aniversarioEsteAnio;
                                await _repo.ActualizarAsync(saldo);
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                // Lógica para reiniciar los días usados anualmente (límite de 30 días).
                if (saldo != null && saldo.AnioActual < hoy.Year)
                {
                    saldo.DiasUsadosAnioActual = 0;
                    saldo.AnioActual = hoy.Year;
                    await _repo.ActualizarAsync(saldo);
                }
            }
        }





        public async Task<SaldoVacaciones> BuscarPorEmpleadoIdAsync(int empleadoId)
        {
            var entidad = await _repo.BuscarPorEmpleadoIdAsync(empleadoId);
            if (entidad == null) return null;

            return new SaldoVacaciones
            {
                Id = entidad.Id,
                IdEmpleado = entidad.IdEmpleado,
                DiasAcumulados = entidad.DiasAcumulados,
                DiasUsadosAnioActual = entidad.DiasUsadosAnioActual,
                FechaUltimaAsignacion = entidad.FechaUltimaAsignacion
            };
        }
    }
}

