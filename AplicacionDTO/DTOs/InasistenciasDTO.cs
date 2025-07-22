using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTO.DTOs
{
    public class InasistenciasDTO
    {
        public bool Remunerable { get; set; }

        public DateOnly Fecha { get; set; }

        public int DiasContados { get; set; }
    }
}
