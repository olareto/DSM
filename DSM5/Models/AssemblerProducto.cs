using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMPGenNHibernate.EN.SMP;

namespace DSM5.Models
{
    public class AssemblerProducto
    {
        public Producto ConvertENToModelUI(ProductoEN en)
        {
            Producto art = new Producto();
            art.id = en.Id;
            art.Descripcion = en.Descripcion;
            art.Nombre = en.Nombre;
            art.Precio = en.Precio;
            art.Imagen = en.Imagen;
            art.Valoracion =(int) en.Valor;
            art.Talla = en.Talla;
            art.Stock = en.Stock;
            art.descriplarga = en.Descriplarga;
            art.imagran = en.Imagran;
            return art;


        }
        public IList<Producto> ConvertListENToModel (IList<ProductoEN> ens){
            IList<Producto> arts = new List<Producto>();
            foreach (ProductoEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
        
    }
}