
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






public virtual string Tipo {
        get { return tipo; } set { tipo = value;  }
}





public EventoEN() : base ()
{
}



public EventoEN(int id, string tipo
                , string nombre, double precio, string descripcion, string imagen, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ComentarioEN> comentario, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum valor, SMPGenNHibernate.EN.SMP.Lineas_pedidoEN lineas_pedido, int stock, SMPGenNHibernate.EN.SMP.OfertaEN oferta
                )
{
        this.init (Id, tipo, nombre, precio, descripcion, imagen, comentario, valor, lineas_pedido, stock, oferta);
}


public EventoEN(EventoEN evento)
{
        this.init (Id, evento.Tipo, evento.Nombre, evento.Precio, evento.Descripcion, evento.Imagen, evento.Comentario, evento.Valor, evento.Lineas_pedido, evento.Stock, evento.Oferta);
}

private void init (int id
                   , string tipo, string nombre, double precio, string descripcion, string imagen, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ComentarioEN> comentario, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum valor, SMPGenNHibernate.EN.SMP.Lineas_pedidoEN lineas_pedido, int stock, SMPGenNHibernate.EN.SMP.OfertaEN oferta)
{
        this.Id = id;


        this.Tipo = tipo;

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
