using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AccesoDatos.Northwind.Interfaces
{
    public interface IRepositorio<TEntity> where TEntity : class
    {
        TEntity fnInsertar(TEntity entity);
        TEntity fnModificar(TEntity entity);
        IEnumerable<TEntity> fnListar();
        bool fnEliminar(TEntity entity);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate, List<string> includes = null);
    }
}
