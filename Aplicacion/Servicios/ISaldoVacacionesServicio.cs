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
    public interface ISaldoVacacionesServicio : IServicio<SaldoVacaciones>
    {
        [OperationContract]
        Task AsignarDiasVacacionesAutomaticamenteAsync();
        [OperationContract]
        Task<SaldoVacaciones> BuscarPorEmpleadoIdAsync(int empleadoId);

    }
}
