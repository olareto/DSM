
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
 * Clase Pelicula:
 *
 */

namespace SMPGenNHibernate.CAD.SMP
{
public partial class PeliculaCAD : BasicCAD, IPeliculaCAD
{
public PeliculaCAD() : base ()
{
}

public PeliculaCAD(ISession sessionAux) : base (sessionAux)
{
}



public PeliculaEN ReadOIDDefault (int id
                                  )
{
        PeliculaEN peliculaEN = null;

        try
        {
                SessionInitializeTransaction ();
                peliculaEN = (PeliculaEN)session.Get (typeof(PeliculaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in PeliculaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return peliculaEN;
}

public System.Collections.Generic.IList<PeliculaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PeliculaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PeliculaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PeliculaEN>();
                        else
                                result = session.CreateCriteria (typeof(PeliculaEN)).List<PeliculaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in PeliculaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PeliculaEN pelicula)
{
        try
        {
                SessionInitializeTransaction ();
                PeliculaEN peliculaEN = (PeliculaEN)session.Load (typeof(PeliculaEN), pelicula.Id);



                peliculaEN.Link = pelicula.Link;

                session.Update (peliculaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in PeliculaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (PeliculaEN pelicula)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (pelicula);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in PeliculaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pelicula.Id;
}

public void Modify (PeliculaEN pelicula)
{
        try
        {
                SessionInitializeTransaction ();
                PeliculaEN peliculaEN = (PeliculaEN)session.Load (typeof(PeliculaEN), pelicula.Id);

                peliculaEN.Valoracion = pelicula.Valoracion;


                peliculaEN.Nombre = pelicula.Nombre;


                peliculaEN.Imagen = pelicula.Imagen;


                peliculaEN.Descriplarga = pelicula.Descriplarga;


                peliculaEN.Descripcion = pelicula.Descripcion;


                peliculaEN.Genero = pelicula.Genero;


                peliculaEN.Anyo = pelicula.Anyo;


                peliculaEN.Imagran = pelicula.Imagran;


                peliculaEN.Link = pelicula.Link;

                session.Update (peliculaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in PeliculaCAD.", ex);
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
                PeliculaEN peliculaEN = (PeliculaEN)session.Load (typeof(PeliculaEN), id);
                session.Delete (peliculaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in PeliculaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: PeliculaEN
public PeliculaEN ReadOID (int id
                           )
{
        PeliculaEN peliculaEN = null;

        try
        {
                SessionInitializeTransaction ();
                peliculaEN = (PeliculaEN)session.Get (typeof(PeliculaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in PeliculaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return peliculaEN;
}

public System.Collections.Generic.IList<PeliculaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PeliculaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PeliculaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PeliculaEN>();
                else
                        result = session.CreateCriteria (typeof(PeliculaEN)).List<PeliculaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in PeliculaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void Eliminarcomentario (int p_Pelicula_OID, System.Collections.Generic.IList<int> p_comentario_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                SMPGenNHibernate.EN.SMP.PeliculaEN peliculaEN = null;
                peliculaEN = (PeliculaEN)session.Load (typeof(PeliculaEN), p_Pelicula_OID);

                SMPGenNHibernate.EN.SMP.ComentarioEN comentarioENAux = null;
                if (peliculaEN.Comentario != null) {
                        foreach (int item in p_comentario_OIDs) {
                                comentarioENAux = (SMPGenNHibernate.EN.SMP.ComentarioEN)session.Load (typeof(SMPGenNHibernate.EN.SMP.ComentarioEN), item);
                                if (peliculaEN.Comentario.Contains (comentarioENAux) == true) {
                                        peliculaEN.Comentario.Remove (comentarioENAux);
                                        comentarioENAux.Pelicula = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_comentario_OIDs you are trying to unrelationer, doesn't exist in PeliculaEN");
                        }
                }

                session.Update (peliculaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in PeliculaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Addcomentario (int p_Pelicula_OID, System.Collections.Generic.IList<int> p_comentario_OIDs)
{
        SMPGenNHibernate.EN.SMP.PeliculaEN peliculaEN = null;
        try
        {
                SessionInitializeTransaction ();
                peliculaEN = (PeliculaEN)session.Load (typeof(PeliculaEN), p_Pelicula_OID);
                SMPGenNHibernate.EN.SMP.ComentarioEN comentarioENAux = null;
                if (peliculaEN.Comentario == null) {
                        peliculaEN.Comentario = new System.Collections.Generic.List<SMPGenNHibernate.EN.SMP.ComentarioEN>();
                }

                foreach (int item in p_comentario_OIDs) {
                        comentarioENAux = new SMPGenNHibernate.EN.SMP.ComentarioEN ();
                        comentarioENAux = (SMPGenNHibernate.EN.SMP.ComentarioEN)session.Load (typeof(SMPGenNHibernate.EN.SMP.ComentarioEN), item);
                        comentarioENAux.Pelicula = peliculaEN;

                        peliculaEN.Comentario.Add (comentarioENAux);
                }


                session.Update (peliculaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in PeliculaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.PeliculaEN> Filtronombre (string p_nombre)
{
        System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.PeliculaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PeliculaEN self where FROM PeliculaEN art where art.Nombre like '%'+:p_nombre+'%'";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PeliculaENfiltronombreHQL");
                query.SetParameter ("p_nombre", p_nombre);

                result = query.List<SMPGenNHibernate.EN.SMP.PeliculaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in PeliculaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.PeliculaEN> Filtroanyo (int? p_min, int ? p_max)
{
        System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.PeliculaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PeliculaEN self where FROM PeliculaEN art where art.Anyo >= :p_min and art.Anyo <= :p_max";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PeliculaENfiltroanyoHQL");
                query.SetParameter ("p_min", p_min);
                query.SetParameter ("p_max", p_max);

                result = query.List<SMPGenNHibernate.EN.SMP.PeliculaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in PeliculaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.PeliculaEN> Filtrovalor (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum ? p_valor)
{
        System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.PeliculaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PeliculaEN self where FROM PeliculaEN art where art.Valoracion = :p_valor";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PeliculaENfiltrovalorHQL");
                query.SetParameter ("p_valor", p_valor);

                result = query.List<SMPGenNHibernate.EN.SMP.PeliculaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in PeliculaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.PeliculaEN> Filtrogenero (string p_genero)
{
        System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.PeliculaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PeliculaEN self where FROM PeliculaEN art where art.Genero = :p_genero";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PeliculaENfiltrogeneroHQL");
                query.SetParameter ("p_genero", p_genero);

                result = query.List<SMPGenNHibernate.EN.SMP.PeliculaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in PeliculaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
