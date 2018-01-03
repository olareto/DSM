
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
 *	Atributo evento
 */
private SMPGenNHibernate.EN.SMP.EventoEN evento;



/**
 *	Atributo producto
 */
private SMPGenNHibernate.EN.SMP.ProductoEN producto;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual SMPGenNHibernate.EN.SMP.CarritoEN Carrito {
        get { return carrito; } set { carrito = value;  }
}



public virtual int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}



public virtual SMPGenNHibernate.EN.SMP.EventoEN Evento {
        get { return evento; } set { evento = value;  }
}



public virtual SMPGenNHibernate.EN.SMP.ProductoEN Producto {
        get { return producto; } set { producto = value;  }
}





public Lineas_pedidoEN()
{
}



public Lineas_pedidoEN(int id, SMPGenNHibernate.EN.SMP.CarritoEN carrito, int cantidad, SMPGenNHibernate.EN.SMP.EventoEN evento, SMPGenNHibernate.EN.SMP.ProductoEN producto
                       )
{
        this.init (Id, carrito, cantidad, evento, producto);
}


public Lineas_pedidoEN(Lineas_pedidoEN lineas_pedido)
{
        this.init (Id, lineas_pedido.Carrito, lineas_pedido.Cantidad, lineas_pedido.Evento, lineas_pedido.Producto);
}

private void init (int id
                   , SMPGenNHibernate.EN.SMP.CarritoEN carrito, int cantidad, SMPGenNHibernate.EN.SMP.EventoEN evento, SMPGenNHibernate.EN.SMP.ProductoEN producto)
{
        this.Id = id;


        this.Carrito = carrito;

        this.Cantidad = cantidad;

        this.Evento = evento;

        this.Producto = producto;
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
