using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSM5.Models
{
    public class Registro
    {
       


        [Display(Prompt = "email del usuario", Description = "email del usuario", Name = "email ")]
        [Required(ErrorMessage = "Debe indicar un email para el producto")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string email { get; set; }

        


        [Display(Prompt = "Password del usuario", Description = "Password del usuario", Name = "Password ")]
        [Required(ErrorMessage = "Debe indicar Password para el usuario")]
        [StringLength(maximumLength: 200, ErrorMessage = "El Apellidos no puede tener más de 200 caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        



        

        


    }
}