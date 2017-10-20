using LogicaNegocio.Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Northwind;
using AccesoDatos.Northwind.Interfaces;

namespace LogicaNegocio.Northwind.Implementaciones
{
    public class ProductsLN : IProductsLN
    {
        private IUnidadDeTrabajo _unidadDeTrabajoLN;

        public ProductsLN(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this._unidadDeTrabajoLN = unidadDeTrabajo;
        }

        public IEnumerable<Products> Buscar(Products entity)
        {
            return this._unidadDeTrabajoLN.Products.Buscar(p => p.ProductId == entity.ProductId);
        }

        public IEnumerable<Products> BuscarPorNombre(Products entity)
        {

            return this._unidadDeTrabajoLN.Products.Buscar(p => p.ProductName  == entity.ProductName);
        }

        public bool fnEliminar(Products entity)
        {
            return this._unidadDeTrabajoLN.Products.fnEliminar(entity);
        }

        public Products fnInsertar(Products entity)
        {
            return this._unidadDeTrabajoLN.Products.fnInsertar(entity);
        }

        public IEnumerable<Products> fnListar()
        {
            return this._unidadDeTrabajoLN.Products.fnListar();
        }

        public Products fnModificar(Products entity)
        {
            return this._unidadDeTrabajoLN.Products.fnModificar(entity);
        }
    }
}
