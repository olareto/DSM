
using System;
// Definición clase PeliculaEN
namespace SMPGenNHibernate.EN.SMP
{
public partial class PeliculaEN                                                                     : SMPGenNHibernate.EN.SMP.VideoEN


{
/**
 *	Atributo comentario
 */
private System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ComentarioEN> comentario;






public virtual System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ComentarioEN> Comentario {
        get { return comentario; } set { comentario = value;  }
}





public PeliculaEN() : base ()
{
        comentario = new System.Collections.Generic.List<SMPGenNHibernate.EN.SMP.ComentarioEN>();
}



public PeliculaEN(int id, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ComentarioEN> comentario
                  , System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ListaEN> lista, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum valoracion, string nombre, string imagen
                  )
{
        this.init (Id, comentario, lista, valoracion, nombre, imagen);
}


public PeliculaEN(PeliculaEN pelicula)
{
        this.init (Id, pelicula.Comentario, pelicula.Lista, pelicula.Valoracion, pelicula.Nombre, pelicula.Imagen);
}

private void init (int id
                   , System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ComentarioEN> comentario, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ListaEN> lista, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum valoracion, string nombre, string imagen)
{
        this.Id = id;


        this.Comentario = comentario;

        this.Lista = lista;

        this.Valoracion = valoracion;

        this.Nombre = nombre;

        this.Imagen = imagen;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PeliculaEN t = obj as PeliculaEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
