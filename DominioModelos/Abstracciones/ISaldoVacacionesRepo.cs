using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTO.DTOs;
using Infraestructura.AccesoDatos;

namespace Dominio.Modelos.Abstracciones
{
    public interface ISaldoVacacionesRepo : IRepositorio<SaldoVacaciones>
    {
        Task<SaldoVacaciones> BuscarPorEmpleadoIdAsync(int empleadoId);





    }
}
