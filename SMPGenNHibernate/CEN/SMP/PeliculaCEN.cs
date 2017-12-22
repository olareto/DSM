

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
 *      Definition of the class PeliculaCEN
 *
 */
public partial class PeliculaCEN
{
private IPeliculaCAD _IPeliculaCAD;

public PeliculaCEN()
{
        this._IPeliculaCAD = new PeliculaCAD ();
}

public PeliculaCEN(IPeliculaCAD _IPeliculaCAD)
{
        this._IPeliculaCAD = _IPeliculaCAD;
}

public IPeliculaCAD get_IPeliculaCAD ()
{
        return this._IPeliculaCAD;
}

public int New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum p_valoracion, string p_nombre)
{
        PeliculaEN peliculaEN = null;
        int oid;

        //Initialized PeliculaEN
        peliculaEN = new PeliculaEN ();
        peliculaEN.Valoracion = p_valoracion;

        peliculaEN.Nombre = p_nombre;

        //Call to PeliculaCAD

        oid = _IPeliculaCAD.New_ (peliculaEN);
        return oid;
}

public void Modify (int p_Pelicula_OID, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum p_valoracion, string p_nombre)
{
        PeliculaEN peliculaEN = null;

        //Initialized PeliculaEN
        peliculaEN = new PeliculaEN ();
        peliculaEN.Id = p_Pelicula_OID;
        peliculaEN.Valoracion = p_valoracion;
        peliculaEN.Nombre = p_nombre;
        //Call to PeliculaCAD

        _IPeliculaCAD.Modify (peliculaEN);
}

public void Destroy (int id
                     )
{
        _IPeliculaCAD.Destroy (id);
}

public PeliculaEN ReadOID (int id
                           )
{
        PeliculaEN peliculaEN = null;

        peliculaEN = _IPeliculaCAD.ReadOID (id);
        return peliculaEN;
}

public System.Collections.Generic.IList<PeliculaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PeliculaEN> list = null;

        list = _IPeliculaCAD.ReadAll (first, size);
        return list;
}
public void Eliminarcomentario (int p_Pelicula_OID, System.Collections.Generic.IList<int> p_comentario_OIDs)
{
        //Call to PeliculaCAD

        _IPeliculaCAD.Eliminarcomentario (p_Pelicula_OID, p_comentario_OIDs);
}
public void Addcomentario (int p_Pelicula_OID, System.Collections.Generic.IList<int> p_comentario_OIDs)
{
        //Call to PeliculaCAD

        _IPeliculaCAD.Addcomentario (p_Pelicula_OID, p_comentario_OIDs);
}
}
}
