using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Modelos.Abstracciones;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class RepositorioImpl<T> : IRepositorio<T> where T : class
    {
        private readonly NominaDBContext _context;
        private readonly DbSet<T> _dbSet;
        public RepositorioImpl(NominaDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task ActualizarAsync(T entidad)
        {
            try
            {
                _dbSet.Update(entidad);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, logging, etc.
                throw new NotImplementedException("ERROR AL ACTUALIZAR", ex);
            }
        }

        public async Task AgregarAsync(T entidad)
        {
            try
            {
                await _dbSet.AddAsync(entidad);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR AL AGREGAR", ex);

            }
        }
        public async Task EliminarAsync(int id)
        {
            try
            {
                var entidad = await _dbSet.FindAsync(id);
                if (entidad == null)
                {
                    throw new KeyNotFoundException($"Entidad con ID {id} no encontrada.");
                }
                _dbSet.Remove(entidad);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                // Manejo de excepciones, logging, etc.
                throw new NotImplementedException("ERROR AL ELIMINAR", ex);
            }
        }

        public async Task<bool> ExisteAsync(int id)
        {
            try
            {
                return await _dbSet.AnyAsync(e => EF.Property<int>(e, "Id") == id);

            }
            catch (Exception ex)
            {
                // Manejo de excepciones, logging, etc.
                throw new NotImplementedException("ERROR AL VERIFICAR EXISTENCIA", ex);
            }
        }

        public async Task<T> ObtenerPorIdAsync(int id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, logging, etc.
                throw new NotImplementedException("ERROR AL OBTENER POR ID", ex);
            }
            

        }

        public async Task<IEnumerable<T>> ObtenerTodosAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();

            }
            catch (Exception)
            {
                // Manejo de excepciones, logging, etc.
                throw new NotImplementedException("ERROR AL OBTENER TODOS");
            }
        }
    }
}
