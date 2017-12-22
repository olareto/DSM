
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


/*PROTECTED REGION ID(usingSMPGenNHibernate.CEN.SMP_usuario_recuperarcontrasenya) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace SMPGenNHibernate.CEN.SMP
{
public partial class UsuarioCEN
{
public String Recuperarcontrasenya (string p_oid)
{
        /*PROTECTED REGION ID(SMPGenNHibernate.CEN.SMP_usuario_recuperarcontrasenya) ENABLED START*/

        // Write here your custom code...

        String result = "";

        UsuarioEN en = _IUsuarioCAD.ReadOIDDefault (p_oid);

        result = "1234";
        String secret = Utils.Util.GetEncondeMD5 (result);
        en.Contrasenya = secret;

        _IUsuarioCAD.Modify (en);


        return result;

        /*PROTECTED REGION END*/
}
}
}
