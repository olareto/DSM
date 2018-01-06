using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSM5.Models
{
    public class FiltroPelicula
    {






        [Display(Prompt = "Filtrar por nombre", Description = "Filtrar por nombre", Name = "Filtrar por nombre ")]
        public bool Nombrebol { get; set; }

        [Display(Prompt = "Nombre de la Pelicula", Description = "Nombre de la Pelicula", Name = "Nombre ")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }


        [Display(Prompt = "Filtrar por Valoracion", Description = "Filtrar por Valoracion", Name = "Filtrar por Valoracion ")]
        public bool Valoracionbol { get; set; }

        [Display(Prompt = "Valoracion de la Pelicula", Description = "Valoracion de la Pelicula", Name = "Valoracion ")]
        [Range(minimum: 1, maximum: 5, ErrorMessage = "El valoración debe ser mayor que cero y menor de 5")]
        public int Valoracion { get; set; }


        [Display(Prompt = "Filtrar por anyo", Description = "Filtrar por Valoracion", Name = "Filtrar por anyo ")]
        public bool anyobol { get; set; }

        [Display(Prompt = "Valoracion de la Pelicula", Description = "Valoracion de la Pelicula", Name = "anyo ")]
        [Range(minimum: 1900, maximum: 2018, ErrorMessage = "El valoración debe ser mayor que 1900 y menor de 2018")]
        public int anyomin { get; set; }

        [Display(Prompt = "Valoracion de la Pelicula", Description = "Valoracion de la Pelicula", Name = "anyo ")]
        [Range(minimum: 1900, maximum: 2018, ErrorMessage = "El valoración debe ser mayor que 1900 y menor de 2018")]
        public int anyomax { get; set; }
        




    }
}