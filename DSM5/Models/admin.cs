using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSM5.Models
{
    public class Admin
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }


        [Display(Prompt = "Nombre del Admin", Description = "Nombre del Admin", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el Admin")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Apellidos del Admin", Description = "Apellidos del Admin", Name = "Apellidos ")]
        [Required(ErrorMessage = "Debe indicar Apellidos para el Admin")]
        [StringLength(maximumLength: 200, ErrorMessage = "El Apellidos no puede tener más de 200 caracteres")]
        public string Apellidos { get; set; }


        [Display(Prompt = "Password del Admin", Description = "Password del Admin", Name = "Password ")]
        [Required(ErrorMessage = "Debe indicar Password para el Admin")]
        [StringLength(maximumLength: 200, ErrorMessage = "El Apellidos no puede tener más de 200 caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        [Display(Prompt = "email del Admin", Description = "email del Admin", Name = "Email ")]
        [Required(ErrorMessage = "Debe indicar email para el Admin")]
        [StringLength(maximumLength: 200, ErrorMessage = "El email no puede tener más de 200 caracteres")]
        public string Email { get; set; }

        [Display(Prompt = "Direccion del Admin", Description = "Direccion del Admin", Name = "Direccion ")]
        [Required(ErrorMessage = "Debe indicar Direccion para el Admin")]
        [StringLength(maximumLength: 200, ErrorMessage = "El Direccion no puede tener más de 200 caracteres")]
        public string Direccion { get; set; }

        [Display(Prompt = "Tarjeta del Admin", Description = "Tarjeta del Admin", Name = "Tarjeta ")]
        [Required(ErrorMessage = "Debe indicar Tarjeta para el Admin")]
        [StringLength(maximumLength: 200, ErrorMessage = "El Direccion no puede tener más de 200 caracteres")]
        public string Tarjeta { get; set; }

        [Display(Prompt = "Imagen del Admin", Description = "Imagen del Admin", Name = "Imagen ")]
        [Required(ErrorMessage = "Debe indicar Imagen para el Admin")]
        [StringLength(maximumLength: 200, ErrorMessage = "El Imagen no puede tener más de 200 caracteres")]
        public string Imagen { get; set; }

        public static implicit operator Admin(Usuario v)
        {
            throw new NotImplementedException();
        }
    }
}