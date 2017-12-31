

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
 *      Definition of the class ComentarioCEN
 *
 */
public partial class ComentarioCEN
{
private IComentarioCAD _IComentarioCAD;

public ComentarioCEN()
{
        this._IComentarioCAD = new ComentarioCAD ();
}

public ComentarioCEN(IComentarioCAD _IComentarioCAD)
{
        this._IComentarioCAD = _IComentarioCAD;
}

public IComentarioCAD get_IComentarioCAD ()
{
        return this._IComentarioCAD;
}

public int New_ (string p_comentario, string p_autor, Nullable<DateTime> p_fecha)
{
        ComentarioEN comentarioEN = null;
        int oid;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.Comentario = p_comentario;

        comentarioEN.Autor = p_autor;

        comentarioEN.Fecha = p_fecha;

        //Call to ComentarioCAD

        oid = _IComentarioCAD.New_ (comentarioEN);
        return oid;
}

public void Modify (int p_Comentario_OID, string p_comentario, string p_autor, Nullable<DateTime> p_fecha)
{
        ComentarioEN comentarioEN = null;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.Id = p_Comentario_OID;
        comentarioEN.Comentario = p_comentario;
        comentarioEN.Autor = p_autor;
        comentarioEN.Fecha = p_fecha;
        //Call to ComentarioCAD

        _IComentarioCAD.Modify (comentarioEN);
}

public void Destroy (int id
                     )
{
        _IComentarioCAD.Destroy (id);
}

public ComentarioEN ReadOID (int id
                             )
{
        ComentarioEN comentarioEN = null;

        comentarioEN = _IComentarioCAD.ReadOID (id);
        return comentarioEN;
}

public System.Collections.Generic.IList<ComentarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComentarioEN> list = null;

        list = _IComentarioCAD.ReadAll (first, size);
        return list;
}
public void Addcap (int p_Comentario_OID, int p_capitulo_OID)
{
        //Call to ComentarioCAD

        _IComentarioCAD.Addcap (p_Comentario_OID, p_capitulo_OID);
}
public void Addpel (int p_Comentario_OID, int p_pelicula_OID)
{
        //Call to ComentarioCAD

        _IComentarioCAD.Addpel (p_Comentario_OID, p_pelicula_OID);
}
public void Addart (int p_Comentario_OID, int p_articulo_OID)
{
        //Call to ComentarioCAD

        _IComentarioCAD.Addart (p_Comentario_OID, p_articulo_OID);
}
}
}
