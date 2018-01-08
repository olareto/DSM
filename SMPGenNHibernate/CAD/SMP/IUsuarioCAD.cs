
using System;
using SMPGenNHibernate.EN.SMP;

namespace SMPGenNHibernate.CAD.SMP
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (string email
                          );

void ModifyDefault (UsuarioEN usuario);



string New_ (UsuarioEN usuario);

void Modify (UsuarioEN usuario);


void Destroy (string email
              );


UsuarioEN ReadOID (string email
                   );


System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size);





string New_CP (UsuarioEN usuario);

void Addlista (string p_usuario_OID, System.Collections.Generic.IList<int> p_lista_OIDs);

void Addcarrito (string p_usuario_OID, int p_carrito_OID);

System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.UsuarioEN> Filtronombre (string p_nombre);
}
}
