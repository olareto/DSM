
using System;
// Definición clase Lineas_pedidoEN
namespace SMPGenNHibernate.EN.SMP
{
public partial class Lineas_pedidoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo carrito
 */
private SMPGenNHibernate.EN.SMP.CarritoEN carrito;



/**
 *	Atributo cantidad
 */
private int cantidad;



/**
 *	Atributo articulo_0
 */
private SMPGenNHibernate.EN.SMP.ArticuloEN articulo_0;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual SMPGenNHibernate.EN.SMP.CarritoEN Carrito {
        get { return carrito; } set { carrito = value;  }
}



public virtual int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}



public virtual SMPGenNHibernate.EN.SMP.ArticuloEN Articulo_0 {
        get { return articulo_0; } set { articulo_0 = value;  }
}





public Lineas_pedidoEN()
{
}



public Lineas_pedidoEN(int id, SMPGenNHibernate.EN.SMP.CarritoEN carrito, int cantidad, SMPGenNHibernate.EN.SMP.ArticuloEN articulo_0
                       )
{
        this.init (Id, carrito, cantidad, articulo_0);
}


public Lineas_pedidoEN(Lineas_pedidoEN lineas_pedido)
{
        this.init (Id, lineas_pedido.Carrito, lineas_pedido.Cantidad, lineas_pedido.Articulo_0);
}

private void init (int id
                   , SMPGenNHibernate.EN.SMP.CarritoEN carrito, int cantidad, SMPGenNHibernate.EN.SMP.ArticuloEN articulo_0)
{
        this.Id = id;


        this.Carrito = carrito;

        this.Cantidad = cantidad;

        this.Articulo_0 = articulo_0;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        Lineas_pedidoEN t = obj as Lineas_pedidoEN;
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
