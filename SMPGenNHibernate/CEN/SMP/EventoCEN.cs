

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using SMPGenNHibernate.Exceptions;

using SMPGenNHibernate.EN.SMP;
using SMPGenNHibernate.CAD.SMP;


namespace SMPGenNHibernate.CEN.SMP
{
/*
 *      Definition of the class EventoCEN
 *
 */
public partial class EventoCEN
{
private IEventoCAD _IEventoCAD;

public EventoCEN()
{
        this._IEventoCAD = new EventoCAD ();
}

public EventoCEN(IEventoCAD _IEventoCAD)
{
        this._IEventoCAD = _IEventoCAD;
}

public IEventoCAD get_IEventoCAD ()
{
        return this._IEventoCAD;
}

public int New_ (string p_nombre, double p_precio, string p_descripcion, string p_imagen, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum p_valor, int p_stock, string p_descriplarga, string p_imagran, string p_tipo)
{
        EventoEN eventoEN = null;
        int oid;

        //Initialized EventoEN
        eventoEN = new EventoEN ();
        eventoEN.Nombre = p_nombre;

        eventoEN.Precio = p_precio;

        eventoEN.Descripcion = p_descripcion;

        eventoEN.Imagen = p_imagen;

        eventoEN.Valor = p_valor;

        eventoEN.Stock = p_stock;

        eventoEN.Descriplarga = p_descriplarga;

        eventoEN.Imagran = p_imagran;

        eventoEN.Tipo = p_tipo;

        //Call to EventoCAD

        oid = _IEventoCAD.New_ (eventoEN);
        return oid;
}

public void Modify (int p_evento_OID, string p_nombre, double p_precio, string p_descripcion, string p_imagen, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum p_valor, int p_stock, string p_descriplarga, string p_imagran, string p_tipo)
{
        EventoEN eventoEN = null;

        //Initialized EventoEN
        eventoEN = new EventoEN ();
        eventoEN.Id = p_evento_OID;
        eventoEN.Nombre = p_nombre;
        eventoEN.Precio = p_precio;
        eventoEN.Descripcion = p_descripcion;
        eventoEN.Imagen = p_imagen;
        eventoEN.Valor = p_valor;
        eventoEN.Stock = p_stock;
        eventoEN.Descriplarga = p_descriplarga;
        eventoEN.Imagran = p_imagran;
        eventoEN.Tipo = p_tipo;
        //Call to EventoCAD

        _IEventoCAD.Modify (eventoEN);
}

public void Destroy (int id
                     )
{
        _IEventoCAD.Destroy (id);
}

public System.Collections.Generic.IList<EventoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EventoEN> list = null;

        list = _IEventoCAD.ReadAll (first, size);
        return list;
}
public EventoEN ReadOID (int id
                         )
{
        EventoEN eventoEN = null;

        eventoEN = _IEventoCAD.ReadOID (id);
        return eventoEN;
}

public System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.EventoEN> Filtronombre (string p_nombre)
{
        return _IEventoCAD.Filtronombre (p_nombre);
}
public System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.EventoEN> Filtroprecio (double? p_min, double ? p_max)
{
        return _IEventoCAD.Filtroprecio (p_min, p_max);
}
public System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.EventoEN> Filtrovalor (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum ? p_valor)
{
        return _IEventoCAD.Filtrovalor (p_valor);
}
public System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.EventoEN> Filtrotipo (string p_tipo)
{
        return _IEventoCAD.Filtrotipo (p_tipo);
}
}
}
