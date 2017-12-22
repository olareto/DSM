

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
 *      Definition of the class TemporadaCEN
 *
 */
public partial class TemporadaCEN
{
private ITemporadaCAD _ITemporadaCAD;

public TemporadaCEN()
{
        this._ITemporadaCAD = new TemporadaCAD ();
}

public TemporadaCEN(ITemporadaCAD _ITemporadaCAD)
{
        this._ITemporadaCAD = _ITemporadaCAD;
}

public ITemporadaCAD get_ITemporadaCAD ()
{
        return this._ITemporadaCAD;
}

public TemporadaEN ReadOID (int id
                            )
{
        TemporadaEN temporadaEN = null;

        temporadaEN = _ITemporadaCAD.ReadOID (id);
        return temporadaEN;
}

public System.Collections.Generic.IList<TemporadaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TemporadaEN> list = null;

        list = _ITemporadaCAD.ReadAll (first, size);
        return list;
}
public int New_ (int p_serie, string p_nombre)
{
        TemporadaEN temporadaEN = null;
        int oid;

        //Initialized TemporadaEN
        temporadaEN = new TemporadaEN ();

        if (p_serie != -1) {
                // El argumento p_serie -> Property serie es oid = false
                // Lista de oids id
                temporadaEN.Serie = new SMPGenNHibernate.EN.SMP.SerieEN ();
                temporadaEN.Serie.Id = p_serie;
        }

        temporadaEN.Nombre = p_nombre;

        //Call to TemporadaCAD

        oid = _ITemporadaCAD.New_ (temporadaEN);
        return oid;
}

public void Modify (int p_Temporada_OID, string p_nombre)
{
        TemporadaEN temporadaEN = null;

        //Initialized TemporadaEN
        temporadaEN = new TemporadaEN ();
        temporadaEN.Id = p_Temporada_OID;
        temporadaEN.Nombre = p_nombre;
        //Call to TemporadaCAD

        _ITemporadaCAD.Modify (temporadaEN);
}

public void Destroy (int id
                     )
{
        _ITemporadaCAD.Destroy (id);
}

public void Borrarcap (int p_Temporada_OID, System.Collections.Generic.IList<int> p_capitulo_OIDs)
{
        //Call to TemporadaCAD

        _ITemporadaCAD.Borrarcap (p_Temporada_OID, p_capitulo_OIDs);
}
public void Addcap (int p_Temporada_OID, System.Collections.Generic.IList<int> p_capitulo_OIDs)
{
        //Call to TemporadaCAD

        _ITemporadaCAD.Addcap (p_Temporada_OID, p_capitulo_OIDs);
}
}
}
