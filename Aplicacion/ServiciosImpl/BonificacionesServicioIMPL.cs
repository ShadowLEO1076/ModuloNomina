using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTO.DTOs;
using Aplicacion.Servicios;
using Dominio.Modelos.Abstracciones;
using Infraestructura.AccesoDatos;
using Infraestructura.AccesoDatos.Repositorio;

namespace Aplicacion.ServiciosImpl
{
    public class BonificacionesServicioIMPL : ServicioIMPL<Bonificaciones>, IBonificacionesServicio
    {
        private readonly IBonificacionesRepo _serv;
        private readonly NominaDBContext _dbContext;

        public BonificacionesServicioIMPL(IBonificacionesRepo serv, NominaDBContext dbContext) : base(dbContext)
        {
            _serv = serv;
            _dbContext = dbContext;
        }

        public decimal CalcularDescuentosDeEmpleadoPorAnioYMes(List<BonificacionesEmpleadoDTO> lista)
        {
            decimal totalValor = 0;

            foreach (BonificacionesEmpleadoDTO empleado in lista)
            {
                foreach (BonificacionesDTO boni in empleado.bonificaciones)
                {
                    totalValor = boni.Monto + totalValor;
                }
            }

            return totalValor;
        }
        

        public async Task<List<BonificacionesEmpleadoDTO>> ObtenerBonificacionesPorCedulaMesYAnio(BusquedaDTO datos)
        {
            try
            {
                return await _serv.ObtenerBonificacionesPorCedulaMesYAnio(datos);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error - BonificacionesServicioImpl : no se puede hallar los datos con cédula {datos.CedulaEmpleado}. {ex.Message}");
            }
        }

        public async Task<IEnumerable<BonificacionesFormDTO>> ObtenerTodasActivasBonificacionesFormDTO()
        {
            try 
            {
                return await _serv.ObtenerTodasActivasBonificacionesFormDTO();
            }
            catch (Exception ex) 
            {
                throw new Exception($"Error - BonificacionesServiceImpl : no se  puede hallar los datos. {ex.Message}");
            }
        }
    }
}
