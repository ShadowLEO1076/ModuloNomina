using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTO.DTOs
{
    public class NominasDTO
    {
        //datos esenciales para nomina
        public int IdNomina { get; set; }
        public int IdEmpleado { get; set; }
        //datos que se pueden conseguir en la base

        public string NombresApellidos { get; set; }

        public string Cedula { get; set; }

        public decimal Salario { get; set; }
        public int? HorasJornada { get; set; } //necesario para calcular mi salario hora

        public TimeOnly HorasLaboradas { get; set; }    

        public decimal Bonificaciones { get; set; }

        public decimal Descuentos { get; set; }

        public DateOnly FechaEmision { get; set; }
        public byte Mes { get; set; }

        public short Anio { get; set; }

       //datos calulados
       public decimal SalarioNeto { get; set; }

    }
}
