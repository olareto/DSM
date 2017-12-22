using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMPGenNHibernate.EN.SMP;

namespace DSM5.Models
{
    public class AssemblerArticulo
    {
        public Articulo ConvertENToModelUI(ArticuloEN en)
        {
            Articulo art = new Articulo();
            art.id = en.Id;
            art.Descripcion = en.Descripcion;
            art.Nombre = en.Nombre;
            art.Precio = en.Precio;
            art.Imagen = en.Imagen;
            art.Valoracion = en.Valor.ToString();

            art.Stock = en.Stock;
            return art;


        }
        public IList<Articulo> ConvertListENToModel (IList<ArticuloEN> ens){
            IList<Articulo> arts = new List<Articulo>();
            foreach (ArticuloEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
        
    }
}