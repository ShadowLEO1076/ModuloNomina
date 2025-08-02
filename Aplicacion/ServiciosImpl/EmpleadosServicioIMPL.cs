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
    public class EmpleadosServicioIMPL : ServicioIMPL<Empleados>, IEmpleadosServicio
    {
        private IEmpleadosRepo _repo;
        private readonly NominaDBContext _context;

        public EmpleadosServicioIMPL(NominaDBContext context) : base(context)
        {
            _context = context;
            _repo = new EmpleadosRepositorioIMPL(context);
        }
        public async Task<Empleados> ObtenerEmpleadoPorCedulaAsync(string cedula)
        {
            try
            {
                return await _repo.ObtenerEmpleadoPorCedulaAsync(cedula);
            }
            catch (Exception ex)
            {
                {
                    throw new Exception($"Error - EmpleadosServicioImpl : no se pudo hallar al empleado con la cédula {cedula}. {ex.Message}");
                }
            }
        }

        public async Task<EmpleadoContratoDTO> ObtenerEmpleadoDTOPorCedulaAsync(string cedula)
        {
            try
            {
                return await _repo.ObtenerEmpleadoDTOPorCedulaAsync(cedula);
            }
            catch (Exception ex)
            {
                {
                    throw new Exception($"Error - EmpleadosServicioImpl : no se pudo hallar al empleado con la cédula {cedula}. {ex.Message}");
                }
            }
        }

        public async Task<IEnumerable<Empleados>> ObtenerTodosActivosAsync()
        {
            try
            {
                return await _repo.ObtenerTodosActivosAsync();
            }
            catch (Exception ex)
            {
                {
                    throw new Exception($"Error - EmpleadosServicioImpl : no se puedieron hallar los datos. {ex.Message}");
                }
            }
        }

        public async Task<IEnumerable<Empleados>> ObtenerTodosInactivosAsync()
        {
            try
            {
                return await _repo.ObtenerTodosInactivosAsync();
            }
            catch (Exception ex)
            {
                {
                    throw new Exception($"Error - EmpleadosServicioImpl : no se puedieron hallar los datos. {ex.Message}");
                }
            }
        }

        public async Task<List<EmpleadoConSalarioDTO>> ListarEmpleadosConSalarioAsync()
        {
            try
            {
                return await _repo.ListarEmpleadosConSalarioAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"Error - EmpleadosServicioImpl : no se puedieron hallar los datos. {ex.Message}");
            }


        }
    }
}
