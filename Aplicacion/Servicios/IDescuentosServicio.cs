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
    public interface IDescuentosServicio: IServicio<Descuentos>
    {
        [OperationContract]
        Task<List<DescuentosEmpleadoDTO>> ObtenerDescuentosEmpleadoPorCedulaMesAnio(BusquedaDTO busqueda);
        [OperationContract]
        public decimal CalcularDescuentosDeEmpleadoPorAnioYMes(List<DescuentosEmpleadoDTO> lista);



    }
}
