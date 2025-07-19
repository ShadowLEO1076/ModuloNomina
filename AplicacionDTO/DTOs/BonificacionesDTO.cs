using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTO.DTOs
{
    // creado para bonificaciones empleado DTO
    public class BonificacionesDTO
    {

        public string Tipo { get; set; }

        public string Descripcion { get; set; }

        public decimal Monto { get; set; }

        public DateOnly Fecha { get; set; }

    }
}
