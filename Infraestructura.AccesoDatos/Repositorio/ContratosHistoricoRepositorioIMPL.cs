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
    public class ContratosHistoricoRepositorioIMPL : RepositorioImpl<ContratosHistorico>, IContratosHistoricoRepo
    {
        private readonly NominaDBContext _context;
        public ContratosHistoricoRepositorioIMPL(NominaDBContext context) : base(context)
        {
            this._context = context;
        }

    }
}
