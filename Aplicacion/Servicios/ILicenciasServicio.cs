using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.AccesoDatos;


namespace Aplicacion.Servicios
{
    internal interface ILicenciasServicio: IService<Licencias>
    {
        Task<IEnumerable<Licencias>> ObtenerLicenciasPorEmpleadoAsync(int empleadoId);
        Task<Licencias> ObtenerLicenciaPorIdAsync(int licenciaId);
        Task<bool> SolicitarLicenciaAsync(Licencias licencia);
        Task<bool> AprobarLicenciaAsync(int licenciaId, bool aprobar);
        Task<bool> CancelarLicenciaAsync(int licenciaId);
    }
    {
    }
}
