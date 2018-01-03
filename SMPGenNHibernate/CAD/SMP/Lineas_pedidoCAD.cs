
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
 * Clase lineas_pedido:
 *
 */

namespace SMPGenNHibernate.CAD.SMP
{
public partial class Lineas_pedidoCAD : BasicCAD, ILineas_pedidoCAD
{
public Lineas_pedidoCAD() : base ()
{
}

public Lineas_pedidoCAD(ISession sessionAux) : base (sessionAux)
{
}



public Lineas_pedidoEN ReadOIDDefault (int id
                                       )
{
        Lineas_pedidoEN lineas_pedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineas_pedidoEN = (Lineas_pedidoEN)session.Get (typeof(Lineas_pedidoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in Lineas_pedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineas_pedidoEN;
}

public System.Collections.Generic.IList<Lineas_pedidoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<Lineas_pedidoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(Lineas_pedidoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<Lineas_pedidoEN>();
                        else
                                result = session.CreateCriteria (typeof(Lineas_pedidoEN)).List<Lineas_pedidoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in Lineas_pedidoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (Lineas_pedidoEN lineas_pedido)
{
        try
        {
                SessionInitializeTransaction ();
                Lineas_pedidoEN lineas_pedidoEN = (Lineas_pedidoEN)session.Load (typeof(Lineas_pedidoEN), lineas_pedido.Id);


                lineas_pedidoEN.Cantidad = lineas_pedido.Cantidad;



                session.Update (lineas_pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in Lineas_pedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (Lineas_pedidoEN lineas_pedido)
{
        try
        {
                SessionInitializeTransaction ();
                if (lineas_pedido.Carrito != null) {
                        // Argumento OID y no colección.
                        lineas_pedido.Carrito = (SMPGenNHibernate.EN.SMP.CarritoEN)session.Load (typeof(SMPGenNHibernate.EN.SMP.CarritoEN), lineas_pedido.Carrito.Id);

                        lineas_pedido.Carrito.Lineas_pedido
                        .Add (lineas_pedido);
                }

                session.Save (lineas_pedido);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in Lineas_pedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineas_pedido.Id;
}

public void Modify (Lineas_pedidoEN lineas_pedido)
{
        try
        {
                SessionInitializeTransaction ();
                Lineas_pedidoEN lineas_pedidoEN = (Lineas_pedidoEN)session.Load (typeof(Lineas_pedidoEN), lineas_pedido.Id);

                lineas_pedidoEN.Cantidad = lineas_pedido.Cantidad;

                session.Update (lineas_pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in Lineas_pedidoCAD.", ex);
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
                Lineas_pedidoEN lineas_pedidoEN = (Lineas_pedidoEN)session.Load (typeof(Lineas_pedidoEN), id);
                session.Delete (lineas_pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in Lineas_pedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: Lineas_pedidoEN
public Lineas_pedidoEN ReadOID (int id
                                )
{
        Lineas_pedidoEN lineas_pedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineas_pedidoEN = (Lineas_pedidoEN)session.Get (typeof(Lineas_pedidoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in Lineas_pedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineas_pedidoEN;
}

public System.Collections.Generic.IList<Lineas_pedidoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<Lineas_pedidoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(Lineas_pedidoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<Lineas_pedidoEN>();
                else
                        result = session.CreateCriteria (typeof(Lineas_pedidoEN)).List<Lineas_pedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in Lineas_pedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void Addevento (int p_lineas_pedido_OID, int p_evento_OID)
{
        SMPGenNHibernate.EN.SMP.Lineas_pedidoEN lineas_pedidoEN = null;
        try
        {
                SessionInitializeTransaction ();
                lineas_pedidoEN = (Lineas_pedidoEN)session.Load (typeof(Lineas_pedidoEN), p_lineas_pedido_OID);
                lineas_pedidoEN.Evento = (SMPGenNHibernate.EN.SMP.EventoEN)session.Load (typeof(SMPGenNHibernate.EN.SMP.EventoEN), p_evento_OID);

                lineas_pedidoEN.Evento.Lineas_pedido.Add (lineas_pedidoEN);



                session.Update (lineas_pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in Lineas_pedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Delevento (int p_lineas_pedido_OID, int p_evento_OID)
{
        try
        {
                SessionInitializeTransaction ();
                SMPGenNHibernate.EN.SMP.Lineas_pedidoEN lineas_pedidoEN = null;
                lineas_pedidoEN = (Lineas_pedidoEN)session.Load (typeof(Lineas_pedidoEN), p_lineas_pedido_OID);

                if (lineas_pedidoEN.Evento.Id == p_evento_OID) {
                        lineas_pedidoEN.Evento = null;
                }
                else
                        throw new ModelException ("The identifier " + p_evento_OID + " in p_evento_OID you are trying to unrelationer, doesn't exist in Lineas_pedidoEN");

                session.Update (lineas_pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in Lineas_pedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Addproducto (int p_lineas_pedido_OID, int p_producto_OID)
{
        SMPGenNHibernate.EN.SMP.Lineas_pedidoEN lineas_pedidoEN = null;
        try
        {
                SessionInitializeTransaction ();
                lineas_pedidoEN = (Lineas_pedidoEN)session.Load (typeof(Lineas_pedidoEN), p_lineas_pedido_OID);
                lineas_pedidoEN.Producto = (SMPGenNHibernate.EN.SMP.ProductoEN)session.Load (typeof(SMPGenNHibernate.EN.SMP.ProductoEN), p_producto_OID);

                lineas_pedidoEN.Producto.Lineas_pedido_0.Add (lineas_pedidoEN);



                session.Update (lineas_pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in Lineas_pedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Delproducto (int p_lineas_pedido_OID, int p_producto_OID)
{
        try
        {
                SessionInitializeTransaction ();
                SMPGenNHibernate.EN.SMP.Lineas_pedidoEN lineas_pedidoEN = null;
                lineas_pedidoEN = (Lineas_pedidoEN)session.Load (typeof(Lineas_pedidoEN), p_lineas_pedido_OID);

                if (lineas_pedidoEN.Producto.Id == p_producto_OID) {
                        lineas_pedidoEN.Producto = null;
                }
                else
                        throw new ModelException ("The identifier " + p_producto_OID + " in p_producto_OID you are trying to unrelationer, doesn't exist in Lineas_pedidoEN");

                session.Update (lineas_pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in Lineas_pedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
