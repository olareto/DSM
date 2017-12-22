using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSM5.Models
{
    public class FiltroCarrito
    {


        [Display(Prompt = "Filtrar por Usuario", Description = "Filtrar por Usuario", Name = "Filtrar por Usuario ")]
        public bool Usuario { get; set; }

        
    }
}