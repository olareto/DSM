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
            art.fecha = (DateTime)en.Fecha;
            art.id = en.Id;

            if(en.Capitulo != null)
                art.idsup =en.Capitulo.Id;
            if (en.Articulo != null)
                art.idsup = en.Articulo.Id;
            if (en.Pelicula != null)
                art.idsup = en.Pelicula.Id;





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