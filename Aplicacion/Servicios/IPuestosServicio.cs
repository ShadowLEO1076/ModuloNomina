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
    public interface IPuestosServicio: IServicio<Puestos>
    {
        [OperationContract] // EMP`LEADO PUESTO 
        Task<IEnumerable<PuestosEmpleadoDTO>> BuscarPorPuestoAsync(string puestoNombre);



    }
}
