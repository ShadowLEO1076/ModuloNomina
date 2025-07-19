using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Modelos.Abstracciones;
using Infraestructura.AccesoDatos;
using Infraestructura.AccesoDatos.Repositorio;

namespace Aplicacion.ServiciosImpl
{
    public class ServicioIMPL<T> where T : class
    {
        IRepositorio<T> _repository;
        private readonly NominaDBContext _context;  

        public ServicioIMPL(NominaDBContext context)
        {
            _context = context; 
            _repository = new RepositorioImpl<T>(context);
        }
    }
}
