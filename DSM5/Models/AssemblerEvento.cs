using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMPGenNHibernate.EN.SMP;

namespace DSM5.Models
{
    public class AssemblerEvento
    {
        public Evento ConvertENToModelUI(EventoEN en)
        {
            Evento art = new Evento();
            art.id = en.Id;
            art.Descripcion = en.Descripcion;
            art.Nombre = en.Nombre;
            art.Precio = en.Precio;
            art.Imagen = en.Imagen;
            art.Valoracion =(int) en.Valor;
            art.Tipo = en.Tipo;
            art.Stock = en.Stock;
            return art;


        }
        public IList<Evento> ConvertListENToModel (IList<EventoEN> ens){
            IList<Evento> arts = new List<Evento>();
            foreach (EventoEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
        
    }
}