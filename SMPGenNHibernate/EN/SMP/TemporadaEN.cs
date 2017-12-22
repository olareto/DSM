
using System;
// Definición clase TemporadaEN
namespace SMPGenNHibernate.EN.SMP
{
public partial class TemporadaEN
{
/**
 *	Atributo capitulo
 */
private System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.CapituloEN> capitulo;



/**
 *	Atributo serie
 */
private SMPGenNHibernate.EN.SMP.SerieEN serie;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo nombre
 */
private string nombre;






public virtual System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.CapituloEN> Capitulo {
        get { return capitulo; } set { capitulo = value;  }
}



public virtual SMPGenNHibernate.EN.SMP.SerieEN Serie {
        get { return serie; } set { serie = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}





public TemporadaEN()
{
        capitulo = new System.Collections.Generic.List<SMPGenNHibernate.EN.SMP.CapituloEN>();
}



public TemporadaEN(int id, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.CapituloEN> capitulo, SMPGenNHibernate.EN.SMP.SerieEN serie, string nombre
                   )
{
        this.init (Id, capitulo, serie, nombre);
}


public TemporadaEN(TemporadaEN temporada)
{
        this.init (Id, temporada.Capitulo, temporada.Serie, temporada.Nombre);
}

private void init (int id
                   , System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.CapituloEN> capitulo, SMPGenNHibernate.EN.SMP.SerieEN serie, string nombre)
{
        this.Id = id;


        this.Capitulo = capitulo;

        this.Serie = serie;

        this.Nombre = nombre;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        TemporadaEN t = obj as TemporadaEN;
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
