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

        public InasistenciasServicioIMPL(IInasistenciasRepo repo, NominaDBContext dbContext) : base(dbContext)
        {


            _repo = repo;
            _dbContext = dbContext;

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
