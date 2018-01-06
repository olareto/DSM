
using System;
// Definición clase SerieEN
namespace SMPGenNHibernate.EN.SMP
{
public partial class SerieEN                                                                        : SMPGenNHibernate.EN.SMP.VideoEN


{
/**
 *	Atributo temporada
 */
private System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.TemporadaEN> temporada;



/**
 *	Atributo lista
 */
private System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ListaEN> lista;



/**
 *	Atributo anyofin
 */
private int anyofin;



/**
 *	Atributo finalizada
 */
private bool finalizada;






public virtual System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.TemporadaEN> Temporada {
        get { return temporada; } set { temporada = value;  }
}



public virtual System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ListaEN> Lista {
        get { return lista; } set { lista = value;  }
}



public virtual int Anyofin {
        get { return anyofin; } set { anyofin = value;  }
}



public virtual bool Finalizada {
        get { return finalizada; } set { finalizada = value;  }
}





public SerieEN() : base ()
{
        temporada = new System.Collections.Generic.List<SMPGenNHibernate.EN.SMP.TemporadaEN>();
        lista = new System.Collections.Generic.List<SMPGenNHibernate.EN.SMP.ListaEN>();
}



public SerieEN(int id, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.TemporadaEN> temporada, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ListaEN> lista, int anyofin, bool finalizada
               , SMPGenNHibernate.Enumerated.SMP.ValoracionEnum valoracion, string nombre, string imagen, string descriplarga, string descripcion, string genero, int anyo, string imagran
               )
{
        this.init (Id, temporada, lista, anyofin, finalizada, valoracion, nombre, imagen, descriplarga, descripcion, genero, anyo, imagran);
}


public SerieEN(SerieEN serie)
{
        this.init (Id, serie.Temporada, serie.Lista, serie.Anyofin, serie.Finalizada, serie.Valoracion, serie.Nombre, serie.Imagen, serie.Descriplarga, serie.Descripcion, serie.Genero, serie.Anyo, serie.Imagran);
}

private void init (int id
                   , System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.TemporadaEN> temporada, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ListaEN> lista, int anyofin, bool finalizada, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum valoracion, string nombre, string imagen, string descriplarga, string descripcion, string genero, int anyo, string imagran)
{
        this.Id = id;


        this.Temporada = temporada;

        this.Lista = lista;

        this.Anyofin = anyofin;

        this.Finalizada = finalizada;

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
        SerieEN t = obj as SerieEN;
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
