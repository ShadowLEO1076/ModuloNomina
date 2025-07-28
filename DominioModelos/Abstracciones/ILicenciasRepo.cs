using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.AccesoDatos;
namespace Dominio.Modelos.Abstracciones
{
    public interface ILicenciasRepo: IRepositorio<Licencias>
    {
        // especificas porque no nesecito las del crud 
        //Task<IEnumerable<Licencias>> ObtenerLicenciasRemunerablesAsync();

    }
}
