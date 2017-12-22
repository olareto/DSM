using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSM5.Models
{
    public class Producto
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        

   

        [Display(Prompt = "Stock del producto", Description = "Stock del producto", Name = "Stock ")]
        [Required(ErrorMessage = "Debe indicar un Stock para el producto")]
        public int Stock { get; set; }



        [Display(Prompt = "Nombre del producto", Description = "Nombre del producto", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el producto")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Precio del producto", Description = "Precio del producto", Name = "Precio ")]
        [Required(ErrorMessage = "Debe indicar un precio para el producto")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que cero y menor de 10000")]
        public double Precio { get; set; }

        [Display(Prompt = "Descripción del producto", Description = "Descripción del producto", Name = "Descripción ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el producto")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Descripcion { get; set; }


        [Display(Prompt = "Imagen del producto", Description = "Unidades del producto", Name = "Imagen ")]
        [Required(ErrorMessage = "Debe indicar una imagen del producto")]
        public string Imagen { get; set; }



        [Display(Prompt = "Valoracion del producto", Description = "Valoracion del producto", Name = "Valoracion ")]
        [Required(ErrorMessage = "Debe indicar una valoración para el producto")]
        [Range(minimum: 1, maximum: 5, ErrorMessage = "El valoración debe ser mayor que cero y menor de 5")]
        public int Valoracion { get; set; }

      

        [Display(Prompt = "talla del producto", Description = "talla del producto", Name = "Talla ")]
        [Required(ErrorMessage = "Debe indicar una talla para el producto")]
        public string Talla { get; set; }


    }
}