
using System;
using SMPGenNHibernate.EN.SMP;

namespace SMPGenNHibernate.CAD.SMP
{
public partial interface ICapituloCAD
{
CapituloEN ReadOIDDefault (int id
                           );

void ModifyDefault (CapituloEN capitulo);



int New_ (CapituloEN capitulo);

void Modify (CapituloEN capitulo);


void Destroy (int id
              );


CapituloEN ReadOID (int id
                    );


System.Collections.Generic.IList<CapituloEN> ReadAll (int first, int size);



void Borrarcomentario (int p_Capitulo_OID, System.Collections.Generic.IList<int> p_comentario_OIDs);

void Addcomentario (int p_Capitulo_OID, System.Collections.Generic.IList<int> p_comentario_OIDs);
}
}
