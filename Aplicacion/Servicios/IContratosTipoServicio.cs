using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.AccesoDatos;


namespace Aplicacion.Servicios
{
    public interface IContratosTipoServicio: IServicio<ContratosTipoServicio>
    {
        Task<IEnumerable<ContratosTipoServicio>> ObtenerPorContratoAsync(int contratoId);
        Task<IEnumerable<ContratosTipoServicio>> ObtenerPorTipoServicioAsync(int tipoServicioId);
        Task<IEnumerable<ContratosTipoServicio>> ObtenerPorContratoYTipoServicioAsync(int contratoId, int tipoServicioId);
    }
    {
    }
}
