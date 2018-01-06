
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



/**
 *	Atributo lista_0
 */
private System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ListaEN> lista_0;



/**
 *	Atributo link
 */
private string link;






public virtual System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ComentarioEN> Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ListaEN> Lista_0 {
        get { return lista_0; } set { lista_0 = value;  }
}



public virtual string Link {
        get { return link; } set { link = value;  }
}





public PeliculaEN() : base ()
{
        comentario = new System.Collections.Generic.List<SMPGenNHibernate.EN.SMP.ComentarioEN>();
        lista_0 = new System.Collections.Generic.List<SMPGenNHibernate.EN.SMP.ListaEN>();
}



public PeliculaEN(int id, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ComentarioEN> comentario, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ListaEN> lista_0, string link
                  , SMPGenNHibernate.Enumerated.SMP.ValoracionEnum valoracion, string nombre, string imagen, string descriplarga, string descripcion, string genero, Nullable<DateTime> anyo, string imagran
                  )
{
        this.init (Id, comentario, lista_0, link, valoracion, nombre, imagen, descriplarga, descripcion, genero, anyo, imagran);
}


public PeliculaEN(PeliculaEN pelicula)
{
        this.init (Id, pelicula.Comentario, pelicula.Lista_0, pelicula.Link, pelicula.Valoracion, pelicula.Nombre, pelicula.Imagen, pelicula.Descriplarga, pelicula.Descripcion, pelicula.Genero, pelicula.Anyo, pelicula.Imagran);
}

private void init (int id
                   , System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ComentarioEN> comentario, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ListaEN> lista_0, string link, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum valoracion, string nombre, string imagen, string descriplarga, string descripcion, string genero, Nullable<DateTime> anyo, string imagran)
{
        this.Id = id;


        this.Comentario = comentario;

        this.Lista_0 = lista_0;

        this.Link = link;

        this.Valoracion = valoracion;

        this.Nombre = nombre;

        this.Imagen = imagen;

        this.Descriplarga = descriplarga;

        this.Descripcion = descripcion;

        this.Genero = genero;

        this.Anyo = anyo;

        this.Imagran = imagran;
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
