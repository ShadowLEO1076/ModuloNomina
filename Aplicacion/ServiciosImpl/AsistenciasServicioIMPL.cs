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
    public class AsistenciasServicioIMPL : ServicioIMPL<Asistencias>, IAsistenciasServicio
    {
        private readonly IAsistenciasRepo _repo;
        private readonly NominaDBContext _db;

        public AsistenciasServicioIMPL(IAsistenciasRepo repo, NominaDBContext db) : base(db)
        {
            _repo = repo;
            _db = db;
        }

        public async Task<IEnumerable<Asistencias>> BuscarPorCedulaAsync(string cedula)
        {
            try
            {
                return await _repo.BuscarPorCedulaAsync(cedula);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error - AsistenciasServicioImpl : no se pudo hallar los datos. {ex.Message}");
            }
        }

        public async Task<List<AsistenciasEmpleadoDTO>> ObtenerAsistenciasPorCedulaMesAnio(BusquedaDTO busquedaDTO)
        {
            try
            {
                return await _repo.ObtenerAsistenciasPorCedulaMesAnio(busquedaDTO);
            }
            catch (Exception ex) 
            {
                throw new Exception($"Error - AsistenciasServicioImpl : no se pudo hallar los datos. {ex.Message}");
            }
        }

        public async Task<IEnumerable<AsistenciasFormDTO>> ObtenerTodasActivasAsistenciasFormDTO()
        {
            try 
            { 
                var busq = _repo.ObtenerTodasActivasAsistenciasFormDTO();
                return await busq;
            }
            catch(Exception ex)
            {
                throw new Exception($"Error - AsistenciasServiceImple : no se pudieron hallar los datos necesarios");
            }
        }
    }
}
