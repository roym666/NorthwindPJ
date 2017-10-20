using Entidades.Northwind;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Northwind.Interfaces
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        IRepositorio<Products> Products { get; }
        IRepositorio<Categories> Categories { get; }
        IRepositorio<Orders> Orders { get; }
        int Completar();
        new void Dispose();
    }
}
