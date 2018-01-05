
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



/**
 *	Atributo descriplarga
 */
private string descriplarga;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo genero
 */
private string genero;



/**
 *	Atributo anyo
 */
private Nullable<DateTime> anyo;



/**
 *	Atributo imagran
 */
private string imagran;






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



public virtual string Descriplarga {
        get { return descriplarga; } set { descriplarga = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual string Genero {
        get { return genero; } set { genero = value;  }
}



public virtual Nullable<DateTime> Anyo {
        get { return anyo; } set { anyo = value;  }
}



public virtual string Imagran {
        get { return imagran; } set { imagran = value;  }
}





public VideoEN()
{
}



public VideoEN(int id, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum valoracion, string nombre, string imagen, string descriplarga, string descripcion, string genero, Nullable<DateTime> anyo, string imagran
               )
{
        this.init (Id, valoracion, nombre, imagen, descriplarga, descripcion, genero, anyo, imagran);
}


public VideoEN(VideoEN video)
{
        this.init (Id, video.Valoracion, video.Nombre, video.Imagen, video.Descriplarga, video.Descripcion, video.Genero, video.Anyo, video.Imagran);
}

private void init (int id
                   , SMPGenNHibernate.Enumerated.SMP.ValoracionEnum valoracion, string nombre, string imagen, string descriplarga, string descripcion, string genero, Nullable<DateTime> anyo, string imagran)
{
        this.Id = id;


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
