
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






public virtual System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.TemporadaEN> Temporada {
        get { return temporada; } set { temporada = value;  }
}





public SerieEN() : base ()
{
        temporada = new System.Collections.Generic.List<SMPGenNHibernate.EN.SMP.TemporadaEN>();
}



public SerieEN(int id, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.TemporadaEN> temporada
               , System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ListaEN> lista, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum valoracion, string nombre, string imagen
               )
{
        this.init (Id, temporada, lista, valoracion, nombre, imagen);
}


public SerieEN(SerieEN serie)
{
        this.init (Id, serie.Temporada, serie.Lista, serie.Valoracion, serie.Nombre, serie.Imagen);
}

private void init (int id
                   , System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.TemporadaEN> temporada, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ListaEN> lista, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum valoracion, string nombre, string imagen)
{
        this.Id = id;


        this.Temporada = temporada;

        this.Lista = lista;

        this.Valoracion = valoracion;

        this.Nombre = nombre;

        this.Imagen = imagen;
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
