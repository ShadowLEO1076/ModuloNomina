using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTO.DTOs;
using Dominio.Modelos.Abstracciones;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class AprobacionVacacionesRepocitorioIMPL : RepositorioImpl<AprobacionVacaciones>, IAprobacionVacacionesRepo
    {
        private readonly NominaDBContext _context;
        public AprobacionVacacionesRepocitorioIMPL(NominaDBContext context) : base(context)
        {
            _context = context;
        }
   
       


        
    }
}
