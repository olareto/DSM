
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
}



public VideoEN(int id, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum valoracion, string nombre, string imagen
               )
{
        this.init (Id, valoracion, nombre, imagen);
}


public VideoEN(VideoEN video)
{
        this.init (Id, video.Valoracion, video.Nombre, video.Imagen);
}

private void init (int id
                   , SMPGenNHibernate.Enumerated.SMP.ValoracionEnum valoracion, string nombre, string imagen)
{
        this.Id = id;


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
