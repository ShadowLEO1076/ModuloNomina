using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTO.DTOs
{
    //este método ES usado tanto en asistencia como inasistencia, 
    //usado para asegurarnos que los ingresos en el MVC no se repitan
    
    //el uso de id es más por conveniencia que por otra cosa, ahorra usar cédula. :D
    public class VerificarAsisInasisDTO
    {
        public int idEmpleado {  get; set; }

        public DateOnly fechaVerificacion { get; set; }
    }
}
