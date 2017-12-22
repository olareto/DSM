
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






public virtual string Talla {
        get { return talla; } set { talla = value;  }
}





public ProductoEN() : base ()
{
}



public ProductoEN(int id, string talla
                  , string nombre, double precio, string descripcion, string imagen, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ComentarioEN> comentario, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum valor, SMPGenNHibernate.EN.SMP.Lineas_pedidoEN lineas_pedido, int stock, SMPGenNHibernate.EN.SMP.OfertaEN oferta
                  )
{
        this.init (Id, talla, nombre, precio, descripcion, imagen, comentario, valor, lineas_pedido, stock, oferta);
}


public ProductoEN(ProductoEN producto)
{
        this.init (Id, producto.Talla, producto.Nombre, producto.Precio, producto.Descripcion, producto.Imagen, producto.Comentario, producto.Valor, producto.Lineas_pedido, producto.Stock, producto.Oferta);
}

private void init (int id
                   , string talla, string nombre, double precio, string descripcion, string imagen, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ComentarioEN> comentario, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum valor, SMPGenNHibernate.EN.SMP.Lineas_pedidoEN lineas_pedido, int stock, SMPGenNHibernate.EN.SMP.OfertaEN oferta)
{
        this.Id = id;


        this.Talla = talla;

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
