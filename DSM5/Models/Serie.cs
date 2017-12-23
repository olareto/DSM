using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSM5.Models
{
    public class Serie
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }




        [Display(Prompt = "Nombre de la Serie", Description = "Nombre de la Pelicula", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para la Serie")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }


        [Display(Prompt = "Valoracion de la Serie", Description = "Valoracion de la Serie", Name = "Valoracion ")]
        [Required(ErrorMessage = "Debe indicar una valoración para la Serie")]
        [Range(minimum: 1, maximum: 5, ErrorMessage = "El valoración debe ser mayor que cero y menor de 5")]
        public int Valoracion { get; set; }


    }
}