using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LogicaNegocio.Northwind.Interfaces;
using Entidades.Northwind;

namespace AngularServiceClient.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {     
        private IProductsLN _productsLN { get; set; }

        public ProductsController(IProductsLN productsLN)
        {
            _productsLN = productsLN; 
        }

        [HttpGet]
        public IEnumerable<Products> getProducts()
        {
            try
            {
                return _productsLN.fnListar();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public IEnumerable<Products> getProductsById(int id)
        {
            try
            {
                var entidad = new Products() { ProductId = id };
                return _productsLN.Buscar(entidad);
            }
            catch
            {
                throw;
            }
        }


    }
}