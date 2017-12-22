
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
 * Clase Lista:
 *
 */

namespace SMPGenNHibernate.CAD.SMP
{
public partial class ListaCAD : BasicCAD, IListaCAD
{
public ListaCAD() : base ()
{
}

public ListaCAD(ISession sessionAux) : base (sessionAux)
{
}



public ListaEN ReadOIDDefault (int id
                               )
{
        ListaEN listaEN = null;

        try
        {
                SessionInitializeTransaction ();
                listaEN = (ListaEN)session.Get (typeof(ListaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in ListaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return listaEN;
}

public System.Collections.Generic.IList<ListaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ListaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ListaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ListaEN>();
                        else
                                result = session.CreateCriteria (typeof(ListaEN)).List<ListaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in ListaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ListaEN lista)
{
        try
        {
                SessionInitializeTransaction ();
                ListaEN listaEN = (ListaEN)session.Load (typeof(ListaEN), lista.Id);

                listaEN.Estado = lista.Estado;



                session.Update (listaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in ListaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ListaEN lista)
{
        try
        {
                SessionInitializeTransaction ();
                if (lista.Usuario_1 != null) {
                        // Argumento OID y no colección.
                        lista.Usuario_1 = (SMPGenNHibernate.EN.SMP.UsuarioEN)session.Load (typeof(SMPGenNHibernate.EN.SMP.UsuarioEN), lista.Usuario_1.Email);

                        lista.Usuario_1.Lista
                        .Add (lista);
                }

                session.Save (lista);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in ListaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lista.Id;
}

public void Modify (ListaEN lista)
{
        try
        {
                SessionInitializeTransaction ();
                ListaEN listaEN = (ListaEN)session.Load (typeof(ListaEN), lista.Id);

                listaEN.Estado = lista.Estado;

                session.Update (listaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in ListaCAD.", ex);
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
                ListaEN listaEN = (ListaEN)session.Load (typeof(ListaEN), id);
                session.Delete (listaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in ListaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ListaEN
public ListaEN ReadOID (int id
                        )
{
        ListaEN listaEN = null;

        try
        {
                SessionInitializeTransaction ();
                listaEN = (ListaEN)session.Get (typeof(ListaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in ListaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return listaEN;
}

public System.Collections.Generic.IList<ListaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ListaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ListaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ListaEN>();
                else
                        result = session.CreateCriteria (typeof(ListaEN)).List<ListaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in ListaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void Addvideo (int p_Lista_OID, System.Collections.Generic.IList<int> p_video_OIDs)
{
        SMPGenNHibernate.EN.SMP.ListaEN listaEN = null;
        try
        {
                SessionInitializeTransaction ();
                listaEN = (ListaEN)session.Load (typeof(ListaEN), p_Lista_OID);
                SMPGenNHibernate.EN.SMP.VideoEN videoENAux = null;
                if (listaEN.Video == null) {
                        listaEN.Video = new System.Collections.Generic.List<SMPGenNHibernate.EN.SMP.VideoEN>();
                }

                foreach (int item in p_video_OIDs) {
                        videoENAux = new SMPGenNHibernate.EN.SMP.VideoEN ();
                        videoENAux = (SMPGenNHibernate.EN.SMP.VideoEN)session.Load (typeof(SMPGenNHibernate.EN.SMP.VideoEN), item);
                        videoENAux.Lista.Add (listaEN);

                        listaEN.Video.Add (videoENAux);
                }


                session.Update (listaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in ListaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Eliminarvideo (int p_Lista_OID, System.Collections.Generic.IList<int> p_video_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                SMPGenNHibernate.EN.SMP.ListaEN listaEN = null;
                listaEN = (ListaEN)session.Load (typeof(ListaEN), p_Lista_OID);

                SMPGenNHibernate.EN.SMP.VideoEN videoENAux = null;
                if (listaEN.Video != null) {
                        foreach (int item in p_video_OIDs) {
                                videoENAux = (SMPGenNHibernate.EN.SMP.VideoEN)session.Load (typeof(SMPGenNHibernate.EN.SMP.VideoEN), item);
                                if (listaEN.Video.Contains (videoENAux) == true) {
                                        listaEN.Video.Remove (videoENAux);
                                        videoENAux.Lista.Remove (listaEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_video_OIDs you are trying to unrelationer, doesn't exist in ListaEN");
                        }
                }

                session.Update (listaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in ListaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
