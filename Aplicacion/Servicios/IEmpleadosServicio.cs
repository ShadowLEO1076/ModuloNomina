using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTO.DTOs;
using Infraestructura.AccesoDatos;

namespace Aplicacion.Servicios
{
    [ServiceContract]
    public interface IEmpleadosServicio: IServicio<Empleados>
    {
        [OperationContract] // este ObtenerEmpleadoDTOPorCedulaAsync
        Task<EmpleadoContratoDTO> ObtenerEmpleadoDTOPorCedulaAsync(string cedula);








    }
   
}
