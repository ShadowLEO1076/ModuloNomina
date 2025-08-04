using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTO.DTOs
{
    public class InasistenciasFormDTO
    {
        public int IdInasistencias { get; set; }
        public int EmpleadoId { get; set; }
        public string NombresApellidos { get; set; }
        public string Cedula { get; set; }
        public DateOnly Fecha { get; set; }
        public int LicenciaId { get; set; }
        public string NombreLicencia { get; set; }
        public bool Remunerable { get; set; }
    }
}
