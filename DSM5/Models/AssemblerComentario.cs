using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMPGenNHibernate.EN.SMP;

namespace DSM5.Models
{
    public class AssemblerComentario
    {
        public Comentario ConvertENToModelUI(ComentarioEN en)
        {
            Comentario art = new Comentario();

            
            art.autor = en.Autor;
            art.comentario = en.Comentario;
            if (en.Fecha != null)
                art.fecha = (DateTime)en.Fecha;
            else
                art.fecha = DateTime.Today;
            art.id = en.Id;



            if (en.Capitulo != null)
            {
                art.idsup = en.Capitulo.Id;
                art.controller = "Capitulo";
                art.action = "";

            }


            if (en.Articulo != null)
            {
                art.idsup = en.Articulo.Id;
                //if (en.Articulo.)
                //{

               // }
                art.controller = "Articulo";
                art.action = "";

            }
            


            if (en.Pelicula != null)
            {
                art.idsup = en.Pelicula.Id;
                art.controller = "Pelicula";
                art.action = "";

            }
            





            return art;


        }
        public IList<Comentario> ConvertListENToModel (IList<ComentarioEN> ens){
            IList<Comentario> arts = new List<Comentario>();
            foreach (ComentarioEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
        
    }
}