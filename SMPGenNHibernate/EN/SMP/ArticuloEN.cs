
using System;
// Definición clase ArticuloEN
namespace SMPGenNHibernate.EN.SMP
{
public partial class ArticuloEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo precio
 */
private double precio;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo imagen
 */
private string imagen;



/**
 *	Atributo comentario
 */
private System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ComentarioEN> comentario;



/**
 *	Atributo valor
 */
private SMPGenNHibernate.Enumerated.SMP.ValoracionEnum valor;



/**
 *	Atributo lineas_pedido
 */
private SMPGenNHibernate.EN.SMP.Lineas_pedidoEN lineas_pedido;



/**
 *	Atributo stock
 */
private int stock;



/**
 *	Atributo oferta
 */
private SMPGenNHibernate.EN.SMP.OfertaEN oferta;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual double Precio {
        get { return precio; } set { precio = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}



public virtual System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ComentarioEN> Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual SMPGenNHibernate.Enumerated.SMP.ValoracionEnum Valor {
        get { return valor; } set { valor = value;  }
}



public virtual SMPGenNHibernate.EN.SMP.Lineas_pedidoEN Lineas_pedido {
        get { return lineas_pedido; } set { lineas_pedido = value;  }
}



public virtual int Stock {
        get { return stock; } set { stock = value;  }
}



public virtual SMPGenNHibernate.EN.SMP.OfertaEN Oferta {
        get { return oferta; } set { oferta = value;  }
}





public ArticuloEN()
{
        comentario = new System.Collections.Generic.List<SMPGenNHibernate.EN.SMP.ComentarioEN>();
}



public ArticuloEN(int id, string nombre, double precio, string descripcion, string imagen, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ComentarioEN> comentario, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum valor, SMPGenNHibernate.EN.SMP.Lineas_pedidoEN lineas_pedido, int stock, SMPGenNHibernate.EN.SMP.OfertaEN oferta
                  )
{
        this.init (Id, nombre, precio, descripcion, imagen, comentario, valor, lineas_pedido, stock, oferta);
}


public ArticuloEN(ArticuloEN articulo)
{
        this.init (Id, articulo.Nombre, articulo.Precio, articulo.Descripcion, articulo.Imagen, articulo.Comentario, articulo.Valor, articulo.Lineas_pedido, articulo.Stock, articulo.Oferta);
}

private void init (int id
                   , string nombre, double precio, string descripcion, string imagen, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ComentarioEN> comentario, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum valor, SMPGenNHibernate.EN.SMP.Lineas_pedidoEN lineas_pedido, int stock, SMPGenNHibernate.EN.SMP.OfertaEN oferta)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Precio = precio;

        this.Descripcion = descripcion;

        this.Imagen = imagen;

        this.Comentario = comentario;

        this.Valor = valor;

        this.Lineas_pedido = lineas_pedido;

        this.Stock = stock;

        this.Oferta = oferta;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ArticuloEN t = obj as ArticuloEN;
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
