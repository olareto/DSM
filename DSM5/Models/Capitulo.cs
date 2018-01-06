using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSM5.Models
{
    public class Capitulo
    {
      

        [ScaffoldColumn(false)]
        public int id { get; set; }

        [ScaffoldColumn(false)]
        public int temporada { get; set; }


        [ScaffoldColumn(false)]
        public int serie { get; set; }





        [Display(Prompt = "Nombre del Capitulo", Description = "Nombre del Capitulo", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el Capitulo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Nombre del Capitulo", Description = "Nombre del Capitulo", Name = "link ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el Capitulo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string link { get; set; }

        [Display(Prompt = "fecha del Capitulo", Description = "fecha del Capitulo", Name = "fecha ")]
        [Required(ErrorMessage = "Debe indicar un fecha para el Capitulo")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime fecha { get; set; }


        [Display(Prompt = "descripcion del Capitulo", Description = "descripcion del Capitulo", Name = "descripcion ")]
        [Required(ErrorMessage = "Debe indicar una descripcion para el Capitulo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        
        public string descripcion { get; set; }

        [Display(Prompt = "imagen del Capitulo", Description = "imagen del Capitulo", Name = "imagen ")]
        [Required(ErrorMessage = "Debe indicar un imagen para el Capitulo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string imagen { get; set; }


    }
}