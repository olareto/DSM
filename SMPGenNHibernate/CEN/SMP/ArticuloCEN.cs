

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
 *      Definition of the class ArticuloCEN
 *
 */
public partial class ArticuloCEN
{
private IArticuloCAD _IArticuloCAD;

public ArticuloCEN()
{
        this._IArticuloCAD = new ArticuloCAD ();
}

public ArticuloCEN(IArticuloCAD _IArticuloCAD)
{
        this._IArticuloCAD = _IArticuloCAD;
}

public IArticuloCAD get_IArticuloCAD ()
{
        return this._IArticuloCAD;
}

public int New_ (string p_nombre, double p_precio, string p_descripcion, string p_imagen, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum p_valor, int p_stock, string p_descriplarga, string p_imagran)
{
        ArticuloEN articuloEN = null;
        int oid;

        //Initialized ArticuloEN
        articuloEN = new ArticuloEN ();
        articuloEN.Nombre = p_nombre;

        articuloEN.Precio = p_precio;

        articuloEN.Descripcion = p_descripcion;

        articuloEN.Imagen = p_imagen;

        articuloEN.Valor = p_valor;

        articuloEN.Stock = p_stock;

        articuloEN.Descriplarga = p_descriplarga;

        articuloEN.Imagran = p_imagran;

        //Call to ArticuloCAD

        oid = _IArticuloCAD.New_ (articuloEN);
        return oid;
}

public void Modify (int p_articulo_OID, string p_nombre, double p_precio, string p_descripcion, string p_imagen, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum p_valor, int p_stock, string p_descriplarga, string p_imagran)
{
        ArticuloEN articuloEN = null;

        //Initialized ArticuloEN
        articuloEN = new ArticuloEN ();
        articuloEN.Id = p_articulo_OID;
        articuloEN.Nombre = p_nombre;
        articuloEN.Precio = p_precio;
        articuloEN.Descripcion = p_descripcion;
        articuloEN.Imagen = p_imagen;
        articuloEN.Valor = p_valor;
        articuloEN.Stock = p_stock;
        articuloEN.Descriplarga = p_descriplarga;
        articuloEN.Imagran = p_imagran;
        //Call to ArticuloCAD

        _IArticuloCAD.Modify (articuloEN);
}

public void Destroy (int id
                     )
{
        _IArticuloCAD.Destroy (id);
}

public ArticuloEN ReadOID (int id
                           )
{
        ArticuloEN articuloEN = null;

        articuloEN = _IArticuloCAD.ReadOID (id);
        return articuloEN;
}

public System.Collections.Generic.IList<ArticuloEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ArticuloEN> list = null;

        list = _IArticuloCAD.ReadAll (first, size);
        return list;
}
public void Eliminarcomentario (int p_articulo_OID, System.Collections.Generic.IList<int> p_comentario_OIDs)
{
        //Call to ArticuloCAD

        _IArticuloCAD.Eliminarcomentario (p_articulo_OID, p_comentario_OIDs);
}
public System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ArticuloEN> Filtronombre (string p_nombre)
{
        return _IArticuloCAD.Filtronombre (p_nombre);
}
public System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ArticuloEN> Filtroprecio (double? p_min, double ? p_max)
{
        return _IArticuloCAD.Filtroprecio (p_min, p_max);
}
public System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ArticuloEN> Filtrovalor (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum ? p_valor)
{
        return _IArticuloCAD.Filtrovalor (p_valor);
}
public void Addcomentario (int p_articulo_OID, System.Collections.Generic.IList<int> p_comentario_OIDs)
{
        //Call to ArticuloCAD

        _IArticuloCAD.Addcomentario (p_articulo_OID, p_comentario_OIDs);
}
}
}
