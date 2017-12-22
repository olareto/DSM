
using System;
using SMPGenNHibernate.EN.SMP;

namespace SMPGenNHibernate.CAD.SMP
{
public partial interface ISerieCAD
{
SerieEN ReadOIDDefault (int id
                        );

void ModifyDefault (SerieEN serie);



int New_ (SerieEN serie);

void Modify (SerieEN serie);


void Destroy (int id
              );


SerieEN ReadOID (int id
                 );


System.Collections.Generic.IList<SerieEN> ReadAll (int first, int size);


void Eliminartemporada (int p_Serie_OID, System.Collections.Generic.IList<int> p_temporada_OIDs);

void Addtemporada (int p_Serie_OID, System.Collections.Generic.IList<int> p_temporada_OIDs);
}
}
