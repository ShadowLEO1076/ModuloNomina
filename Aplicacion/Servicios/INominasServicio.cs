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
    public interface INominasServicio :IServicio<Nominas>
    {
        [OperationContract]
        public Task IngresarNominasMesAutomatico(BusquedaDTO datos);
        [OperationContract]
        public Task IngresarNomionaAutomático(NominasBusquedaDTO datos);
        [OperationContract]
        Task<NominasDTO> ObtenerNominaPorEmpleadoMesAnioAsync(BusquedaDTO dto);
        [OperationContract]
        Task<List<NominasDTO>> ObtenerTodosActivosAsync();
    }
}
