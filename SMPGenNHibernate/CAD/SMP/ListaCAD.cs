
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

public void Addserie (int p_Lista_OID, System.Collections.Generic.IList<int> p_serie_OIDs)
{
        SMPGenNHibernate.EN.SMP.ListaEN listaEN = null;
        try
        {
                SessionInitializeTransaction ();
                listaEN = (ListaEN)session.Load (typeof(ListaEN), p_Lista_OID);
                SMPGenNHibernate.EN.SMP.SerieEN serieENAux = null;
                if (listaEN.Serie == null) {
                        listaEN.Serie = new System.Collections.Generic.List<SMPGenNHibernate.EN.SMP.SerieEN>();
                }

                foreach (int item in p_serie_OIDs) {
                        serieENAux = new SMPGenNHibernate.EN.SMP.SerieEN ();
                        serieENAux = (SMPGenNHibernate.EN.SMP.SerieEN)session.Load (typeof(SMPGenNHibernate.EN.SMP.SerieEN), item);
                        serieENAux.Lista.Add (listaEN);

                        listaEN.Serie.Add (serieENAux);
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

public void Delserie (int p_Lista_OID, System.Collections.Generic.IList<int> p_serie_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                SMPGenNHibernate.EN.SMP.ListaEN listaEN = null;
                listaEN = (ListaEN)session.Load (typeof(ListaEN), p_Lista_OID);

                SMPGenNHibernate.EN.SMP.SerieEN serieENAux = null;
                if (listaEN.Serie != null) {
                        foreach (int item in p_serie_OIDs) {
                                serieENAux = (SMPGenNHibernate.EN.SMP.SerieEN)session.Load (typeof(SMPGenNHibernate.EN.SMP.SerieEN), item);
                                if (listaEN.Serie.Contains (serieENAux) == true) {
                                        listaEN.Serie.Remove (serieENAux);
                                        serieENAux.Lista.Remove (listaEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_serie_OIDs you are trying to unrelationer, doesn't exist in ListaEN");
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
public void Addpel (int p_Lista_OID, System.Collections.Generic.IList<int> p_pelicula_OIDs)
{
        SMPGenNHibernate.EN.SMP.ListaEN listaEN = null;
        try
        {
                SessionInitializeTransaction ();
                listaEN = (ListaEN)session.Load (typeof(ListaEN), p_Lista_OID);
                SMPGenNHibernate.EN.SMP.PeliculaEN peliculaENAux = null;
                if (listaEN.Pelicula == null) {
                        listaEN.Pelicula = new System.Collections.Generic.List<SMPGenNHibernate.EN.SMP.PeliculaEN>();
                }

                foreach (int item in p_pelicula_OIDs) {
                        peliculaENAux = new SMPGenNHibernate.EN.SMP.PeliculaEN ();
                        peliculaENAux = (SMPGenNHibernate.EN.SMP.PeliculaEN)session.Load (typeof(SMPGenNHibernate.EN.SMP.PeliculaEN), item);
                        peliculaENAux.Lista_0.Add (listaEN);

                        listaEN.Pelicula.Add (peliculaENAux);
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

public void Delpel (int p_Lista_OID, System.Collections.Generic.IList<int> p_pelicula_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                SMPGenNHibernate.EN.SMP.ListaEN listaEN = null;
                listaEN = (ListaEN)session.Load (typeof(ListaEN), p_Lista_OID);

                SMPGenNHibernate.EN.SMP.PeliculaEN peliculaENAux = null;
                if (listaEN.Pelicula != null) {
                        foreach (int item in p_pelicula_OIDs) {
                                peliculaENAux = (SMPGenNHibernate.EN.SMP.PeliculaEN)session.Load (typeof(SMPGenNHibernate.EN.SMP.PeliculaEN), item);
                                if (listaEN.Pelicula.Contains (peliculaENAux) == true) {
                                        listaEN.Pelicula.Remove (peliculaENAux);
                                        peliculaENAux.Lista_0.Remove (listaEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_pelicula_OIDs you are trying to unrelationer, doesn't exist in ListaEN");
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
