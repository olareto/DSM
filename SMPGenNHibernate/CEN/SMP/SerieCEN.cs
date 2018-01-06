

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
 *      Definition of the class SerieCEN
 *
 */
public partial class SerieCEN
{
private ISerieCAD _ISerieCAD;

public SerieCEN()
{
        this._ISerieCAD = new SerieCAD ();
}

public SerieCEN(ISerieCAD _ISerieCAD)
{
        this._ISerieCAD = _ISerieCAD;
}

public ISerieCAD get_ISerieCAD ()
{
        return this._ISerieCAD;
}

public int New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum p_valoracion, string p_nombre, string p_imagen, string p_descriplarga, string p_descripcion, string p_genero, int p_anyo, string p_imagran, int p_anyofin, bool p_finalizada)
{
        SerieEN serieEN = null;
        int oid;

        //Initialized SerieEN
        serieEN = new SerieEN ();
        serieEN.Valoracion = p_valoracion;

        serieEN.Nombre = p_nombre;

        serieEN.Imagen = p_imagen;

        serieEN.Descriplarga = p_descriplarga;

        serieEN.Descripcion = p_descripcion;

        serieEN.Genero = p_genero;

        serieEN.Anyo = p_anyo;

        serieEN.Imagran = p_imagran;

        serieEN.Anyofin = p_anyofin;

        serieEN.Finalizada = p_finalizada;

        //Call to SerieCAD

        oid = _ISerieCAD.New_ (serieEN);
        return oid;
}

public void Modify (int p_Serie_OID, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum p_valoracion, string p_nombre, string p_imagen, string p_descriplarga, string p_descripcion, string p_genero, int p_anyo, string p_imagran, int p_anyofin, bool p_finalizada)
{
        SerieEN serieEN = null;

        //Initialized SerieEN
        serieEN = new SerieEN ();
        serieEN.Id = p_Serie_OID;
        serieEN.Valoracion = p_valoracion;
        serieEN.Nombre = p_nombre;
        serieEN.Imagen = p_imagen;
        serieEN.Descriplarga = p_descriplarga;
        serieEN.Descripcion = p_descripcion;
        serieEN.Genero = p_genero;
        serieEN.Anyo = p_anyo;
        serieEN.Imagran = p_imagran;
        serieEN.Anyofin = p_anyofin;
        serieEN.Finalizada = p_finalizada;
        //Call to SerieCAD

        _ISerieCAD.Modify (serieEN);
}

public void Destroy (int id
                     )
{
        _ISerieCAD.Destroy (id);
}

public SerieEN ReadOID (int id
                        )
{
        SerieEN serieEN = null;

        serieEN = _ISerieCAD.ReadOID (id);
        return serieEN;
}

public System.Collections.Generic.IList<SerieEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<SerieEN> list = null;

        list = _ISerieCAD.ReadAll (first, size);
        return list;
}
public void Eliminartemporada (int p_Serie_OID, System.Collections.Generic.IList<int> p_temporada_OIDs)
{
        //Call to SerieCAD

        _ISerieCAD.Eliminartemporada (p_Serie_OID, p_temporada_OIDs);
}
public void Addtemporada (int p_Serie_OID, System.Collections.Generic.IList<int> p_temporada_OIDs)
{
        //Call to SerieCAD

        _ISerieCAD.Addtemporada (p_Serie_OID, p_temporada_OIDs);
}
}
}
