using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSM5.Models
{
    public class FiltroEvento
    {






        [Display(Prompt = "Filtrar por nombre", Description = "Filtrar por nombre", Name = "Filtrar por nombre ")]
        public bool Nombrebol { get; set; }

        [Display(Prompt = "Nombre del producto", Description = "Nombre del producto", Name = "Nombre ")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Filtrar por Precio", Description = "Filtrar por Precio", Name = "Filtrar por Precio ")]
        public bool Preciobol { get; set; }

        [Display(Prompt = "Precio min del producto", Description = "Precio del producto", Name = "Precio minimo ")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que cero y menor de 10000")]
        public int Preciomin { get; set; }

        [Display(Prompt = "Precio max del producto", Description = "Precio del producto", Name = "Precio maximo")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que cero y menor de 10000")]
        public int Preciomax { get; set; }

        [Display(Prompt = "Filtrar por Valoracion", Description = "Filtrar por Valoracion", Name = "Filtrar por Valoracion ")]
        public bool Valoracionbol { get; set; }

        [Display(Prompt = "Valoracion del producto", Description = "Valoracion del producto", Name = "Valoracion ")]
        [Range(minimum: 1, maximum: 5, ErrorMessage = "El valoración debe ser mayor que cero y menor de 5")]
        public int Valoracion { get; set; }

        [Display(Prompt = "Filtrar por tipo", Description = "Filtrar por tipo", Name = "Filtrar por tipo ")]
        public bool Tipobol { get; set; }

        [Display(Prompt = "tipo del producto", Description = "tipo del producto", Name = "Tipo ")]
        public string Tipo { get; set; }


    }
}