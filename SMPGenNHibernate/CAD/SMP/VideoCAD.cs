
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
 * Clase video:
 *
 */

namespace SMPGenNHibernate.CAD.SMP
{
public partial class VideoCAD : BasicCAD, IVideoCAD
{
public VideoCAD() : base ()
{
}

public VideoCAD(ISession sessionAux) : base (sessionAux)
{
}



public VideoEN ReadOIDDefault (int id
                               )
{
        VideoEN videoEN = null;

        try
        {
                SessionInitializeTransaction ();
                videoEN = (VideoEN)session.Get (typeof(VideoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return videoEN;
}

public System.Collections.Generic.IList<VideoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<VideoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(VideoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<VideoEN>();
                        else
                                result = session.CreateCriteria (typeof(VideoEN)).List<VideoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (VideoEN video)
{
        try
        {
                SessionInitializeTransaction ();
                VideoEN videoEN = (VideoEN)session.Load (typeof(VideoEN), video.Id);

                videoEN.Valoracion = video.Valoracion;


                videoEN.Nombre = video.Nombre;


                videoEN.Imagen = video.Imagen;

                session.Update (videoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (VideoEN video)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (video);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return video.Id;
}

public void Modify (VideoEN video)
{
        try
        {
                SessionInitializeTransaction ();
                VideoEN videoEN = (VideoEN)session.Load (typeof(VideoEN), video.Id);

                videoEN.Valoracion = video.Valoracion;


                videoEN.Nombre = video.Nombre;


                videoEN.Imagen = video.Imagen;

                session.Update (videoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
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
                VideoEN videoEN = (VideoEN)session.Load (typeof(VideoEN), id);
                session.Delete (videoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: VideoEN
public VideoEN ReadOID (int id
                        )
{
        VideoEN videoEN = null;

        try
        {
                SessionInitializeTransaction ();
                videoEN = (VideoEN)session.Get (typeof(VideoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return videoEN;
}

public System.Collections.Generic.IList<VideoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<VideoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(VideoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<VideoEN>();
                else
                        result = session.CreateCriteria (typeof(VideoEN)).List<VideoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
