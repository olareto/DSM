
using System;
// Definición clase ProductoEN
namespace SMPGenNHibernate.EN.SMP
{
public partial class ProductoEN                                                                     : SMPGenNHibernate.EN.SMP.ArticuloEN


{
/**
 *	Atributo talla
 */
private string talla;



/**
 *	Atributo lineas_pedido_0
 */
private System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.Lineas_pedidoEN> lineas_pedido_0;






public virtual string Talla {
        get { return talla; } set { talla = value;  }
}



public virtual System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.Lineas_pedidoEN> Lineas_pedido_0 {
        get { return lineas_pedido_0; } set { lineas_pedido_0 = value;  }
}





public ProductoEN() : base ()
{
        lineas_pedido_0 = new System.Collections.Generic.List<SMPGenNHibernate.EN.SMP.Lineas_pedidoEN>();
}



public ProductoEN(int id, string talla, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.Lineas_pedidoEN> lineas_pedido_0
                  , string nombre, double precio, string descripcion, string imagen, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ComentarioEN> comentario, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum valor, int stock, SMPGenNHibernate.EN.SMP.OfertaEN oferta, string descriplarga, string imagran
                  )
{
        this.init (Id, talla, lineas_pedido_0, nombre, precio, descripcion, imagen, comentario, valor, stock, oferta, descriplarga, imagran);
}


public ProductoEN(ProductoEN producto)
{
        this.init (Id, producto.Talla, producto.Lineas_pedido_0, producto.Nombre, producto.Precio, producto.Descripcion, producto.Imagen, producto.Comentario, producto.Valor, producto.Stock, producto.Oferta, producto.Descriplarga, producto.Imagran);
}

private void init (int id
                   , string talla, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.Lineas_pedidoEN> lineas_pedido_0, string nombre, double precio, string descripcion, string imagen, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ComentarioEN> comentario, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum valor, int stock, SMPGenNHibernate.EN.SMP.OfertaEN oferta, string descriplarga, string imagran)
{
        this.Id = id;


        this.Talla = talla;

        this.Lineas_pedido_0 = lineas_pedido_0;

        this.Nombre = nombre;

        this.Precio = precio;

        this.Descripcion = descripcion;

        this.Imagen = imagen;

        this.Comentario = comentario;

        this.Valor = valor;

        this.Stock = stock;

        this.Oferta = oferta;

        this.Descriplarga = descriplarga;

        this.Imagran = imagran;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ProductoEN t = obj as ProductoEN;
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
