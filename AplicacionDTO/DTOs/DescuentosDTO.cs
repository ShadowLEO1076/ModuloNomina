using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTO.DTOs
{
    public class DescuentosDTO
    {
        public string Tipo { get; set; }

        public string Descripcion { get; set; }

        public decimal Monto { get; set; }

        public DateOnly Fecha { get; set; }
    }
}
