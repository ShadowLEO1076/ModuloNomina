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
    public interface IEmpleadosServicio : IServicio<Empleados>
    {

        [OperationContract]
        Task<EmpleadoContratoDTO> ObtenerEmpleadoDTOPorCedulaAsync(string cedula);

        [OperationContract]
        public Task<Empleados> ObtenerEmpleadoPorCedulaAsync(string cedula);
        [OperationContract]
        Task<IEnumerable<Empleados>> ObtenerTodosActivosAsync();
        [OperationContract]
        Task<IEnumerable<Empleados>> ObtenerTodosInactivosAsync();
        [OperationContract]
        Task<bool> VerificarCorreoElectronico(string correo);

        /*
        [OperationContract] // este ObtenerEmpleadoDTOPorCedulaAsync
        Task<EmpleadoContratoDTO> ObtenerEmpleadoDTOPorCedulaAsync(string cedula);
        */
    }
   
}
