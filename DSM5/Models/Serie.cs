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

        [Display(Prompt = "Imagen de la Serie", Description = "Imagen de la Serie", Name = "Imagen ")]
        [Required(ErrorMessage = "Debe indicar una imagen para la Serie")]
        public string Imagen { get; set; }


        [Display(Prompt = "Imagen de la Serie", Description = "Imagen de la Serie", Name = "descripcion ")]
        [Required(ErrorMessage = "Debe indicar una imagen para la Serie")]
        public string descripcion { get; set; }

        [Display(Prompt = "Imagen de la Serie", Description = "Imagen de la Serie", Name = "desclar ")]
        [Required(ErrorMessage = "Debe indicar una imagen para la Serie")]
        public string desclar { get; set; }

        [Display(Prompt = "Imagen de la Serie", Description = "Imagen de la Serie", Name = "genero ")]
        [Required(ErrorMessage = "Debe indicar una imagen para la Serie")]
        public string genero { get; set; }

        [Display(Prompt = "Imagen de la Serie", Description = "Imagen de la Serie", Name = "imagran ")]
        [Required(ErrorMessage = "Debe indicar una imagen para la Serie")]
        public string imagran { get; set; }

        [Display(Prompt = "fecha de la Comentario", Description = "fecha de la Comentario", Name = "fecha ")]
        [Required(ErrorMessage = "Debe indicar un fecha para la Comentario")]
        [DisplayFormat(DataFormatString = "{0:t}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime fecha { get; set; }


    }
}