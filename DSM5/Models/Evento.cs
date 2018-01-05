using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSM5.Models
{
    public class Evento
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }


        [Display(Prompt = "imagen grande del producto", Description = "imagen grande del producto", Name = "imagen grande ")]
        [Required(ErrorMessage = "Debe indicar un imagen grande para el producto")]
        [StringLength(maximumLength: 200, ErrorMessage = "El imagen grande no puede tener más de 200 caracteres")]
        public string imagran { get; set; }

        [Display(Prompt = "descricion larga del producto", Description = "descricion larga del producto", Name = "descricion larga ")]
        [Required(ErrorMessage = "Debe indicar un descricion larga para el producto")]
        [StringLength(maximumLength: 200, ErrorMessage = "El descricion larga no puede tener más de 200 caracteres")]
        public string descriplarga { get; set; }

   




        ///



       



        [Display(Prompt = "Stock del Evento", Description = "Stock del Evento", Name = "Stock ")]
        [Required(ErrorMessage = "Debe indicar un Stock para el Evento")]
        public int Stock { get; set; }



        [Display(Prompt = "Nombre del Evento", Description = "Nombre del Evento", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el Evento")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Precio del producto", Description = "Precio del Evento", Name = "Precio ")]
        [Required(ErrorMessage = "Debe indicar un precio para el Evento")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que cero y menor de 10000")]
        public double Precio { get; set; }

        [Display(Prompt = "Descripción del Evento", Description = "Descripción del Evento", Name = "Descripción ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el Evento")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Descripcion { get; set; }


        [Display(Prompt = "Imagen del Evento", Description = "Unidades del Evento", Name = "Imagen ")]
        [Required(ErrorMessage = "Debe indicar una imagen del Evento")]
        public string Imagen { get; set; }



        [Display(Prompt = "Valoracion del Evento", Description = "Valoracion del Evento", Name = "Valoracion ")]
        [Required(ErrorMessage = "Debe indicar una valoración para el Evento")]
        [Range(minimum: 1, maximum: 5, ErrorMessage = "El valoración debe ser mayor que cero y menor de 5")]
        public int Valoracion { get; set; }

      

        [Display(Prompt = "Tipo del Evento", Description = "Tipo del Evento", Name = "Tipo ")]
        [Required(ErrorMessage = "Debe indicar una Tipo para el Evento")]
        public string Tipo { get; set; }


    }
}