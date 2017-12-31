using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSM5.Models
{
    public class Usuario
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [ScaffoldColumn(false)]
        public int carrito { get; set; }


        [Display(Prompt = "Nombre del usuario", Description = "Nombre del usuario", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el producto")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Apellidos del usuario", Description = "Apellidos del usuario", Name = "Apellidos ")]
        [Required(ErrorMessage = "Debe indicar Apellidos para el usuario")]
        [StringLength(maximumLength: 200, ErrorMessage = "El Apellidos no puede tener más de 200 caracteres")]
        public string Apellidos { get; set; }


        [Display(Prompt = "Password del usuario", Description = "Password del usuario", Name = "Password ")]
        [Required(ErrorMessage = "Debe indicar Password para el usuario")]
        [StringLength(maximumLength: 200, ErrorMessage = "El Apellidos no puede tener más de 200 caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        [Display(Prompt = "email del usuario", Description = "email del usuario", Name = "Email ")]
        [Required(ErrorMessage = "Debe indicar email para el usuario")]
        [StringLength(maximumLength: 200, ErrorMessage = "El email no puede tener más de 200 caracteres")]
        public string Email { get; set; }

        [Display(Prompt = "Direccion del usuario", Description = "Direccion del usuario", Name = "Direccion ")]
        [Required(ErrorMessage = "Debe indicar Direccion para el usuario")]
        [StringLength(maximumLength: 200, ErrorMessage = "El Direccion no puede tener más de 200 caracteres")]
        public string Direccion { get; set; }

        [Display(Prompt = "Tarjeta del usuario", Description = "Tarjeta del usuario", Name = "Tarjeta ")]
        [Required(ErrorMessage = "Debe indicar Tarjeta para el usuario")]
        [StringLength(maximumLength: 200, ErrorMessage = "El Direccion no puede tener más de 200 caracteres")]
        public string Tarjeta { get; set; }

        [Display(Prompt = "Imagen del usuario", Description = "Imagen del usuario", Name = "Imagen ")]
        [Required(ErrorMessage = "Debe indicar Imagen para el usuario")]
        [StringLength(maximumLength: 200, ErrorMessage = "El Imagen no puede tener más de 200 caracteres")]
        public string Imagen { get; set; }




        

        


    }
}