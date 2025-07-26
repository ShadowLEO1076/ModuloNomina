using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTO.DTOs;
using Aplicacion.Servicios;
using Dominio.Modelos.Abstracciones;
using Infraestructura.AccesoDatos;
using Infraestructura.AccesoDatos.Repositorio;

namespace Aplicacion.ServiciosImpl
{
    public class AprobacionVacacionesServicioIMPL : ServicioIMPL<AprobacionVacaciones>, IAprobacionVacacionesServicio
    {

        private IAprobacionVacacionesRepo _repo;
        private readonly NominaDBContext _context;
        public AprobacionVacacionesServicioIMPL(NominaDBContext context) : base(context)
        {
            _context = context;
            _repo = new AprobacionVacacionesRepocitorioIMPL(context);
        }

       
    }
}
