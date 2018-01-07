
using System;
// Definición clase CarritoEN
namespace SMPGenNHibernate.EN.SMP
{
public partial class CarritoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo usuario
 */
private SMPGenNHibernate.EN.SMP.UsuarioEN usuario;



/**
 *	Atributo precio
 */
private double precio;



/**
 *	Atributo lineas_pedido
 */
private System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.Lineas_pedidoEN> lineas_pedido;



/**
 *	Atributo admin
 */
private SMPGenNHibernate.EN.SMP.AdminEN admin;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual SMPGenNHibernate.EN.SMP.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual double Precio {
        get { return precio; } set { precio = value;  }
}



public virtual System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.Lineas_pedidoEN> Lineas_pedido {
        get { return lineas_pedido; } set { lineas_pedido = value;  }
}



public virtual SMPGenNHibernate.EN.SMP.AdminEN Admin {
        get { return admin; } set { admin = value;  }
}





public CarritoEN()
{
        lineas_pedido = new System.Collections.Generic.List<SMPGenNHibernate.EN.SMP.Lineas_pedidoEN>();
}



public CarritoEN(int id, SMPGenNHibernate.EN.SMP.UsuarioEN usuario, double precio, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.Lineas_pedidoEN> lineas_pedido, SMPGenNHibernate.EN.SMP.AdminEN admin
                 )
{
        this.init (Id, usuario, precio, lineas_pedido, admin);
}


public CarritoEN(CarritoEN carrito)
{
        this.init (Id, carrito.Usuario, carrito.Precio, carrito.Lineas_pedido, carrito.Admin);
}

private void init (int id
                   , SMPGenNHibernate.EN.SMP.UsuarioEN usuario, double precio, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.Lineas_pedidoEN> lineas_pedido, SMPGenNHibernate.EN.SMP.AdminEN admin)
{
        this.Id = id;


        this.Usuario = usuario;

        this.Precio = precio;

        this.Lineas_pedido = lineas_pedido;

        this.Admin = admin;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CarritoEN t = obj as CarritoEN;
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
