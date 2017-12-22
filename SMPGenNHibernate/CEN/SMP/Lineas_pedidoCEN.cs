

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
 *      Definition of the class Lineas_pedidoCEN
 *
 */
public partial class Lineas_pedidoCEN
{
private ILineas_pedidoCAD _ILineas_pedidoCAD;

public Lineas_pedidoCEN()
{
        this._ILineas_pedidoCAD = new Lineas_pedidoCAD ();
}

public Lineas_pedidoCEN(ILineas_pedidoCAD _ILineas_pedidoCAD)
{
        this._ILineas_pedidoCAD = _ILineas_pedidoCAD;
}

public ILineas_pedidoCAD get_ILineas_pedidoCAD ()
{
        return this._ILineas_pedidoCAD;
}

public int New_ (int p_carrito, int p_cantidad, int p_articulo_0)
{
        Lineas_pedidoEN lineas_pedidoEN = null;
        int oid;

        //Initialized Lineas_pedidoEN
        lineas_pedidoEN = new Lineas_pedidoEN ();

        if (p_carrito != -1) {
                // El argumento p_carrito -> Property carrito es oid = false
                // Lista de oids id
                lineas_pedidoEN.Carrito = new SMPGenNHibernate.EN.SMP.CarritoEN ();
                lineas_pedidoEN.Carrito.Id = p_carrito;
        }

        lineas_pedidoEN.Cantidad = p_cantidad;


        if (p_articulo_0 != -1) {
                // El argumento p_articulo_0 -> Property articulo_0 es oid = false
                // Lista de oids id
                lineas_pedidoEN.Articulo_0 = new SMPGenNHibernate.EN.SMP.ArticuloEN ();
                lineas_pedidoEN.Articulo_0.Id = p_articulo_0;
        }

        //Call to Lineas_pedidoCAD

        oid = _ILineas_pedidoCAD.New_ (lineas_pedidoEN);
        return oid;
}

public void Modify (int p_lineas_pedido_OID, int p_cantidad)
{
        Lineas_pedidoEN lineas_pedidoEN = null;

        //Initialized Lineas_pedidoEN
        lineas_pedidoEN = new Lineas_pedidoEN ();
        lineas_pedidoEN.Id = p_lineas_pedido_OID;
        lineas_pedidoEN.Cantidad = p_cantidad;
        //Call to Lineas_pedidoCAD

        _ILineas_pedidoCAD.Modify (lineas_pedidoEN);
}

public void Destroy (int id
                     )
{
        _ILineas_pedidoCAD.Destroy (id);
}

public Lineas_pedidoEN ReadOID (int id
                                )
{
        Lineas_pedidoEN lineas_pedidoEN = null;

        lineas_pedidoEN = _ILineas_pedidoCAD.ReadOID (id);
        return lineas_pedidoEN;
}

public System.Collections.Generic.IList<Lineas_pedidoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<Lineas_pedidoEN> list = null;

        list = _ILineas_pedidoCAD.ReadAll (first, size);
        return list;
}
}
}
