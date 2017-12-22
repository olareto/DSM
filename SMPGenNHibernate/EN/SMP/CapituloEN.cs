
using System;
// Definición clase CapituloEN
namespace SMPGenNHibernate.EN.SMP
{
public partial class CapituloEN
{
/**
 *	Atributo temporada
 */
private SMPGenNHibernate.EN.SMP.TemporadaEN temporada;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo comentario
 */
private System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ComentarioEN> comentario;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo imagen
 */
private string imagen;






public virtual SMPGenNHibernate.EN.SMP.TemporadaEN Temporada {
        get { return temporada; } set { temporada = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ComentarioEN> Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}





public CapituloEN()
{
        comentario = new System.Collections.Generic.List<SMPGenNHibernate.EN.SMP.ComentarioEN>();
}



public CapituloEN(int id, SMPGenNHibernate.EN.SMP.TemporadaEN temporada, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ComentarioEN> comentario, string nombre, Nullable<DateTime> fecha, string descripcion, string imagen
                  )
{
        this.init (Id, temporada, comentario, nombre, fecha, descripcion, imagen);
}


public CapituloEN(CapituloEN capitulo)
{
        this.init (Id, capitulo.Temporada, capitulo.Comentario, capitulo.Nombre, capitulo.Fecha, capitulo.Descripcion, capitulo.Imagen);
}

private void init (int id
                   , SMPGenNHibernate.EN.SMP.TemporadaEN temporada, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ComentarioEN> comentario, string nombre, Nullable<DateTime> fecha, string descripcion, string imagen)
{
        this.Id = id;


        this.Temporada = temporada;

        this.Comentario = comentario;

        this.Nombre = nombre;

        this.Fecha = fecha;

        this.Descripcion = descripcion;

        this.Imagen = imagen;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CapituloEN t = obj as CapituloEN;
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
