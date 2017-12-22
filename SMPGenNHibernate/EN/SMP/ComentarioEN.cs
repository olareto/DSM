
using System;
// Definición clase ComentarioEN
namespace SMPGenNHibernate.EN.SMP
{
public partial class ComentarioEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo capitulo
 */
private SMPGenNHibernate.EN.SMP.CapituloEN capitulo;



/**
 *	Atributo pelicula
 */
private SMPGenNHibernate.EN.SMP.PeliculaEN pelicula;



/**
 *	Atributo articulo
 */
private SMPGenNHibernate.EN.SMP.ArticuloEN articulo;



/**
 *	Atributo comentario
 */
private string comentario;



/**
 *	Atributo autor
 */
private string autor;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual SMPGenNHibernate.EN.SMP.CapituloEN Capitulo {
        get { return capitulo; } set { capitulo = value;  }
}



public virtual SMPGenNHibernate.EN.SMP.PeliculaEN Pelicula {
        get { return pelicula; } set { pelicula = value;  }
}



public virtual SMPGenNHibernate.EN.SMP.ArticuloEN Articulo {
        get { return articulo; } set { articulo = value;  }
}



public virtual string Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual string Autor {
        get { return autor; } set { autor = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}





public ComentarioEN()
{
}



public ComentarioEN(int id, SMPGenNHibernate.EN.SMP.CapituloEN capitulo, SMPGenNHibernate.EN.SMP.PeliculaEN pelicula, SMPGenNHibernate.EN.SMP.ArticuloEN articulo, string comentario, string autor, Nullable<DateTime> fecha
                    )
{
        this.init (Id, capitulo, pelicula, articulo, comentario, autor, fecha);
}


public ComentarioEN(ComentarioEN comentario)
{
        this.init (Id, comentario.Capitulo, comentario.Pelicula, comentario.Articulo, comentario.Comentario, comentario.Autor, comentario.Fecha);
}

private void init (int id
                   , SMPGenNHibernate.EN.SMP.CapituloEN capitulo, SMPGenNHibernate.EN.SMP.PeliculaEN pelicula, SMPGenNHibernate.EN.SMP.ArticuloEN articulo, string comentario, string autor, Nullable<DateTime> fecha)
{
        this.Id = id;


        this.Capitulo = capitulo;

        this.Pelicula = pelicula;

        this.Articulo = articulo;

        this.Comentario = comentario;

        this.Autor = autor;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ComentarioEN t = obj as ComentarioEN;
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
