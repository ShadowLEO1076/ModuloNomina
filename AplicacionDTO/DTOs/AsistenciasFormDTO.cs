using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTO.DTOs
{
    //DTO sin listas anidadas para ser usada en el Windows Form
    public class AsistenciasFormDTO
    {
        public int IdAsistencia { get; set; }
        public int EmpleadoId { get; set; }
        public string NombresApellidos { get; set; }
        public string Cedula { get; set; }
        public DateOnly Fecha { get; set; }

        public TimeOnly? HoraEntrada { get; set; }

        public TimeOnly? HoraSalida { get; set; }
    }
}
