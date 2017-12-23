using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSM5.Models
{
    public class Pelicula
    {
        
            [ScaffoldColumn(false)]
            public int id { get; set; }




            [Display(Prompt = "Nombre de la pelicula", Description = "Nombre de la Pelicula", Name = "Nombre ")]
            [Required(ErrorMessage = "Debe indicar un nombre para la Pelicula")]
            [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
            public string Nombre { get; set; }


            [Display(Prompt = "Valoracion de la Pelicula", Description = "Valoracion de la Pelicula", Name = "Valoracion ")]
            [Required(ErrorMessage = "Debe indicar una valoración para la Pelicula")]
            [Range(minimum: 1, maximum: 5, ErrorMessage = "El valoración debe ser mayor que cero y menor de 5")]
            public int Valoracion { get; set; }


  
        
    }
}
