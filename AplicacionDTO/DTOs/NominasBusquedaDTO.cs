using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTO.DTOs
{
    //usada para todo lo que es nómina, NO TOCAR
    public class NominasBusquedaDTO
    {
        public string? CedulaEmpleado {  get; set; }
        public int Mes { get; set; }

        public int Anio { get; set; }
    }
}
