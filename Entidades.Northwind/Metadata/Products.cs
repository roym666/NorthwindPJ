using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidades.Northwind
{
    [ModelMetadataType(typeof(ProductsMetadata))]
    public partial class Products
    {

    }

    public class ProductsMetadata
    {
        [Required(ErrorMessage = "El campo {0} es requerido"),
            MaxLength(40, ErrorMessage = "El campo debe ser máximo de {1} caracteres"),
            MinLength(3, ErrorMessage = "El campo debe ser mínimo de {1} caracteres"),
            Display(Name = "Nombre del Producto")]
        public string ProductName { get; set; }
    }
}
