
using System;
using SMPGenNHibernate.EN.SMP;

namespace SMPGenNHibernate.CAD.SMP
{
public partial interface IOfertaCAD
{
OfertaEN ReadOIDDefault (int id
                         );

void ModifyDefault (OfertaEN oferta);



int New_ (OfertaEN oferta);

void Modify (OfertaEN oferta);


void Destroy (int id
              );


OfertaEN ReadOID (int id
                  );


System.Collections.Generic.IList<OfertaEN> ReadAll (int first, int size);
}
}
