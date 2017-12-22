using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;




//GERMAN ES MUY GAY

namespace DSM5.Models
{

    //PUCHOLAAAAAAA
    public class Articulo
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [ScaffoldColumn(false)]
        public string Valoracion { get; set; }

   

        [Display(Prompt = "Stock del artículo", Description = "Stock del artículo", Name = "Stock ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el artículo")]
        public int Stock { get; set; }



        [Display(Prompt = "Nombre del artículo", Description = "Nombre del artículo", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el artículo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Precio del artículo", Description = "Precio del artículo", Name = "Precio ")]
        [Required(ErrorMessage = "Debe indicar un precio para el artículo")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que cero y menor de 10000")]
        public double Precio { get; set; }

        [Display(Prompt = "Descripción del artículo", Description = "Descripción del artículo", Name = "Descripción ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el artículo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Descripcion { get; set; }


        [Display(Prompt = "Imagen del artículo", Description = "Unidades del artículo", Name = "Imagen ")]
        [Required(ErrorMessage = "Debe indicar una imagen del artículo")]
        public string Imagen { get; set; }


    }
}