
using System;
using SMPGenNHibernate.EN.SMP;

namespace SMPGenNHibernate.CAD.SMP
{
public partial interface ITemporadaCAD
{
TemporadaEN ReadOIDDefault (int id
                            );

void ModifyDefault (TemporadaEN temporada);



TemporadaEN ReadOID (int id
                     );


System.Collections.Generic.IList<TemporadaEN> ReadAll (int first, int size);


int New_ (TemporadaEN temporada);

void Modify (TemporadaEN temporada);


void Destroy (int id
              );


void Borrarcap (int p_Temporada_OID, System.Collections.Generic.IList<int> p_capitulo_OIDs);

void Addcap (int p_Temporada_OID, System.Collections.Generic.IList<int> p_capitulo_OIDs);
}
}
