using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Servicios;
using Dominio.Modelos.Abstracciones;
using Infraestructura.AccesoDatos;
using Infraestructura.AccesoDatos.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.ServiciosImpl
{
    public class ServicioIMPL<T> : IServicio<T> where T : class
    {

        IRepositorio<T> _repository;
        private readonly NominaDBContext _context; // leo 

        public ServicioIMPL(NominaDBContext context)
        {
            _context = context; // leo
            _repository = new RepositorioImpl<T>(context);
        }

        public async Task<T> ObtenerPorIdAsync(int id)
        {
            try
            {
                return await _repository.ObtenerPorIdAsync(id);
            }
            catch (Exception ex) { throw new Exception("Error - Service: el dato no se pudo recuperar: " + ex.Message); }
        }

        public async Task<IEnumerable<T>> ObtenerTodosAsync()
        {
            try
            {
                return await _repository.ObtenerTodosAsync();
            }
            catch (Exception ex) { throw new Exception("Error - Service: los datos no se pudieron obtener: " + ex.Message); }
        }

        public async Task AgregarAsync(T entidad)
        {
            try
            {
                await _repository.AgregarAsync(entidad);
            }
            catch (Exception ex) { throw new Exception("Error - Service: el dato no se pudo añadir: " + ex.Message); }
        }

        public async Task ActualizarAsync(T entidad)
        {
            try
            {
                await _repository.ActualizarAsync(entidad);
            }
            catch (Exception ex) { throw new Exception("Error - Service: el dato no se pudo actualizar: " + ex.Message); }
        }

        public async Task EliminarAsync(int id)
        {
            try
            {
                await _repository.EliminarAsync(id);
            }
            catch (Exception ex) { throw new Exception("Error - Service: el dato no se pudo eliminar: " + ex.Message); }
        }

        public async Task<bool> ExisteAsync(int id)
        {
            try
            {
                return await _repository.ExisteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error - Service: no se pudo verificar la existencia del dato: " + ex.Message);
            }
        }
    }
}
