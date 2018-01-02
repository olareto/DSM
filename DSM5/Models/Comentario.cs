using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSM5.Models
{
    public class Comentario
    {
      

        [ScaffoldColumn(false)]
        public int id { get; set; }


        [ScaffoldColumn(false)]
        public int idsup { get; set; }

        [ScaffoldColumn(false)]
        public string tipo { get; set; }

       





        [Display(Prompt = "autor de la Comentario", Description = "autor de la Comentario", Name = "autor ")]
        [Required(ErrorMessage = "Debe indicar un autor para la Comentario")]
        [StringLength(maximumLength: 200, ErrorMessage = "El autor no puede tener más de 200 caracteres")]
        public string autor { get; set; }

        [Display(Prompt = "comentario de la Comentario", Description = "comentario de la Comentario", Name = "comentario ")]
        [Required(ErrorMessage = "Debe indicar un comentario para la Comentario")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string comentario { get; set; }


        [Display(Prompt = "fecha de la Comentario", Description = "fecha de la Comentario", Name = "fecha ")]
        [Required(ErrorMessage = "Debe indicar un fecha para la Comentario")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime fecha { get; set; }


      


    }
}