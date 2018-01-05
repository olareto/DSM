using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSM5.Models
{
    public class Lineas_pedido
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [ScaffoldColumn(false)]
        public int articulo { get; set; }

        [ScaffoldColumn(false)]
        public int carrito { get; set; }

        [ScaffoldColumn(false)]
        public string tipo { get; set; }

        [ScaffoldColumn(false)]
        public int stock { get; set; }

        [ScaffoldColumn(false)]
        public double precio { get; set; }







        [Display(Prompt = "Cantidad", Description = "Cantidad del linea", Name = "Cantidad ")]
        [Required(ErrorMessage = "Debe indicar un Cantidad para el linea")]
        [Range(minimum: 0, maximum: 10000000, ErrorMessage = "El precio debe ser mayor que cero")]
        public int cantidad { get; set; }

        

    }
}