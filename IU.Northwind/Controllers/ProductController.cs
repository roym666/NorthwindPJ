using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LogicaNegocio.Northwind.Interfaces;
using Entidades.Northwind;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IU.Northwind.Controllers
{
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private IProductsLN _objProduct { get; set; }

        public ProductController(IProductsLN objProductLN)
        {
            this._objProduct = objProductLN;
        }

        [HttpGet()]
        public JsonResult Buscar(string nombre = "")
        {
            try
            {
                var product = new Products() { ProductName = nombre };
                var consulta = _objProduct.BuscarPorNombre(product);
                return Json(new
                {
                    data = consulta.Select(p => new
                    {
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        QuantityPerUnit = p.QuantityPerUnit,
                        UnitPrice = p.UnitPrice,
                        UnitsInStock = p.UnitsInStock,
                        UnitsOnOrder = p.UnitsOnOrder,
                        ReorderLevel = p.ReorderLevel,
                        Discontinued = p.Discontinued,
                        CategoryId = p.CategoryId,
                        CategoryName = p.Category?.CategoryName,
                        SupplierId = p.SupplierId,
                        SupplierName = p.Supplier?.CompanyName

                    })
                });
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct([FromRoute] int id)
        {
            try
            {
                var product = new Products() { ProductId = id };
                var consulta = _objProduct.Buscar(product).FirstOrDefault();
                return Ok(consulta);
            }

            catch
            {
                throw;
            }
        }
    }
}
