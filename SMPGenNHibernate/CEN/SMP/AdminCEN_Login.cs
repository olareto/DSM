
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


/*PROTECTED REGION ID(usingSMPGenNHibernate.CEN.SMP_admin_login) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace SMPGenNHibernate.CEN.SMP
{
public partial class AdminCEN
{
public bool Login (string p_oid, string contrasenya)
{
        /*PROTECTED REGION ID(SMPGenNHibernate.CEN.SMP_admin_login) ENABLED START*/

        // Write here your custom code...

        bool result = false;

        AdminEN en = _IAdminCAD.ReadOIDDefault (p_oid);

        if (en != null)
                if (en.Contrasenya.Equals (Utils.Util.GetEncondeMD5 (contrasenya)))
                        result = true;

        return result;

        /*PROTECTED REGION END*/
}
}
}
