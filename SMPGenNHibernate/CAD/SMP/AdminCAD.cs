
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
 * Clase admin:
 *
 */

namespace SMPGenNHibernate.CAD.SMP
{
public partial class AdminCAD : BasicCAD, IAdminCAD
{
public AdminCAD() : base ()
{
}

public AdminCAD(ISession sessionAux) : base (sessionAux)
{
}



public AdminEN ReadOIDDefault (string email
                               )
{
        AdminEN adminEN = null;

        try
        {
                SessionInitializeTransaction ();
                adminEN = (AdminEN)session.Get (typeof(AdminEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return adminEN;
}

public System.Collections.Generic.IList<AdminEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<AdminEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(AdminEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<AdminEN>();
                        else
                                result = session.CreateCriteria (typeof(AdminEN)).List<AdminEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (AdminEN admin)
{
        try
        {
                SessionInitializeTransaction ();
                AdminEN adminEN = (AdminEN)session.Load (typeof(AdminEN), admin.Email);


                session.Update (adminEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string New_ (AdminEN admin)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (admin);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return admin.Email;
}

public void Modify (AdminEN admin)
{
        try
        {
                SessionInitializeTransaction ();
                AdminEN adminEN = (AdminEN)session.Load (typeof(AdminEN), admin.Email);

                adminEN.Nombre = admin.Nombre;


                adminEN.Apellidos = admin.Apellidos;


                adminEN.Contrasenya = admin.Contrasenya;


                adminEN.Direccion = admin.Direccion;


                adminEN.Tarjeta = admin.Tarjeta;


                adminEN.Imagen = admin.Imagen;

                session.Update (adminEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (string email
                     )
{
        try
        {
                SessionInitializeTransaction ();
                AdminEN adminEN = (AdminEN)session.Load (typeof(AdminEN), email);
                session.Delete (adminEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: AdminEN
public AdminEN ReadOID (string email
                        )
{
        AdminEN adminEN = null;

        try
        {
                SessionInitializeTransaction ();
                adminEN = (AdminEN)session.Get (typeof(AdminEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return adminEN;
}

public System.Collections.Generic.IList<AdminEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AdminEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AdminEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<AdminEN>();
                else
                        result = session.CreateCriteria (typeof(AdminEN)).List<AdminEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public string New_CP (AdminEN admin)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (admin);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return admin.Email;
}

public void Addlista (string p_admin_OID, System.Collections.Generic.IList<int> p_lista_0_OIDs)
{
        SMPGenNHibernate.EN.SMP.AdminEN adminEN = null;
        try
        {
                SessionInitializeTransaction ();
                adminEN = (AdminEN)session.Load (typeof(AdminEN), p_admin_OID);
                SMPGenNHibernate.EN.SMP.ListaEN lista_0ENAux = null;
                if (adminEN.Lista_0 == null) {
                        adminEN.Lista_0 = new System.Collections.Generic.List<SMPGenNHibernate.EN.SMP.ListaEN>();
                }

                foreach (int item in p_lista_0_OIDs) {
                        lista_0ENAux = new SMPGenNHibernate.EN.SMP.ListaEN ();
                        lista_0ENAux = (SMPGenNHibernate.EN.SMP.ListaEN)session.Load (typeof(SMPGenNHibernate.EN.SMP.ListaEN), item);
                        lista_0ENAux.Admin = adminEN;

                        adminEN.Lista_0.Add (lista_0ENAux);
                }


                session.Update (adminEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Addcarrito (string p_admin_OID, int p_carrito_0_OID)
{
        SMPGenNHibernate.EN.SMP.AdminEN adminEN = null;
        try
        {
                SessionInitializeTransaction ();
                adminEN = (AdminEN)session.Load (typeof(AdminEN), p_admin_OID);
                adminEN.Carrito_0 = (SMPGenNHibernate.EN.SMP.CarritoEN)session.Load (typeof(SMPGenNHibernate.EN.SMP.CarritoEN), p_carrito_0_OID);

                adminEN.Carrito_0.Admin = adminEN;




                session.Update (adminEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SMPGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new SMPGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
