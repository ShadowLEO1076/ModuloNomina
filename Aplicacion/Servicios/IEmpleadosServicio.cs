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
        [OperationContract]
<<<<<<< HEAD
        Task<EmpleadoContratoDTO> ObtenerEmpleadoDTOPorCedulaAsync(string cedula);
=======
        Task<EmpleadoDTO> ObtenerEmpleadoDTOPorCedulaAsync(Empleados empleado);
       


>>>>>>> b21c18f976a1a96643dbd1ec730ad682cb8ba5fa


    }
   
}
/*
         * --> método de Guille
        // por cedula
        [OperationContract]
        Task<Empleados> ObtenerEmpleadoPorCedulaAsync(string cedula);
        */