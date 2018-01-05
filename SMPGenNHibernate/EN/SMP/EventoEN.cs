
using System;
// Definición clase EventoEN
namespace SMPGenNHibernate.EN.SMP
{
public partial class EventoEN                                                                       : SMPGenNHibernate.EN.SMP.ArticuloEN


{
/**
 *	Atributo tipo
 */
private string tipo;



/**
 *	Atributo lineas_pedido
 */
private System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.Lineas_pedidoEN> lineas_pedido;






public virtual string Tipo {
        get { return tipo; } set { tipo = value;  }
}



public virtual System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.Lineas_pedidoEN> Lineas_pedido {
        get { return lineas_pedido; } set { lineas_pedido = value;  }
}





public EventoEN() : base ()
{
        lineas_pedido = new System.Collections.Generic.List<SMPGenNHibernate.EN.SMP.Lineas_pedidoEN>();
}



public EventoEN(int id, string tipo, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.Lineas_pedidoEN> lineas_pedido
                , string nombre, double precio, string descripcion, string imagen, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ComentarioEN> comentario, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum valor, int stock, SMPGenNHibernate.EN.SMP.OfertaEN oferta, string descriplarga, string imagran
                )
{
        this.init (Id, tipo, lineas_pedido, nombre, precio, descripcion, imagen, comentario, valor, stock, oferta, descriplarga, imagran);
}


public EventoEN(EventoEN evento)
{
        this.init (Id, evento.Tipo, evento.Lineas_pedido, evento.Nombre, evento.Precio, evento.Descripcion, evento.Imagen, evento.Comentario, evento.Valor, evento.Stock, evento.Oferta, evento.Descriplarga, evento.Imagran);
}

private void init (int id
                   , string tipo, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.Lineas_pedidoEN> lineas_pedido, string nombre, double precio, string descripcion, string imagen, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ComentarioEN> comentario, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum valor, int stock, SMPGenNHibernate.EN.SMP.OfertaEN oferta, string descriplarga, string imagran)
{
        this.Id = id;


        this.Tipo = tipo;

        this.Lineas_pedido = lineas_pedido;

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
        EventoEN t = obj as EventoEN;
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
