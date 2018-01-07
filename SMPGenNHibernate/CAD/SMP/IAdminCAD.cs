
using System;
using SMPGenNHibernate.EN.SMP;

namespace SMPGenNHibernate.CAD.SMP
{
public partial interface IAdminCAD
{
AdminEN ReadOIDDefault (string email
                        );

void ModifyDefault (AdminEN admin);



string New_ (AdminEN admin);

void Modify (AdminEN admin);


void Destroy (string email
              );


AdminEN ReadOID (string email
                 );


System.Collections.Generic.IList<AdminEN> ReadAll (int first, int size);



string New_CP (AdminEN admin);

void Addlista (string p_admin_OID, System.Collections.Generic.IList<int> p_lista_0_OIDs);

void Addcarrito (string p_admin_OID, int p_carrito_0_OID);
}
}
