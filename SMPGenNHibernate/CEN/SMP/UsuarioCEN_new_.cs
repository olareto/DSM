
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using SMPGenNHibernate.Exceptions;
using SMPGenNHibernate.EN.SMP;
using SMPGenNHibernate.CAD.SMP;


/*PROTECTED REGION ID(usingSMPGenNHibernate.CEN.SMP_usuario_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace SMPGenNHibernate.CEN.SMP
{
public partial class UsuarioCEN
{
public string New_ (string p_nombre, string p_apellidos, String p_contrasenya, string p_email, string p_direccion, string p_tarjeta, string p_imagen)
{
        /*PROTECTED REGION ID(SMPGenNHibernate.CEN.SMP_usuario_new__customized) START*/

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

        usuarioEN.

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.New_ (usuarioEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
