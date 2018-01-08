

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
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioCAD _IUsuarioCAD;

public UsuarioCEN()
{
        this._IUsuarioCAD = new UsuarioCAD ();
}

public UsuarioCEN(IUsuarioCAD _IUsuarioCAD)
{
        this._IUsuarioCAD = _IUsuarioCAD;
}

public IUsuarioCAD get_IUsuarioCAD ()
{
        return this._IUsuarioCAD;
}

public string New_ (string p_nombre, string p_apellidos, String p_contrasenya, string p_email, string p_direccion, string p_tarjeta, string p_imagen)
{
        UsuarioEN usuarioEN = null;
        string oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Nombre = p_nombre;

        usuarioEN.Apellidos = p_apellidos;

        usuarioEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);

        usuarioEN.Email = p_email;

        usuarioEN.Direccion = p_direccion;

        usuarioEN.Tarjeta = p_tarjeta;

        usuarioEN.Imagen = p_imagen;

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.New_ (usuarioEN);
        return oid;
}

public void Modify (string p_usuario_OID, string p_nombre, string p_apellidos, String p_contrasenya, string p_direccion, string p_tarjeta, string p_imagen)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Email = p_usuario_OID;
        usuarioEN.Nombre = p_nombre;
        usuarioEN.Apellidos = p_apellidos;
        usuarioEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);
        usuarioEN.Direccion = p_direccion;
        usuarioEN.Tarjeta = p_tarjeta;
        usuarioEN.Imagen = p_imagen;
        //Call to UsuarioCAD

        _IUsuarioCAD.Modify (usuarioEN);
}

public void Destroy (string email
                     )
{
        _IUsuarioCAD.Destroy (email);
}

public UsuarioEN ReadOID (string email
                          )
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioCAD.ReadOID (email);
        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> list = null;

        list = _IUsuarioCAD.ReadAll (first, size);
        return list;
}
public void Addlista (string p_usuario_OID, System.Collections.Generic.IList<int> p_lista_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.Addlista (p_usuario_OID, p_lista_OIDs);
}
public void Addcarrito (string p_usuario_OID, int p_carrito_OID)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.Addcarrito (p_usuario_OID, p_carrito_OID);
}
public System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.UsuarioEN> Filtronombre (string p_nombre)
{
        return _IUsuarioCAD.Filtronombre (p_nombre);
}
}
}
