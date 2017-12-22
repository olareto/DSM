
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
 * Clase oferta:
 *
 */

namespace SMPGenNHibernate.CAD.SMP
{
public partial class OfertaCAD : BasicCAD, IOfertaCAD
{
public OfertaCAD() : base ()
{
}

public OfertaCAD(ISession sessionAux) : base (sessionAux)
{
}



public OfertaEN ReadOIDDefault (int id
                                )
{
        OfertaEN ofertaEN = null;

        try
        {
                SessionInitializeTransaction ();
                ofertaEN = (OfertaEN)session.Get (typeof(OfertaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in OfertaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return ofertaEN;
}

public System.Collections.Generic.IList<OfertaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<OfertaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(OfertaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<OfertaEN>();
                        else
                                result = session.CreateCriteria (typeof(OfertaEN)).List<OfertaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in OfertaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (OfertaEN oferta)
{
        try
        {
                SessionInitializeTransaction ();
                OfertaEN ofertaEN = (OfertaEN)session.Load (typeof(OfertaEN), oferta.Id);


                ofertaEN.Tiempo_inicial = oferta.Tiempo_inicial;


                ofertaEN.Tiempo_final = oferta.Tiempo_final;


                ofertaEN.Descuento = oferta.Descuento;

                session.Update (ofertaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in OfertaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (OfertaEN oferta)
{
        try
        {
                SessionInitializeTransaction ();
                if (oferta.Articulo != null) {
                        // Argumento OID y no colección.
                        oferta.Articulo = (SMPGenNHibernate.EN.SMP.ArticuloEN)session.Load (typeof(SMPGenNHibernate.EN.SMP.ArticuloEN), oferta.Articulo.Id);

                        oferta.Articulo.Oferta
                                = oferta;
                }

                session.Save (oferta);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in OfertaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return oferta.Id;
}

public void Modify (OfertaEN oferta)
{
        try
        {
                SessionInitializeTransaction ();
                OfertaEN ofertaEN = (OfertaEN)session.Load (typeof(OfertaEN), oferta.Id);

                ofertaEN.Tiempo_inicial = oferta.Tiempo_inicial;


                ofertaEN.Tiempo_final = oferta.Tiempo_final;


                ofertaEN.Descuento = oferta.Descuento;

                session.Update (ofertaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in OfertaCAD.", ex);
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
                OfertaEN ofertaEN = (OfertaEN)session.Load (typeof(OfertaEN), id);
                session.Delete (ofertaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in OfertaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: OfertaEN
public OfertaEN ReadOID (int id
                         )
{
        OfertaEN ofertaEN = null;

        try
        {
                SessionInitializeTransaction ();
                ofertaEN = (OfertaEN)session.Get (typeof(OfertaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in OfertaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return ofertaEN;
}

public System.Collections.Generic.IList<OfertaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<OfertaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(OfertaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<OfertaEN>();
                else
                        result = session.CreateCriteria (typeof(OfertaEN)).List<OfertaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in OfertaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
