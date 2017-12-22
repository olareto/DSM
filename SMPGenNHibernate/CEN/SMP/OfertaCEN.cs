

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
 *      Definition of the class OfertaCEN
 *
 */
public partial class OfertaCEN
{
private IOfertaCAD _IOfertaCAD;

public OfertaCEN()
{
        this._IOfertaCAD = new OfertaCAD ();
}

public OfertaCEN(IOfertaCAD _IOfertaCAD)
{
        this._IOfertaCAD = _IOfertaCAD;
}

public IOfertaCAD get_IOfertaCAD ()
{
        return this._IOfertaCAD;
}

public int New_ (int p_articulo, Nullable<DateTime> p_tiempo_inicial, Nullable<DateTime> p_tiempo_final, int p_descuento)
{
        OfertaEN ofertaEN = null;
        int oid;

        //Initialized OfertaEN
        ofertaEN = new OfertaEN ();

        if (p_articulo != -1) {
                // El argumento p_articulo -> Property articulo es oid = false
                // Lista de oids id
                ofertaEN.Articulo = new SMPGenNHibernate.EN.SMP.ArticuloEN ();
                ofertaEN.Articulo.Id = p_articulo;
        }

        ofertaEN.Tiempo_inicial = p_tiempo_inicial;

        ofertaEN.Tiempo_final = p_tiempo_final;

        ofertaEN.Descuento = p_descuento;

        //Call to OfertaCAD

        oid = _IOfertaCAD.New_ (ofertaEN);
        return oid;
}

public void Modify (int p_oferta_OID, Nullable<DateTime> p_tiempo_inicial, Nullable<DateTime> p_tiempo_final, int p_descuento)
{
        OfertaEN ofertaEN = null;

        //Initialized OfertaEN
        ofertaEN = new OfertaEN ();
        ofertaEN.Id = p_oferta_OID;
        ofertaEN.Tiempo_inicial = p_tiempo_inicial;
        ofertaEN.Tiempo_final = p_tiempo_final;
        ofertaEN.Descuento = p_descuento;
        //Call to OfertaCAD

        _IOfertaCAD.Modify (ofertaEN);
}

public void Destroy (int id
                     )
{
        _IOfertaCAD.Destroy (id);
}

public OfertaEN ReadOID (int id
                         )
{
        OfertaEN ofertaEN = null;

        ofertaEN = _IOfertaCAD.ReadOID (id);
        return ofertaEN;
}

public System.Collections.Generic.IList<OfertaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<OfertaEN> list = null;

        list = _IOfertaCAD.ReadAll (first, size);
        return list;
}
}
}
