
using System;
// Definición clase OfertaEN
namespace SMPGenNHibernate.EN.SMP
{
public partial class OfertaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo articulo
 */
private SMPGenNHibernate.EN.SMP.ArticuloEN articulo;



/**
 *	Atributo tiempo_inicial
 */
private Nullable<DateTime> tiempo_inicial;



/**
 *	Atributo tiempo_final
 */
private Nullable<DateTime> tiempo_final;



/**
 *	Atributo descuento
 */
private int descuento;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual SMPGenNHibernate.EN.SMP.ArticuloEN Articulo {
        get { return articulo; } set { articulo = value;  }
}



public virtual Nullable<DateTime> Tiempo_inicial {
        get { return tiempo_inicial; } set { tiempo_inicial = value;  }
}



public virtual Nullable<DateTime> Tiempo_final {
        get { return tiempo_final; } set { tiempo_final = value;  }
}



public virtual int Descuento {
        get { return descuento; } set { descuento = value;  }
}





public OfertaEN()
{
}



public OfertaEN(int id, SMPGenNHibernate.EN.SMP.ArticuloEN articulo, Nullable<DateTime> tiempo_inicial, Nullable<DateTime> tiempo_final, int descuento
                )
{
        this.init (Id, articulo, tiempo_inicial, tiempo_final, descuento);
}


public OfertaEN(OfertaEN oferta)
{
        this.init (Id, oferta.Articulo, oferta.Tiempo_inicial, oferta.Tiempo_final, oferta.Descuento);
}

private void init (int id
                   , SMPGenNHibernate.EN.SMP.ArticuloEN articulo, Nullable<DateTime> tiempo_inicial, Nullable<DateTime> tiempo_final, int descuento)
{
        this.Id = id;


        this.Articulo = articulo;

        this.Tiempo_inicial = tiempo_inicial;

        this.Tiempo_final = tiempo_final;

        this.Descuento = descuento;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        OfertaEN t = obj as OfertaEN;
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
