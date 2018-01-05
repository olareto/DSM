

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
 *      Definition of the class ProductoCEN
 *
 */
public partial class ProductoCEN
{
private IProductoCAD _IProductoCAD;

public ProductoCEN()
{
        this._IProductoCAD = new ProductoCAD ();
}

public ProductoCEN(IProductoCAD _IProductoCAD)
{
        this._IProductoCAD = _IProductoCAD;
}

public IProductoCAD get_IProductoCAD ()
{
        return this._IProductoCAD;
}

public int New_ (string p_nombre, double p_precio, string p_descripcion, string p_imagen, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum p_valor, int p_stock, string p_descriplarga, string p_imagran, string p_talla)
{
        ProductoEN productoEN = null;
        int oid;

        //Initialized ProductoEN
        productoEN = new ProductoEN ();
        productoEN.Nombre = p_nombre;

        productoEN.Precio = p_precio;

        productoEN.Descripcion = p_descripcion;

        productoEN.Imagen = p_imagen;

        productoEN.Valor = p_valor;

        productoEN.Stock = p_stock;

        productoEN.Descriplarga = p_descriplarga;

        productoEN.Imagran = p_imagran;

        productoEN.Talla = p_talla;

        //Call to ProductoCAD

        oid = _IProductoCAD.New_ (productoEN);
        return oid;
}

public void Modify (int p_producto_OID, string p_nombre, double p_precio, string p_descripcion, string p_imagen, SMPGenNHibernate.Enumerated.SMP.ValoracionEnum p_valor, int p_stock, string p_descriplarga, string p_imagran, string p_talla)
{
        ProductoEN productoEN = null;

        //Initialized ProductoEN
        productoEN = new ProductoEN ();
        productoEN.Id = p_producto_OID;
        productoEN.Nombre = p_nombre;
        productoEN.Precio = p_precio;
        productoEN.Descripcion = p_descripcion;
        productoEN.Imagen = p_imagen;
        productoEN.Valor = p_valor;
        productoEN.Stock = p_stock;
        productoEN.Descriplarga = p_descriplarga;
        productoEN.Imagran = p_imagran;
        productoEN.Talla = p_talla;
        //Call to ProductoCAD

        _IProductoCAD.Modify (productoEN);
}

public void Destroy (int id
                     )
{
        _IProductoCAD.Destroy (id);
}

public System.Collections.Generic.IList<ProductoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ProductoEN> list = null;

        list = _IProductoCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ProductoEN> Filtronombre (string p_nombre)
{
        return _IProductoCAD.Filtronombre (p_nombre);
}
public System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ProductoEN> Filtroprecio (double? p_min, double ? p_max)
{
        return _IProductoCAD.Filtroprecio (p_min, p_max);
}
public System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ProductoEN> Filtrovalor (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum ? p_valor)
{
        return _IProductoCAD.Filtrovalor (p_valor);
}
public System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ProductoEN> Filtrotalla (string p_talla)
{
        return _IProductoCAD.Filtrotalla (p_talla);
}
public ProductoEN ReadOID (int id
                           )
{
        ProductoEN productoEN = null;

        productoEN = _IProductoCAD.ReadOID (id);
        return productoEN;
}
}
}
