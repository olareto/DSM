

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using SMPGenNHibernate.Exceptions;

using SMPGenNHibernate.EN.SMP;
using SMPGenNHibernate.CAD.SMP;


namespace SMPGenNHibernate.CEN.SMP
{
/*
 *      Definition of the class VideoCEN
 *
 */
public partial class VideoCEN
{
private IVideoCAD _IVideoCAD;

public VideoCEN()
{
        this._IVideoCAD = new VideoCAD ();
}

public VideoCEN(IVideoCAD _IVideoCAD)
{
        this._IVideoCAD = _IVideoCAD;
}

public IVideoCAD get_IVideoCAD ()
{
        return this._IVideoCAD;
}

public int New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum p_valoracion, string p_nombre, string p_imagen, string p_descriplarga, string p_descripcion, string p_genero, Nullable<DateTime> p_anyo, string p_imagran)
{
        VideoEN videoEN = null;
        int oid;

        //Initialized VideoEN
        videoEN = new VideoEN ();
        videoEN.Valoracion = p_valoracion;

        videoEN.Nombre = p_nombre;

        videoEN.Imagen = p_imagen;

        videoEN.Descriplarga = p_descriplarga;

        videoEN.Descripcion = p_descripcion;

        videoEN.Genero = p_genero;

        videoEN.Anyo = p_anyo;

        videoEN.Imagran = p_imagran;

        //Call to VideoCAD

        oid = _IVideoCAD.New_ (videoEN);
        return oid;
}

public void Modify (int p_video_OID, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum p_valoracion, string p_nombre, string p_imagen, string p_descriplarga, string p_descripcion, string p_genero, Nullable<DateTime> p_anyo, string p_imagran)
{
        VideoEN videoEN = null;

        //Initialized VideoEN
        videoEN = new VideoEN ();
        videoEN.Id = p_video_OID;
        videoEN.Valoracion = p_valoracion;
        videoEN.Nombre = p_nombre;
        videoEN.Imagen = p_imagen;
        videoEN.Descriplarga = p_descriplarga;
        videoEN.Descripcion = p_descripcion;
        videoEN.Genero = p_genero;
        videoEN.Anyo = p_anyo;
        videoEN.Imagran = p_imagran;
        //Call to VideoCAD

        _IVideoCAD.Modify (videoEN);
}

public void Destroy (int id
                     )
{
        _IVideoCAD.Destroy (id);
}

public VideoEN ReadOID (int id
                        )
{
        VideoEN videoEN = null;

        videoEN = _IVideoCAD.ReadOID (id);
        return videoEN;
}

public System.Collections.Generic.IList<VideoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<VideoEN> list = null;

        list = _IVideoCAD.ReadAll (first, size);
        return list;
}
}
}
