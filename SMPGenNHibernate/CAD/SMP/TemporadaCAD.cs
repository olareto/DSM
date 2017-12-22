
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
 * Clase Temporada:
 *
 */

namespace SMPGenNHibernate.CAD.SMP
{
public partial class TemporadaCAD : BasicCAD, ITemporadaCAD
{
public TemporadaCAD() : base ()
{
}

public TemporadaCAD(ISession sessionAux) : base (sessionAux)
{
}



public TemporadaEN ReadOIDDefault (int id
                                   )
{
        TemporadaEN temporadaEN = null;

        try
        {
                SessionInitializeTransaction ();
                temporadaEN = (TemporadaEN)session.Get (typeof(TemporadaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in TemporadaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return temporadaEN;
}

public System.Collections.Generic.IList<TemporadaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<TemporadaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(TemporadaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<TemporadaEN>();
                        else
                                result = session.CreateCriteria (typeof(TemporadaEN)).List<TemporadaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in TemporadaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (TemporadaEN temporada)
{
        try
        {
                SessionInitializeTransaction ();
                TemporadaEN temporadaEN = (TemporadaEN)session.Load (typeof(TemporadaEN), temporada.Id);



                temporadaEN.Nombre = temporada.Nombre;

                session.Update (temporadaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in TemporadaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


//Sin e: ReadOID
//Con e: TemporadaEN
public TemporadaEN ReadOID (int id
                            )
{
        TemporadaEN temporadaEN = null;

        try
        {
                SessionInitializeTransaction ();
                temporadaEN = (TemporadaEN)session.Get (typeof(TemporadaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in TemporadaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return temporadaEN;
}

public System.Collections.Generic.IList<TemporadaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TemporadaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(TemporadaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<TemporadaEN>();
                else
                        result = session.CreateCriteria (typeof(TemporadaEN)).List<TemporadaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in TemporadaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public int New_ (TemporadaEN temporada)
{
        try
        {
                SessionInitializeTransaction ();
                if (temporada.Serie != null) {
                        // Argumento OID y no colección.
                        temporada.Serie = (SMPGenNHibernate.EN.SMP.SerieEN)session.Load (typeof(SMPGenNHibernate.EN.SMP.SerieEN), temporada.Serie.Id);

                        temporada.Serie.Temporada
                        .Add (temporada);
                }

                session.Save (temporada);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in TemporadaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return temporada.Id;
}

public void Modify (TemporadaEN temporada)
{
        try
        {
                SessionInitializeTransaction ();
                TemporadaEN temporadaEN = (TemporadaEN)session.Load (typeof(TemporadaEN), temporada.Id);

                temporadaEN.Nombre = temporada.Nombre;

                session.Update (temporadaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in TemporadaCAD.", ex);
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
                TemporadaEN temporadaEN = (TemporadaEN)session.Load (typeof(TemporadaEN), id);
                session.Delete (temporadaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in TemporadaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Borrarcap (int p_Temporada_OID, System.Collections.Generic.IList<int> p_capitulo_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                SMPGenNHibernate.EN.SMP.TemporadaEN temporadaEN = null;
                temporadaEN = (TemporadaEN)session.Load (typeof(TemporadaEN), p_Temporada_OID);

                SMPGenNHibernate.EN.SMP.CapituloEN capituloENAux = null;
                if (temporadaEN.Capitulo != null) {
                        foreach (int item in p_capitulo_OIDs) {
                                capituloENAux = (SMPGenNHibernate.EN.SMP.CapituloEN)session.Load (typeof(SMPGenNHibernate.EN.SMP.CapituloEN), item);
                                if (temporadaEN.Capitulo.Contains (capituloENAux) == true) {
                                        temporadaEN.Capitulo.Remove (capituloENAux);
                                        capituloENAux.Temporada = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_capitulo_OIDs you are trying to unrelationer, doesn't exist in TemporadaEN");
                        }
                }

                session.Update (temporadaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in TemporadaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Addcap (int p_Temporada_OID, System.Collections.Generic.IList<int> p_capitulo_OIDs)
{
        SMPGenNHibernate.EN.SMP.TemporadaEN temporadaEN = null;
        try
        {
                SessionInitializeTransaction ();
                temporadaEN = (TemporadaEN)session.Load (typeof(TemporadaEN), p_Temporada_OID);
                SMPGenNHibernate.EN.SMP.CapituloEN capituloENAux = null;
                if (temporadaEN.Capitulo == null) {
                        temporadaEN.Capitulo = new System.Collections.Generic.List<SMPGenNHibernate.EN.SMP.CapituloEN>();
                }

                foreach (int item in p_capitulo_OIDs) {
                        capituloENAux = new SMPGenNHibernate.EN.SMP.CapituloEN ();
                        capituloENAux = (SMPGenNHibernate.EN.SMP.CapituloEN)session.Load (typeof(SMPGenNHibernate.EN.SMP.CapituloEN), item);
                        capituloENAux.Temporada = temporadaEN;

                        temporadaEN.Capitulo.Add (capituloENAux);
                }


                session.Update (temporadaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in TemporadaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
