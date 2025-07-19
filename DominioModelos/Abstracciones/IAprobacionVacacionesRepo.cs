using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.AccesoDatos;


namespace Dominio.Modelos.Abstracciones
{
    public interface IAprobacionVacacionesRepo : IRepositorio<AprobacionVacaciones>
    {
        // declaro metodos de busqueda especificos para AprobacionVacaciones si es necesario
        // Por ejemplo, si necesitas un método para buscar aprobaciones por empleado o fecha, lo puedes declarar aquí.

    }
}
