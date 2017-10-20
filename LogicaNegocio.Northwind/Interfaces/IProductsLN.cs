using Entidades.Northwind;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Northwind.Interfaces
{
    public interface IProductsLN
    {
        Products fnInsertar(Products entity);
        Products fnModificar(Products entity);
        bool fnEliminar(Products entity);
        IEnumerable<Products> fnListar();
        IEnumerable<Products> Buscar(Products entity);
        IEnumerable<Products> BuscarPorNombre(Products entity);
    }
}
