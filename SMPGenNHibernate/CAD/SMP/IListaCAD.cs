
using System;
using SMPGenNHibernate.EN.SMP;

namespace SMPGenNHibernate.CAD.SMP
{
public partial interface IListaCAD
{
ListaEN ReadOIDDefault (int id
                        );

void ModifyDefault (ListaEN lista);



int New_ (ListaEN lista);

void Modify (ListaEN lista);


void Destroy (int id
              );


ListaEN ReadOID (int id
                 );


System.Collections.Generic.IList<ListaEN> ReadAll (int first, int size);


void Addvideo (int p_Lista_OID, System.Collections.Generic.IList<int> p_video_OIDs);

void Eliminarvideo (int p_Lista_OID, System.Collections.Generic.IList<int> p_video_OIDs);
}
}
