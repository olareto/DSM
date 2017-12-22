

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
 *      Definition of the class CapituloCEN
 *
 */
public partial class CapituloCEN
{
private ICapituloCAD _ICapituloCAD;

public CapituloCEN()
{
        this._ICapituloCAD = new CapituloCAD ();
}

public CapituloCEN(ICapituloCAD _ICapituloCAD)
{
        this._ICapituloCAD = _ICapituloCAD;
}

public ICapituloCAD get_ICapituloCAD ()
{
        return this._ICapituloCAD;
}

public int New_ (int p_temporada, string p_nombre, Nullable<DateTime> p_fecha, string p_descripcion, string p_imagen)
{
        CapituloEN capituloEN = null;
        int oid;

        //Initialized CapituloEN
        capituloEN = new CapituloEN ();

        if (p_temporada != -1) {
                // El argumento p_temporada -> Property temporada es oid = false
                // Lista de oids id
                capituloEN.Temporada = new SMPGenNHibernate.EN.SMP.TemporadaEN ();
                capituloEN.Temporada.Id = p_temporada;
        }

        capituloEN.Nombre = p_nombre;

        capituloEN.Fecha = p_fecha;

        capituloEN.Descripcion = p_descripcion;

        capituloEN.Imagen = p_imagen;

        //Call to CapituloCAD

        oid = _ICapituloCAD.New_ (capituloEN);
        return oid;
}

public void Modify (int p_Capitulo_OID, string p_nombre, Nullable<DateTime> p_fecha, string p_descripcion, string p_imagen)
{
        CapituloEN capituloEN = null;

        //Initialized CapituloEN
        capituloEN = new CapituloEN ();
        capituloEN.Id = p_Capitulo_OID;
        capituloEN.Nombre = p_nombre;
        capituloEN.Fecha = p_fecha;
        capituloEN.Descripcion = p_descripcion;
        capituloEN.Imagen = p_imagen;
        //Call to CapituloCAD

        _ICapituloCAD.Modify (capituloEN);
}

public void Destroy (int id
                     )
{
        _ICapituloCAD.Destroy (id);
}

public CapituloEN ReadOID (int id
                           )
{
        CapituloEN capituloEN = null;

        capituloEN = _ICapituloCAD.ReadOID (id);
        return capituloEN;
}

public System.Collections.Generic.IList<CapituloEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CapituloEN> list = null;

        list = _ICapituloCAD.ReadAll (first, size);
        return list;
}
public void Borrarcomentario (int p_Capitulo_OID, System.Collections.Generic.IList<int> p_comentario_OIDs)
{
        //Call to CapituloCAD

        _ICapituloCAD.Borrarcomentario (p_Capitulo_OID, p_comentario_OIDs);
}
public void Addcomentario (int p_Capitulo_OID, System.Collections.Generic.IList<int> p_comentario_OIDs)
{
        //Call to CapituloCAD

        _ICapituloCAD.Addcomentario (p_Capitulo_OID, p_comentario_OIDs);
}
}
}
