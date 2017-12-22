using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSM5.Models
{
    public class Carrito
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }
        

        [Display(Prompt = "Total", Description = "Subtotal del carrito", Name = "Total ")]
        [Required(ErrorMessage = "Debe indicar un total para el Carrito")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000000, ErrorMessage = "El precio debe ser mayor que cero")]
        public double Precio { get; set; }

        [Display(Prompt = "Usuario", Description = "Usuario del carrito", Name = "Usuario")]
        [Required(ErrorMessage = "Debe indicar un usuario para el Carrito")]
        [DataType(DataType.Text, ErrorMessage = "El usuario debe ser un string")]
        public string Usuario { get; set; }

    }
}