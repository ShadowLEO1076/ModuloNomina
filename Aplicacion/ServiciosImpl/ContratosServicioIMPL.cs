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

        public async Task<int> FinalizarContratosVencidosAsync()
        {
            var fechaActual = DateTime.Now;

            var contratosVencidos = await _repo.ObtenerContratosVencidosAsync();

            foreach (var contrato in contratosVencidos)
            {
                contrato.Estado = "Finalizado";
                contrato.FechaModificacion = DateTime.Now; // si usas esto
                await _repo.ActualizarAsync(contrato);
            }

            return contratosVencidos.Count;
        }

        public async Task ActualizarContratoAsync(ContratoDTO contratoDto)
        {
            // Obtener el contrato actual desde la base de datos
            var contrato = await _repo.ObtenerPorIdAsync(contratoDto.IdContrato);

            if (contrato == null)
                throw new Exception($"No se encontró el contrato con ID {contratoDto.IdContrato}");

            // Actualizar las propiedades del contrato
            contrato.EmpleadoId = contratoDto.EmpleadoId;
            contrato.TipoId = contratoDto.IdContrato;
            contrato.FechaInicio = contratoDto.FechaInicio ?? DateOnly.MinValue;
            contrato.JornadaHoraInicio = contratoDto.JornadaHoraInicio;// modificacion 
            contrato.JornadaHoraFin = contratoDto.JornadaHoraFin;// modificacion 
           // contrato.FechaFin = contratoDto.FechaFin;
            contrato.Salario = contratoDto.Salario;
           // contrato.HorasJornada = contratoDto.HorasJornada;
            contrato.Estado = contratoDto.Estado;
            contrato.FechaCreacion = contratoDto.FechaCreacion;
            contrato.FechaModificacion = DateTime.Now;

            // Guardar cambios
            await _repo.ActualizarAsync(contrato);
        }

        public Task AgregarAsync(ContratosHistorico contratosHistorico)
        {
            throw new NotImplementedException();
        }

        public Task ActualizarAsync(ContratosHistorico contratosHistorico)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contratos>> BuscarPorFechaAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
