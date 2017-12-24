using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSM5.Models
{
    public class Temporada
    {
      

        [ScaffoldColumn(false)]
        public int id { get; set; }

        




        [Display(Prompt = "Nombre de la Temporada", Description = "Nombre de la Temporada", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para la Serie")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }


        


    }
}