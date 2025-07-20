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
    public class ContratosServicioIMPL : ServicioIMPL<Contratos>, IContratosServicio
    {
       
        private IContratosRepo _repo;
        private readonly NominaDBContext _context;
        public ContratosServicioIMPL(NominaDBContext context) : base(context)
        {
            _context = context;
            _repo = new ContratosRepositorioIMPL(context);
        }

        public async Task<bool> ActualizarEstadoContratoAsync(int idContrato, string nuevoEstado)
        {
            try
            {
                // Verificar si el contrato existe
                var contrato = await _repo.ObtenerPorIdAsync(idContrato);
                if (contrato == null)
                {
                    throw new Exception("Contrato no encontrado");
                }
                // Actualizar el estado del contrato
                contrato.Estado = nuevoEstado;
                // Guardar los cambios en la base de datos
                await _repo.ActualizarAsync(contrato);
                return true; // Retornar true si la actualización fue exitosass


            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al actualizar el estado del contrato", ex);
            }
        }

        public Task<IEnumerable<Contratos>> BuscarPorFechaAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                return _repo.BuscarPorFechaAsync(DateOnly.FromDateTime(fechaInicio), DateOnly.FromDateTime(fechaFin));
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar contratos por fecha", ex);
            }
        }

        public Task<List<ContratoDTO>> ObtenerContratosCompletosAsync()
        {
            try
            {
                return _repo.ObtenerContratosCompletosAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener contratos completos", ex);
            }
        }

        public Task<List<ContratoDTO>> ObtenerContratosPorEmpleadoAsync(string cedula)
        {
            try
            {
                return _repo.ObtenerContratosPorEmpleadoAsync(cedula);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener contratos por empleado", ex);
            }
        }
    }
}
