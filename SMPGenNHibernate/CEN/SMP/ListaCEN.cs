

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

public int New_ (SMPGenNHibernate.Enumerated.SMP.Estado_videoEnum p_estado, string p_usuario_1)
{
        ListaEN listaEN = null;
        int oid;

        //Initialized ListaEN
        listaEN = new ListaEN ();
        listaEN.Estado = p_estado;


        if (p_usuario_1 != null) {
                // El argumento p_usuario_1 -> Property usuario_1 es oid = false
                // Lista de oids id
                listaEN.Usuario_1 = new SMPGenNHibernate.EN.SMP.UsuarioEN ();
                listaEN.Usuario_1.Email = p_usuario_1;
        }

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
public void Addvideo (int p_Lista_OID, System.Collections.Generic.IList<int> p_video_OIDs)
{
        //Call to ListaCAD

        _IListaCAD.Addvideo (p_Lista_OID, p_video_OIDs);
}
public void Eliminarvideo (int p_Lista_OID, System.Collections.Generic.IList<int> p_video_OIDs)
{
        //Call to ListaCAD

        _IListaCAD.Eliminarvideo (p_Lista_OID, p_video_OIDs);
}
}
}
