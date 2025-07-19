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
    public class PuestosServicioIMPL : ServicioIMPL<Puestos>, IPuestosServicio
    {
        public PuestosServicioIMPL(NominaDBContext context) : base(context)
        {
        }
    }
}
