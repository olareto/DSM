

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
 *      Definition of the class CarritoCEN
 *
 */
public partial class CarritoCEN
{
private ICarritoCAD _ICarritoCAD;

public CarritoCEN()
{
        this._ICarritoCAD = new CarritoCAD ();
}

public CarritoCEN(ICarritoCAD _ICarritoCAD)
{
        this._ICarritoCAD = _ICarritoCAD;
}

public ICarritoCAD get_ICarritoCAD ()
{
        return this._ICarritoCAD;
}

public int New_ (string p_usuario, double p_precio)
{
        CarritoEN carritoEN = null;
        int oid;

        //Initialized CarritoEN
        carritoEN = new CarritoEN ();

        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                carritoEN.Usuario = new SMPGenNHibernate.EN.SMP.UsuarioEN ();
                carritoEN.Usuario.Email = p_usuario;
        }

        carritoEN.Precio = p_precio;

        //Call to CarritoCAD

        oid = _ICarritoCAD.New_ (carritoEN);
        return oid;
}

public void Modify (int p_carrito_OID, double p_precio)
{
        CarritoEN carritoEN = null;

        //Initialized CarritoEN
        carritoEN = new CarritoEN ();
        carritoEN.Id = p_carrito_OID;
        carritoEN.Precio = p_precio;
        //Call to CarritoCAD

        _ICarritoCAD.Modify (carritoEN);
}

public void Destroy (int id
                     )
{
        _ICarritoCAD.Destroy (id);
}

public CarritoEN ReadOID (int id
                          )
{
        CarritoEN carritoEN = null;

        carritoEN = _ICarritoCAD.ReadOID (id);
        return carritoEN;
}

public System.Collections.Generic.IList<CarritoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CarritoEN> list = null;

        list = _ICarritoCAD.ReadAll (first, size);
        return list;
}
public void Addlinea (int p_carrito_OID, System.Collections.Generic.IList<int> p_lineas_pedido_OIDs)
{
        //Call to CarritoCAD

        _ICarritoCAD.Addlinea (p_carrito_OID, p_lineas_pedido_OIDs);
}
public void Dellinea (int p_carrito_OID, System.Collections.Generic.IList<int> p_lineas_pedido_OIDs)
{
        //Call to CarritoCAD

        _ICarritoCAD.Dellinea (p_carrito_OID, p_lineas_pedido_OIDs);
}
public void Addusuario (int p_carrito_OID, string p_usuario_OID)
{
        //Call to CarritoCAD

        _ICarritoCAD.Addusuario (p_carrito_OID, p_usuario_OID);
}
}
}
