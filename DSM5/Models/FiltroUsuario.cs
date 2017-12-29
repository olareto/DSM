using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSM5.Models
{
    public class FiltroUsuario
    {






        [Display(Prompt = "Filtrar por nombre", Description = "Filtrar por nombre", Name = "Filtrar por nombre ")]
        public bool Nombrebol { get; set; }

        [Display(Prompt = "Nombre del Usuario", Description = "Nombre del Usuario", Name = "Nombre ")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        


    }
}