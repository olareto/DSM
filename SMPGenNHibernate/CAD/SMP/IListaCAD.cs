
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


void Addserie (int p_Lista_OID, System.Collections.Generic.IList<int> p_serie_OIDs);

void Delserie (int p_Lista_OID, System.Collections.Generic.IList<int> p_serie_OIDs);

void Addpel (int p_Lista_OID, System.Collections.Generic.IList<int> p_pelicula_OIDs);

void Delpel (int p_Lista_OID, System.Collections.Generic.IList<int> p_pelicula_OIDs);
}
}
