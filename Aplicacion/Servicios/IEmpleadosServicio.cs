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
<<<<<<< HEAD
        [OperationContract]
        Task<EmpleadoContratoDTO> ObtenerEmpleadoDTOPorCedulaAsync(string cedula);
=======
        [OperationContract] // este ObtenerEmpleadoDTOPorCedulaAsync
        Task<EmpleadoContratoDTO> ObtenerEmpleadoDTOPorCedulaAsync(string cedula);







>>>>>>> decf52b34256b32d9d8d3d03001c8758798e2e07

    }
   
}
