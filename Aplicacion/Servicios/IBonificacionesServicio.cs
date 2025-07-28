using Aplicacion.DTO.DTOs;
using Infraestructura.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Servicios
{
    [ServiceContract]
    public interface IBonificacionesServicio : IServicio<Bonificaciones>
    {
        [OperationContract]
        Task<List<BonificacionesEmpleadoDTO>> ObtenerBonificacionesPorCedulaMesYAnio(BusquedaDTO datos);

        [OperationContract]
        public decimal CalcularDescuentosDeEmpleadoPorAnioYMes(List<BonificacionesEmpleadoDTO> lista);

        [OperationContract]
        Task<IEnumerable<BonificacionesFormDTO>> ObtenerTodasActivasBonificacionesFormDTO();


        // Aquí puedes definir métodos específicos para el servicio de bonificaciones
        // Por ejemplo:
        // Task<IEnumerable<Bonificaciones>> ObtenerBonificacionesPorEmpleadoAsync(int empleadoId);
        // Task<Bonificaciones> CalcularBonificacionAsync(int empleadoId, DateTime fecha);
    }


}
