using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTO.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "La cédula es requerida")]
        [StringLength(20, MinimumLength = 3)]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Contraseña { get; set; }
    }
}


