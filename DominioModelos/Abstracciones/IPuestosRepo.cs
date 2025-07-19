using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.AccesoDatos;
namespace Dominio.Modelos.Abstracciones
{
    public interface IPuestosRepo: IRepositorio<Puestos>
    {
        Task<IEnumerable<Puestos>> BuscarPorNombreAsync(string nombre); // Método para buscar puestos por nombre
        Task<IEnumerable<Puestos>> BuscarPorDepartamentoAsync(string departamento); // Método para buscar puestos por departamento
        Task<bool> ExistePuestoPorNombreAsync(string nombre); // Método para verificar si existe un puesto por nombre
        Task<bool> ExistePuestoPorDepartamentoAsync(string departamento); // Método para verificar si existe un puesto por departamento
    }

}