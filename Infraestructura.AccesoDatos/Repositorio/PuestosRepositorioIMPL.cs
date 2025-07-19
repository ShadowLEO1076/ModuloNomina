using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Modelos.Abstracciones;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class PuestosRepositorioIMPL : RepositorioImpl<Puestos>, IPuestosRepo
    {
        public PuestosRepositorioIMPL(NominaDBContext context) : base(context)
        {
        }

        public Task<IEnumerable<Puestos>> BuscarPorDepartamentoAsync(string departamento)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Puestos>> BuscarPorNombreAsync(string nombre)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistePuestoPorDepartamentoAsync(string departamento)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistePuestoPorNombreAsync(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
