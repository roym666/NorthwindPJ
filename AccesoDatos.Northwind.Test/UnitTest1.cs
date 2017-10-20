using AccesoDatos.Northwind.Implementaciones;
using Entidades.Northwind;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace AccesoDatos.Northwind.Test
{
    public class ProductsUnitTest
    {

        DbContextOptionsBuilder<NorthwindContext> builder;
        NorthwindContext context;

        public ProductsUnitTest()
        {
            builder = new DbContextOptionsBuilder<NorthwindContext>()
     .UseSqlServer("Server=.;Database=Northwind;Trusted_Connection=True;");

            context = new NorthwindContext(builder.Options);
        }

        [Fact]
        public void PruebaListarProductos()
        {

            var ut = new UnidadDeTrabajoEF(context);
            var objRespuesta = ut.Products.fnListar();
            Assert.True(objRespuesta.Count() > 0);
        }

        [Fact]
        public void PruebaInsertarProducto()
        {

            var producto = new Products() { ProductName = "Eliminar producto" };

            var ut = new UnidadDeTrabajoEF(context);
            var objRespuesta = ut.Products.fnInsertar(producto);
            ut.Completar();
            Assert.True(objRespuesta.ProductId > 0);
        }

        [Fact]
        public void PruebaEliminarProducto()
        {

            var producto = new Products() { ProductId = 97, ProductName = "Eliminar producto" };

            var ut = new UnidadDeTrabajoEF(context);
            var objRespuesta = ut.Products.fnEliminar(producto);
            ut.Completar();
            Assert.True(objRespuesta);
        }

        [Fact]
        public void PruebaBuscarProductosPorNombre()
        {

            var ut = new UnidadDeTrabajoEF(context);
            var objRespuesta = ut.Products.Buscar(p => p.ProductName.Contains("cha")).ToList();
            Assert.True(objRespuesta.Count() > 0);
        }

        public void PruebaBuscarProductosPorNombreYPrecio()
        {

            var ut = new UnidadDeTrabajoEF(context);
            var objRespuesta = ut.Products.Buscar(p => p.ProductName.Contains("cha") && p.UnitPrice > 0).ToList();
            Assert.True(objRespuesta.Count() > 0);
        }

        [Fact]
        public void PruebaListarCategorias()
        {

            var ut = new UnidadDeTrabajoEF(context);
            var objRespuesta = ut.Categories.fnListar();
            Assert.True(objRespuesta.Count() > 0);
        }

        [Fact]
        public void PruebaListarOrders()
        {

            var ut = new UnidadDeTrabajoEF(context);
            var objRespuesta = ut.Orders.fnListar();
            Assert.True(objRespuesta.Count() > 0);
        }
    }
}
