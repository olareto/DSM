
using System;
using System.Text;
using SMPGenNHibernate.CEN.SMP;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using SMPGenNHibernate.EN.SMP;
using SMPGenNHibernate.Exceptions;


/*
 * Clase carrito:
 *
 */

namespace SMPGenNHibernate.CAD.SMP
{
public partial class CarritoCAD : BasicCAD, ICarritoCAD
{
public CarritoCAD() : base ()
{
}

public CarritoCAD(ISession sessionAux) : base (sessionAux)
{
}



public CarritoEN ReadOIDDefault (int id
                                 )
{
        CarritoEN carritoEN = null;

        try
        {
                SessionInitializeTransaction ();
                carritoEN = (CarritoEN)session.Get (typeof(CarritoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in CarritoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return carritoEN;
}

public System.Collections.Generic.IList<CarritoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CarritoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CarritoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CarritoEN>();
                        else
                                result = session.CreateCriteria (typeof(CarritoEN)).List<CarritoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in CarritoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CarritoEN carrito)
{
        try
        {
                SessionInitializeTransaction ();
                CarritoEN carritoEN = (CarritoEN)session.Load (typeof(CarritoEN), carrito.Id);


                carritoEN.Precio = carrito.Precio;


                session.Update (carritoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in CarritoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (CarritoEN carrito)
{
        try
        {
                SessionInitializeTransaction ();
                if (carrito.Usuario != null) {
                        // Argumento OID y no colección.
                        carrito.Usuario = (SMPGenNHibernate.EN.SMP.UsuarioEN)session.Load (typeof(SMPGenNHibernate.EN.SMP.UsuarioEN), carrito.Usuario.Email);

                        carrito.Usuario.Carrito
                                = carrito;
                }

                session.Save (carrito);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in CarritoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return carrito.Id;
}

public void Modify (CarritoEN carrito)
{
        try
        {
                SessionInitializeTransaction ();
                CarritoEN carritoEN = (CarritoEN)session.Load (typeof(CarritoEN), carrito.Id);

                carritoEN.Precio = carrito.Precio;

                session.Update (carritoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in CarritoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                CarritoEN carritoEN = (CarritoEN)session.Load (typeof(CarritoEN), id);
                session.Delete (carritoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in CarritoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: CarritoEN
public CarritoEN ReadOID (int id
                          )
{
        CarritoEN carritoEN = null;

        try
        {
                SessionInitializeTransaction ();
                carritoEN = (CarritoEN)session.Get (typeof(CarritoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in CarritoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return carritoEN;
}

public System.Collections.Generic.IList<CarritoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CarritoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CarritoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CarritoEN>();
                else
                        result = session.CreateCriteria (typeof(CarritoEN)).List<CarritoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in CarritoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void Addlinea (int p_carrito_OID, System.Collections.Generic.IList<int> p_lineas_pedido_OIDs)
{
        SMPGenNHibernate.EN.SMP.CarritoEN carritoEN = null;
        try
        {
                SessionInitializeTransaction ();
                carritoEN = (CarritoEN)session.Load (typeof(CarritoEN), p_carrito_OID);
                SMPGenNHibernate.EN.SMP.Lineas_pedidoEN lineas_pedidoENAux = null;
                if (carritoEN.Lineas_pedido == null) {
                        carritoEN.Lineas_pedido = new System.Collections.Generic.List<SMPGenNHibernate.EN.SMP.Lineas_pedidoEN>();
                }

                foreach (int item in p_lineas_pedido_OIDs) {
                        lineas_pedidoENAux = new SMPGenNHibernate.EN.SMP.Lineas_pedidoEN ();
                        lineas_pedidoENAux = (SMPGenNHibernate.EN.SMP.Lineas_pedidoEN)session.Load (typeof(SMPGenNHibernate.EN.SMP.Lineas_pedidoEN), item);
                        lineas_pedidoENAux.Carrito = carritoEN;

                        carritoEN.Lineas_pedido.Add (lineas_pedidoENAux);
                }


                session.Update (carritoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in CarritoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
