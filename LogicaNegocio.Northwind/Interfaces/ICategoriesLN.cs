using Entidades.Northwind;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Northwind.Interfaces
{
    interface ICategoriesLN
    {
        Categories fnInsertar(Categories entity);
        Categories fnModificar(Categories entity);
        bool fnEliminar(Categories entity);
        IEnumerable<Categories> fnListar();
        IEnumerable<Categories> Buscar(Categories entity);
    }
}
