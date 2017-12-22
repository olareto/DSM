

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
 *      Definition of the class AdminCEN
 *
 */
public partial class AdminCEN
{
private IAdminCAD _IAdminCAD;

public AdminCEN()
{
        this._IAdminCAD = new AdminCAD ();
}

public AdminCEN(IAdminCAD _IAdminCAD)
{
        this._IAdminCAD = _IAdminCAD;
}

public IAdminCAD get_IAdminCAD ()
{
        return this._IAdminCAD;
}

public string New_ (string p_nombre, string p_apellidos, String p_contrasenya, string p_email, string p_direccion, string p_tarjeta, string p_imagen)
{
        AdminEN adminEN = null;
        string oid;

        //Initialized AdminEN
        adminEN = new AdminEN ();
        adminEN.Nombre = p_nombre;

        adminEN.Apellidos = p_apellidos;

        adminEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);

        adminEN.Email = p_email;

        adminEN.Direccion = p_direccion;

        adminEN.Tarjeta = p_tarjeta;

        adminEN.Imagen = p_imagen;

        //Call to AdminCAD

        oid = _IAdminCAD.New_ (adminEN);
        return oid;
}

public void Modify (string p_admin_OID, string p_nombre, string p_apellidos, String p_contrasenya, string p_direccion, string p_tarjeta, string p_imagen)
{
        AdminEN adminEN = null;

        //Initialized AdminEN
        adminEN = new AdminEN ();
        adminEN.Email = p_admin_OID;
        adminEN.Nombre = p_nombre;
        adminEN.Apellidos = p_apellidos;
        adminEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);
        adminEN.Direccion = p_direccion;
        adminEN.Tarjeta = p_tarjeta;
        adminEN.Imagen = p_imagen;
        //Call to AdminCAD

        _IAdminCAD.Modify (adminEN);
}

public void Destroy (string email
                     )
{
        _IAdminCAD.Destroy (email);
}

public AdminEN ReadOID (string email
                        )
{
        AdminEN adminEN = null;

        adminEN = _IAdminCAD.ReadOID (email);
        return adminEN;
}

public System.Collections.Generic.IList<AdminEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AdminEN> list = null;

        list = _IAdminCAD.ReadAll (first, size);
        return list;
}
}
}
