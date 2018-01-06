
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
 * Clase Capitulo:
 *
 */

namespace SMPGenNHibernate.CAD.SMP
{
public partial class CapituloCAD : BasicCAD, ICapituloCAD
{
public CapituloCAD() : base ()
{
}

public CapituloCAD(ISession sessionAux) : base (sessionAux)
{
}



public CapituloEN ReadOIDDefault (int id
                                  )
{
        CapituloEN capituloEN = null;

        try
        {
                SessionInitializeTransaction ();
                capituloEN = (CapituloEN)session.Get (typeof(CapituloEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in CapituloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return capituloEN;
}

public System.Collections.Generic.IList<CapituloEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CapituloEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CapituloEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CapituloEN>();
                        else
                                result = session.CreateCriteria (typeof(CapituloEN)).List<CapituloEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in CapituloCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CapituloEN capitulo)
{
        try
        {
                SessionInitializeTransaction ();
                CapituloEN capituloEN = (CapituloEN)session.Load (typeof(CapituloEN), capitulo.Id);



                capituloEN.Nombre = capitulo.Nombre;


                capituloEN.Fecha = capitulo.Fecha;


                capituloEN.Descripcion = capitulo.Descripcion;


                capituloEN.Imagen = capitulo.Imagen;


                capituloEN.Link = capitulo.Link;

                session.Update (capituloEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in CapituloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (CapituloEN capitulo)
{
        try
        {
                SessionInitializeTransaction ();
                if (capitulo.Temporada != null) {
                        // Argumento OID y no colección.
                        capitulo.Temporada = (SMPGenNHibernate.EN.SMP.TemporadaEN)session.Load (typeof(SMPGenNHibernate.EN.SMP.TemporadaEN), capitulo.Temporada.Id);

                        capitulo.Temporada.Capitulo
                        .Add (capitulo);
                }

                session.Save (capitulo);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in CapituloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return capitulo.Id;
}

public void Modify (CapituloEN capitulo)
{
        try
        {
                SessionInitializeTransaction ();
                CapituloEN capituloEN = (CapituloEN)session.Load (typeof(CapituloEN), capitulo.Id);

                capituloEN.Nombre = capitulo.Nombre;


                capituloEN.Fecha = capitulo.Fecha;


                capituloEN.Descripcion = capitulo.Descripcion;


                capituloEN.Imagen = capitulo.Imagen;


                capituloEN.Link = capitulo.Link;

                session.Update (capituloEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in CapituloCAD.", ex);
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
                CapituloEN capituloEN = (CapituloEN)session.Load (typeof(CapituloEN), id);
                session.Delete (capituloEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in CapituloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: CapituloEN
public CapituloEN ReadOID (int id
                           )
{
        CapituloEN capituloEN = null;

        try
        {
                SessionInitializeTransaction ();
                capituloEN = (CapituloEN)session.Get (typeof(CapituloEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in CapituloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return capituloEN;
}

public System.Collections.Generic.IList<CapituloEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CapituloEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CapituloEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CapituloEN>();
                else
                        result = session.CreateCriteria (typeof(CapituloEN)).List<CapituloEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in CapituloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void Borrarcomentario (int p_Capitulo_OID, System.Collections.Generic.IList<int> p_comentario_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                SMPGenNHibernate.EN.SMP.CapituloEN capituloEN = null;
                capituloEN = (CapituloEN)session.Load (typeof(CapituloEN), p_Capitulo_OID);

                SMPGenNHibernate.EN.SMP.ComentarioEN comentarioENAux = null;
                if (capituloEN.Comentario != null) {
                        foreach (int item in p_comentario_OIDs) {
                                comentarioENAux = (SMPGenNHibernate.EN.SMP.ComentarioEN)session.Load (typeof(SMPGenNHibernate.EN.SMP.ComentarioEN), item);
                                if (capituloEN.Comentario.Contains (comentarioENAux) == true) {
                                        capituloEN.Comentario.Remove (comentarioENAux);
                                        comentarioENAux.Capitulo = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_comentario_OIDs you are trying to unrelationer, doesn't exist in CapituloEN");
                        }
                }

                session.Update (capituloEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in CapituloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Addcomentario (int p_Capitulo_OID, System.Collections.Generic.IList<int> p_comentario_OIDs)
{
        SMPGenNHibernate.EN.SMP.CapituloEN capituloEN = null;
        try
        {
                SessionInitializeTransaction ();
                capituloEN = (CapituloEN)session.Load (typeof(CapituloEN), p_Capitulo_OID);
                SMPGenNHibernate.EN.SMP.ComentarioEN comentarioENAux = null;
                if (capituloEN.Comentario == null) {
                        capituloEN.Comentario = new System.Collections.Generic.List<SMPGenNHibernate.EN.SMP.ComentarioEN>();
                }

                foreach (int item in p_comentario_OIDs) {
                        comentarioENAux = new SMPGenNHibernate.EN.SMP.ComentarioEN ();
                        comentarioENAux = (SMPGenNHibernate.EN.SMP.ComentarioEN)session.Load (typeof(SMPGenNHibernate.EN.SMP.ComentarioEN), item);
                        comentarioENAux.Capitulo = capituloEN;

                        capituloEN.Comentario.Add (comentarioENAux);
                }


                session.Update (capituloEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in CapituloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
