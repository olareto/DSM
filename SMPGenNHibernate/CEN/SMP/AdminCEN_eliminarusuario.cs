
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


/*PROTECTED REGION ID(usingSMPGenNHibernate.CEN.SMP_admin_eliminarusuario) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace SMPGenNHibernate.CEN.SMP
{
public partial class AdminCEN
{
public void Eliminarusuario (string p_oid)
{
        /*PROTECTED REGION ID(SMPGenNHibernate.CEN.SMP_admin_eliminarusuario) ENABLED START*/

        // Write here your custom code...

        AdminEN en = _IAdminCAD.ReadOIDDefault (p_oid);

        //_IUsuarioCAD.Destroy (p_oid);


        throw new NotImplementedException ("Method Eliminarusuario() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
