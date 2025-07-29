using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTO.DTOs;
using Infraestructura.AccesoDatos;

namespace Dominio.Modelos.Abstracciones
{
    public interface INominasRepo : IRepositorio<Nominas>
    {
        Task<NominasDTO> ObtenerNominaPorEmpleadoMesAnioAsync(BusquedaDTO dto);
        Task<List<NominasDTO>> ObtenerTodosActivosAsync();
    }
}
