using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Servicios;
using Dominio.Modelos.Abstracciones;
using Infraestructura.AccesoDatos;
using Infraestructura.AccesoDatos.Repositorio;

namespace Aplicacion.ServiciosImpl
{
    public class ContratosTipoServicioIMPL : ServicioIMPL<ContratosTipo>, IContratosTipoServicio
    {
        private IContratosTipoRepo _repo;
        private readonly NominaDBContext _context;
        public ContratosTipoServicioIMPL(NominaDBContext context) : base(context)
        {
            _context = context;
            _repo = new ContratosTipoRepositorioIMPL(context);
        }
    }
}
