
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


/*PROTECTED REGION ID(usingSMPGenNHibernate.CEN.SMP_usuario_anyadirpago) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace SMPGenNHibernate.CEN.SMP
{
public partial class UsuarioCEN
{
public void Anyadirpago (string p_oid)
{
        /*PROTECTED REGION ID(SMPGenNHibernate.CEN.SMP_usuario_anyadirpago) ENABLED START*/

        // Write here your custom code...

        UsuarioEN en = _IUsuarioCAD.ReadOIDDefault (p_oid);

        en.Tarjeta = num_tarjeta;
        _IUsuarioCAD.Modify (en);

        throw new NotImplementedException ("Method Anyadirpago() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
