using AccesoDatos.Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Northwind;

namespace AccesoDatos.Northwind.Implementaciones
{
    public class UnidadDeTrabajoEF : IUnidadDeTrabajo
    {
        public NorthwindContext _Contexto { get; set; }

        public UnidadDeTrabajoEF(NorthwindContext contexto)
        {
            _Contexto = contexto;
        }

        private RepositorioEF<Products> _Products;
        public IRepositorio<Products> Products
        {
            get
            {
                if (this._Products == null)
                {
                    this._Products = new RepositorioEF<Products>(_Contexto);
                }
                return _Products;
            }
        }

        private RepositorioEF<Categories> _Categories;
        public IRepositorio<Categories> Categories
        {
            get
            {
                if (this._Categories == null)
                {
                    this._Categories = new RepositorioEF<Categories>(_Contexto);
                }
                return _Categories;
            }
        }

        private RepositorioEF<Orders> _Orders;
        public IRepositorio<Orders> Orders
        {
            get
            {
                if (this._Orders == null)
                {
                    this._Orders = new RepositorioEF<Orders>(_Contexto);
                }
                return _Orders;
            }
        }

        public int Completar()
        {
            try
            {
                return _Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            _Contexto.Dispose();
        }
    }
}
