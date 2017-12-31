using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMPGenNHibernate.EN.SMP;

namespace DSM5.Models
{
    public class AssemblerCapitulo
    {
        public Capitulo ConvertENToModelUI(CapituloEN en)
        {
            Capitulo art = new Capitulo();
            art.id = en.Id;
            if (en.Temporada != null)
            {
                art.temporada = en.Temporada.Id;
                art.serie = en.Temporada.Serie.Id;
            }
                
            
            art.Nombre = en.Nombre;
            if (en.Fecha != null)
                art.fecha = (DateTime)en.Fecha;
            else
                art.fecha = DateTime.Today;
            art.descripcion = en.Descripcion;
            art.imagen = en.Imagen;
            
         
            return art;


        }
        public IList<Capitulo> ConvertListENToModel (IList<CapituloEN> ens){
            IList<Capitulo> arts = new List<Capitulo>();
            foreach (CapituloEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
        
    }
}