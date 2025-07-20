using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTO.DTOs;
using Infraestructura.AccesoDatos;

namespace Dominio.Modelos.Abstracciones
{
    public interface IAprobacionVacacionesRepo : IRepositorio<AprobacionVacaciones>
    {
        // Método para buscar aprobaciones de vacaciones por empleado usando su cédula
        Task<IEnumerable<VacacionesAprovadasGestionDTO>> ResumenDiasAprovadosDiasUsadosAsync(string cedula);
        // LO MAS LOGICO SERIA BUSCAR POR CÉDULA, YA QUE LA FECHA DE APROBACIÓN PUEDE VARIAR


    }
}
