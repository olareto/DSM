
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
 * Clase Serie:
 *
 */

namespace SMPGenNHibernate.CAD.SMP
{
public partial class SerieCAD : BasicCAD, ISerieCAD
{
public SerieCAD() : base ()
{
}

public SerieCAD(ISession sessionAux) : base (sessionAux)
{
}



public SerieEN ReadOIDDefault (int id
                               )
{
        SerieEN serieEN = null;

        try
        {
                SessionInitializeTransaction ();
                serieEN = (SerieEN)session.Get (typeof(SerieEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in SerieCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return serieEN;
}

public System.Collections.Generic.IList<SerieEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<SerieEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(SerieEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<SerieEN>();
                        else
                                result = session.CreateCriteria (typeof(SerieEN)).List<SerieEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in SerieCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (SerieEN serie)
{
        try
        {
                SessionInitializeTransaction ();
                SerieEN serieEN = (SerieEN)session.Load (typeof(SerieEN), serie.Id);



                serieEN.Anyofin = serie.Anyofin;


                serieEN.Finalizada = serie.Finalizada;

                session.Update (serieEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in SerieCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (SerieEN serie)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (serie);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in SerieCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return serie.Id;
}

public void Modify (SerieEN serie)
{
        try
        {
                SessionInitializeTransaction ();
                SerieEN serieEN = (SerieEN)session.Load (typeof(SerieEN), serie.Id);

                serieEN.Valoracion = serie.Valoracion;


                serieEN.Nombre = serie.Nombre;


                serieEN.Imagen = serie.Imagen;


                serieEN.Descriplarga = serie.Descriplarga;


                serieEN.Descripcion = serie.Descripcion;


                serieEN.Genero = serie.Genero;


                serieEN.Anyo = serie.Anyo;


                serieEN.Imagran = serie.Imagran;


                serieEN.Anyofin = serie.Anyofin;


                serieEN.Finalizada = serie.Finalizada;

                session.Update (serieEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in SerieCAD.", ex);
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
                SerieEN serieEN = (SerieEN)session.Load (typeof(SerieEN), id);
                session.Delete (serieEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in SerieCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: SerieEN
public SerieEN ReadOID (int id
                        )
{
        SerieEN serieEN = null;

        try
        {
                SessionInitializeTransaction ();
                serieEN = (SerieEN)session.Get (typeof(SerieEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in SerieCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return serieEN;
}

public System.Collections.Generic.IList<SerieEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<SerieEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(SerieEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<SerieEN>();
                else
                        result = session.CreateCriteria (typeof(SerieEN)).List<SerieEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in SerieCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void Eliminartemporada (int p_Serie_OID, System.Collections.Generic.IList<int> p_temporada_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                SMPGenNHibernate.EN.SMP.SerieEN serieEN = null;
                serieEN = (SerieEN)session.Load (typeof(SerieEN), p_Serie_OID);

                SMPGenNHibernate.EN.SMP.TemporadaEN temporadaENAux = null;
                if (serieEN.Temporada != null) {
                        foreach (int item in p_temporada_OIDs) {
                                temporadaENAux = (SMPGenNHibernate.EN.SMP.TemporadaEN)session.Load (typeof(SMPGenNHibernate.EN.SMP.TemporadaEN), item);
                                if (serieEN.Temporada.Contains (temporadaENAux) == true) {
                                        serieEN.Temporada.Remove (temporadaENAux);
                                        temporadaENAux.Serie = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_temporada_OIDs you are trying to unrelationer, doesn't exist in SerieEN");
                        }
                }

                session.Update (serieEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in SerieCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Addtemporada (int p_Serie_OID, System.Collections.Generic.IList<int> p_temporada_OIDs)
{
        SMPGenNHibernate.EN.SMP.SerieEN serieEN = null;
        try
        {
                SessionInitializeTransaction ();
                serieEN = (SerieEN)session.Load (typeof(SerieEN), p_Serie_OID);
                SMPGenNHibernate.EN.SMP.TemporadaEN temporadaENAux = null;
                if (serieEN.Temporada == null) {
                        serieEN.Temporada = new System.Collections.Generic.List<SMPGenNHibernate.EN.SMP.TemporadaEN>();
                }

                foreach (int item in p_temporada_OIDs) {
                        temporadaENAux = new SMPGenNHibernate.EN.SMP.TemporadaEN ();
                        temporadaENAux = (SMPGenNHibernate.EN.SMP.TemporadaEN)session.Load (typeof(SMPGenNHibernate.EN.SMP.TemporadaEN), item);
                        temporadaENAux.Serie = serieEN;

                        serieEN.Temporada.Add (temporadaENAux);
                }


                session.Update (serieEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in SerieCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.SerieEN> Filtronombre (string p_nombre)
{
        System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.SerieEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SerieEN self where FROM SerieEN art where art.Nombre like '%'+:p_nombre+'%'";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SerieENfiltronombreHQL");
                query.SetParameter ("p_nombre", p_nombre);

                result = query.List<SMPGenNHibernate.EN.SMP.SerieEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in SerieCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.SerieEN> Filtrovalor (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum ? p_valor)
{
        System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.SerieEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SerieEN self where FROM SerieEN art where art.Valoracion = :p_valor";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SerieENfiltrovalorHQL");
                query.SetParameter ("p_valor", p_valor);

                result = query.List<SMPGenNHibernate.EN.SMP.SerieEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in SerieCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.SerieEN> Filtroanyo (int? p_min, int ? p_max)
{
        System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.SerieEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SerieEN self where FROM SerieEN art where art.Anyo >= :p_min and art.Anyo <= :p_max";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SerieENfiltroanyoHQL");
                query.SetParameter ("p_min", p_min);
                query.SetParameter ("p_max", p_max);

                result = query.List<SMPGenNHibernate.EN.SMP.SerieEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in SerieCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.SerieEN> Filtrogenero (string p_genero)
{
        System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.SerieEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SerieEN self where FROM SerieEN art where art.Genero = :p_genero";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SerieENfiltrogeneroHQL");
                query.SetParameter ("p_genero", p_genero);

                result = query.List<SMPGenNHibernate.EN.SMP.SerieEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in SerieCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
