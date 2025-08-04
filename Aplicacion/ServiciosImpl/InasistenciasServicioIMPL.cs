using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTO.DTOs;
using Aplicacion.Servicios;
using Dominio.Modelos.Abstracciones;
using Infraestructura.AccesoDatos;
using Infraestructura.AccesoDatos.Repositorio;

namespace Aplicacion.ServiciosImpl
{
    public class InasistenciasServicioIMPL : ServicioIMPL<Inasistencias>, IInasistenciasServicio
    {
        private readonly IInasistenciasRepo _repo;
        private readonly NominaDBContext _dbContext;
        private readonly IEmpleadosRepo _empleadosRepositorio;
        private readonly IDescuentosRepo _descuentosRepositorio;
        private readonly IInasistenciasRepo _inasistenciasRepositorio;

        public InasistenciasServicioIMPL(IInasistenciasRepo repo, NominaDBContext dbContext, IInasistenciasRepo repo1, IEmpleadosRepo repo2, IDescuentosRepo repo3) : base(dbContext)
        {


            _repo = repo;
            _dbContext = dbContext;
            _empleadosRepositorio = repo2;
            _inasistenciasRepositorio = repo1;
            _descuentosRepositorio = repo3;

        }

        public async Task<IEnumerable<Inasistencias>> BuscarPorCedulaAsync(string cedula)
        {
            try 
            {
                return await _repo.BuscarPorCedulaAsync(cedula);
            }
            catch (Exception ex) 
            {
                throw new Exception($"Error - InasistenciasServicioImpl : {ex.Message}");
            }
        }

        public async Task<Inasistencias> BuscarPorIdYFecha(VerificarAsisInasisDTO dato)
        {
            try
            {
                return await _repo.BuscarPorIdYFecha(dato);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error - InasistenciasServicioImpl : {ex.Message}");
            }
        }

        public async Task<List<DescuentoPorInasistenciaDTO>> CalcularDescuentosPorInasistencias(BusquedaDTO busquedaDTO)
        {
            // 1. Obtener las inasistencias no remunerables por mes y año a través del repositorio de inasistencias
            var inasistenciasPorEmpleado = await _inasistenciasRepositorio.ObtenerInasistenciasPorMesAnio(busquedaDTO);

            // 2. Obtener la lista de empleados con sus salarios a través del repositorio de empleados
            var empleadosConSalario = await _empleadosRepositorio.ListarEmpleadosConSalarioAsync();

            // 3. Crear un diccionario para un acceso rápido al salario por IdEmpleado
            var salariosPorId = empleadosConSalario.ToDictionary(e => e.IdEmpleado, e => e.SalarioBase);

            // 4. Calcular los descuentos
            var descuentos = new List<DescuentoPorInasistenciaDTO>();

            foreach (var inasistenciaEmpleado in inasistenciasPorEmpleado)
            {
                int cantidadInasistencias = inasistenciaEmpleado.inasistencias.Count;

                if (salariosPorId.TryGetValue(inasistenciaEmpleado.IdEmpleado, out decimal salarioBase))
                {
                    decimal costoPorDia = salarioBase / 30;
                    decimal descuentoTotal = costoPorDia * cantidadInasistencias;

                    descuentos.Add(new DescuentoPorInasistenciaDTO
                    {
                        IdEmpleado = inasistenciaEmpleado.IdEmpleado,
                        NombresCompletos = inasistenciaEmpleado.NombresCompletos,
                        CedulaEmpleado = inasistenciaEmpleado.CedulaEmpleado,
                        SalarioBase = salarioBase,
                        CantidadInasistenciasNoRemunerables = cantidadInasistencias,
                        DescuentoTotal = descuentoTotal
                    });
                }
            }

            return descuentos;
        }
        public async Task<List<DescuentoPorInasistenciaDTO>> CalcularYGuardarDescuentos(BusquedaDTO busquedaDTO)
        {
            // Reutiliza este método Mate que solo calcula
            // Este método devolverá una lista de DescuentoCalculadoDTO con datos de todos los descuentos por inasistencia
            var descuentosCalculadosDTO = await CalcularDescuentosPorInasistencias(busquedaDTO);

            // luego  Mapeas y puedes usar la lista en tu logica  si hay descuentos
            if (descuentosCalculadosDTO.Any())
            {
                var descuentosParaGuardar = descuentosCalculadosDTO.Select(d => new Descuentos
                {
                    EmpleadoId = d.IdEmpleado,
                    Monto = d.DescuentoTotal, // Asigna DescuentoTotal a Monto

                    // Asigna estos campos aquí, justo antes de guardar:
                    Tipo = "Descuento por Inasistencia", // Valor fijo, o de alguna configuración
                    Descripcion = $"Descuento por {d.CantidadInasistenciasNoRemunerables} inasistencia(s) no remunerable(s) de {d.NombresCompletos} en {busquedaDTO.mes}/{busquedaDTO.anio}.", // Descripción dinámica
                    Estado = true, // O "Pendiente", según tu flujo
                    Fecha = new DateOnly(busquedaDTO.anio, busquedaDTO.mes, DateTime.DaysInMonth(busquedaDTO.anio, busquedaDTO.mes)),
                    /*Mes = busquedaDTO.mes,
                    Anio = busquedaDTO.anio*/
                    // No mapeas Id (IdDescuento) aquí, porque la DB lo generará automáticamente
                }).ToList();

                await _descuentosRepositorio.AddRangeAsync(descuentosParaGuardar); // Usa tu repositorio genérico
            }

            return descuentosCalculadosDTO; // Devuelve la lista de los DTOs calculados (para visualización si quieres)
        }





        public async Task<List<InasistenciasEmpleadoDTO>> ObtenerInasistenciasPorCedulaMesAnio(BusquedaDTO busquedaDTO)
        {
            try
            {
                return await _repo.ObtenerInasistenciasPorCedulaMesAnio(busquedaDTO);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error - InasistenciasServicioImpl : {ex.Message}");
            }
        }

        public async Task<List<InasistenciasEmpleadoDTO>> ObtenerInasistenciasPorMesAnio(BusquedaDTO busquedaDTO)
        {
            try
            {
                return await _repo.ObtenerInasistenciasPorMesAnio(busquedaDTO);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error - InasistenciasServicioImpl : {ex.Message}");
            }
        }
        public async Task<IEnumerable<InasistenciasFormDTO>> ObtenerTodasActivasInasistenciasFormDTO()
        {
            try
            {
                return await _repo.ObtenerTodasActivasInasistenciasFormDTO();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error - InasistenciasServicioImpl : {ex.Message}");
            }
        }

    }
}
