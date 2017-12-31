
using System;
// Definición clase VideoEN
namespace SMPGenNHibernate.EN.SMP
{
public partial class VideoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo lista
 */
private System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ListaEN> lista;



/**
 *	Atributo valoracion
 */
private SMPGenNHibernate.Enumerated.SMP.ValoracionEnum valoracion;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo imagen
 */
private string imagen;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ListaEN> Lista {
        get { return lista; } set { lista = value;  }
}



public virtual SMPGenNHibernate.Enumerated.SMP.ValoracionEnum Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}





public VideoEN()
{
        lista = new System.Collections.Generic.List<SMPGenNHibernate.EN.SMP.ListaEN>();
}



public VideoEN(int id, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ListaEN> lista, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum valoracion, string nombre, string imagen
               )
{
        this.init (Id, lista, valoracion, nombre, imagen);
}


public VideoEN(VideoEN video)
{
        this.init (Id, video.Lista, video.Valoracion, video.Nombre, video.Imagen);
}

private void init (int id
                   , System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ListaEN> lista, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum valoracion, string nombre, string imagen)
{
        this.Id = id;


        this.Lista = lista;

        this.Valoracion = valoracion;

        this.Nombre = nombre;

        this.Imagen = imagen;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        VideoEN t = obj as VideoEN;
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
