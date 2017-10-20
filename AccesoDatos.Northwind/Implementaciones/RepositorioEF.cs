using AccesoDatos.Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AccesoDatos.Northwind.Implementaciones
{
    public class RepositorioEF<TEntity> : IRepositorio<TEntity> where TEntity : class
    {

        private DbContext _context;

        public RepositorioEF(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate, List<string> includes = null)
        {
            IQueryable<TEntity> preconsulta = _context.Set<TEntity>();

            if (includes != null)
            {
                includes.ForEach(x => preconsulta = preconsulta.Include(x));
            }

            return preconsulta.Where(predicate);
        }

        public bool fnEliminar(TEntity entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TEntity fnInsertar(TEntity entity)
        {    
            try
            {
                _context.Set<TEntity>().Add(entity);
                return entity;
            }
            catch (Exception)
            {
                throw;
            }                 
        }

        public IEnumerable<TEntity> fnListar()
        {
            try
            {
                return _context.Set<TEntity>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TEntity fnModificar(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Update(entity);
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
