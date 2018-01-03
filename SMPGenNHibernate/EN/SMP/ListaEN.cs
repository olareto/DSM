
using System;
// Definición clase ListaEN
namespace SMPGenNHibernate.EN.SMP
{
public partial class ListaEN
{
/**
 *	Atributo estado
 */
private SMPGenNHibernate.Enumerated.SMP.Estado_videoEnum estado;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo usuario_1
 */
private SMPGenNHibernate.EN.SMP.UsuarioEN usuario_1;



/**
 *	Atributo serie
 */
private System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.SerieEN> serie;



/**
 *	Atributo pelicula
 */
private System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.PeliculaEN> pelicula;






public virtual SMPGenNHibernate.Enumerated.SMP.Estado_videoEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual SMPGenNHibernate.EN.SMP.UsuarioEN Usuario_1 {
        get { return usuario_1; } set { usuario_1 = value;  }
}



public virtual System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.SerieEN> Serie {
        get { return serie; } set { serie = value;  }
}



public virtual System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.PeliculaEN> Pelicula {
        get { return pelicula; } set { pelicula = value;  }
}





public ListaEN()
{
        serie = new System.Collections.Generic.List<SMPGenNHibernate.EN.SMP.SerieEN>();
        pelicula = new System.Collections.Generic.List<SMPGenNHibernate.EN.SMP.PeliculaEN>();
}



public ListaEN(int id, SMPGenNHibernate.Enumerated.SMP.Estado_videoEnum estado, SMPGenNHibernate.EN.SMP.UsuarioEN usuario_1, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.SerieEN> serie, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.PeliculaEN> pelicula
               )
{
        this.init (Id, estado, usuario_1, serie, pelicula);
}


public ListaEN(ListaEN lista)
{
        this.init (Id, lista.Estado, lista.Usuario_1, lista.Serie, lista.Pelicula);
}

private void init (int id
                   , SMPGenNHibernate.Enumerated.SMP.Estado_videoEnum estado, SMPGenNHibernate.EN.SMP.UsuarioEN usuario_1, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.SerieEN> serie, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.PeliculaEN> pelicula)
{
        this.Id = id;


        this.Estado = estado;

        this.Usuario_1 = usuario_1;

        this.Serie = serie;

        this.Pelicula = pelicula;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ListaEN t = obj as ListaEN;
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
