
using System;
using System.Text;
using SMPGenNHibernate.CEN.SMP;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using SMPGenNHibernate.EN.SMP;
using SMPGenNHibernate.Exceptions;


/*
 * Clase producto:
 *
 */

namespace SMPGenNHibernate.CAD.SMP
{
public partial class ProductoCAD : BasicCAD, IProductoCAD
{
public ProductoCAD() : base ()
{
}

public ProductoCAD(ISession sessionAux) : base (sessionAux)
{
}



public ProductoEN ReadOIDDefault (int id
                                  )
{
        ProductoEN productoEN = null;

        try
        {
                SessionInitializeTransaction ();
                productoEN = (ProductoEN)session.Get (typeof(ProductoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return productoEN;
}

public System.Collections.Generic.IList<ProductoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ProductoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ProductoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ProductoEN>();
                        else
                                result = session.CreateCriteria (typeof(ProductoEN)).List<ProductoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ProductoEN producto)
{
        try
        {
                SessionInitializeTransaction ();
                ProductoEN productoEN = (ProductoEN)session.Load (typeof(ProductoEN), producto.Id);

                productoEN.Talla = producto.Talla;


                session.Update (productoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ProductoEN producto)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (producto);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return producto.Id;
}

public void Modify (ProductoEN producto)
{
        try
        {
                SessionInitializeTransaction ();
                ProductoEN productoEN = (ProductoEN)session.Load (typeof(ProductoEN), producto.Id);

                productoEN.Nombre = producto.Nombre;


                productoEN.Precio = producto.Precio;


                productoEN.Descripcion = producto.Descripcion;


                productoEN.Imagen = producto.Imagen;


                productoEN.Valor = producto.Valor;


                productoEN.Stock = producto.Stock;


                productoEN.Talla = producto.Talla;

                session.Update (productoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                ProductoEN productoEN = (ProductoEN)session.Load (typeof(ProductoEN), id);
                session.Delete (productoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<ProductoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ProductoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ProductoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ProductoEN>();
                else
                        result = session.CreateCriteria (typeof(ProductoEN)).List<ProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ProductoEN> Filtronombre (string p_nombre)
{
        System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ProductoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProductoEN self where FROM ProductoEN art where art.Nombre = :p_nombre";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProductoENfiltronombreHQL");
                query.SetParameter ("p_nombre", p_nombre);

                result = query.List<SMPGenNHibernate.EN.SMP.ProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ProductoEN> Filtroprecio (double? p_min, double ? p_max)
{
        System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ProductoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProductoEN self where FROM ProductoEN art where art.Precio > :p_min and art.Precio < :p_max ";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProductoENfiltroprecioHQL");
                query.SetParameter ("p_min", p_min);
                query.SetParameter ("p_max", p_max);

                result = query.List<SMPGenNHibernate.EN.SMP.ProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ProductoEN> Filtrovalor (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum ? p_valor)
{
        System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ProductoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProductoEN self where FROM ProductoEN art where art.Valor = :p_valor";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProductoENfiltrovalorHQL");
                query.SetParameter ("p_valor", p_valor);

                result = query.List<SMPGenNHibernate.EN.SMP.ProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ProductoEN> Filtrotalla (string p_talla)
{
        System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ProductoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProductoEN self where FROM ProductoEN art where art.Talla = :p_talla";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProductoENfiltrotallaHQL");
                query.SetParameter ("p_talla", p_talla);

                result = query.List<SMPGenNHibernate.EN.SMP.ProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
//Sin e: ReadOID
//Con e: ProductoEN
public ProductoEN ReadOID (int id
                           )
{
        ProductoEN productoEN = null;

        try
        {
                SessionInitializeTransaction ();
                productoEN = (ProductoEN)session.Get (typeof(ProductoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return productoEN;
}
}
}
