

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
 *      Definition of the class ListaCEN
 *
 */
public partial class ListaCEN
{
private IListaCAD _IListaCAD;

public ListaCEN()
{
        this._IListaCAD = new ListaCAD ();
}

public ListaCEN(IListaCAD _IListaCAD)
{
        this._IListaCAD = _IListaCAD;
}

public IListaCAD get_IListaCAD ()
{
        return this._IListaCAD;
}

public int New_ (SMPGenNHibernate.Enumerated.SMP.Estado_videoEnum p_estado)
{
        ListaEN listaEN = null;
        int oid;

        //Initialized ListaEN
        listaEN = new ListaEN ();
        listaEN.Estado = p_estado;

        //Call to ListaCAD

        oid = _IListaCAD.New_ (listaEN);
        return oid;
}

public void Modify (int p_Lista_OID, SMPGenNHibernate.Enumerated.SMP.Estado_videoEnum p_estado)
{
        ListaEN listaEN = null;

        //Initialized ListaEN
        listaEN = new ListaEN ();
        listaEN.Id = p_Lista_OID;
        listaEN.Estado = p_estado;
        //Call to ListaCAD

        _IListaCAD.Modify (listaEN);
}

public void Destroy (int id
                     )
{
        _IListaCAD.Destroy (id);
}

public ListaEN ReadOID (int id
                        )
{
        ListaEN listaEN = null;

        listaEN = _IListaCAD.ReadOID (id);
        return listaEN;
}

public System.Collections.Generic.IList<ListaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ListaEN> list = null;

        list = _IListaCAD.ReadAll (first, size);
        return list;
}
public void Addserie (int p_Lista_OID, System.Collections.Generic.IList<int> p_serie_OIDs)
{
        //Call to ListaCAD

        _IListaCAD.Addserie (p_Lista_OID, p_serie_OIDs);
}
public void Delserie (int p_Lista_OID, System.Collections.Generic.IList<int> p_serie_OIDs)
{
        //Call to ListaCAD

        _IListaCAD.Delserie (p_Lista_OID, p_serie_OIDs);
}
public void Addpel (int p_Lista_OID, System.Collections.Generic.IList<int> p_pelicula_OIDs)
{
        //Call to ListaCAD

        _IListaCAD.Addpel (p_Lista_OID, p_pelicula_OIDs);
}
public void Delpel (int p_Lista_OID, System.Collections.Generic.IList<int> p_pelicula_OIDs)
{
        //Call to ListaCAD

        _IListaCAD.Delpel (p_Lista_OID, p_pelicula_OIDs);
}
public void Addusuario (int p_Lista_OID, string p_usuario_1_OID)
{
        //Call to ListaCAD

        _IListaCAD.Addusuario (p_Lista_OID, p_usuario_1_OID);
}
public void Addadmin (int p_Lista_OID, string p_admin_OID)
{
        //Call to ListaCAD

        _IListaCAD.Addadmin (p_Lista_OID, p_admin_OID);
}
}
}
