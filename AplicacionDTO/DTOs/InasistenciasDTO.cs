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

        //este dato lo necesito de Tipo Contrato
        public int? JornadaLaboral {  get; set; }

    }
}
