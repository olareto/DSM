
using System;
using SMPGenNHibernate.EN.SMP;

namespace SMPGenNHibernate.CAD.SMP
{
public partial interface IComentarioCAD
{
ComentarioEN ReadOIDDefault (int id
                             );

void ModifyDefault (ComentarioEN comentario);



int New_ (ComentarioEN comentario);

void Modify (ComentarioEN comentario);


void Destroy (int id
              );


ComentarioEN ReadOID (int id
                      );


System.Collections.Generic.IList<ComentarioEN> ReadAll (int first, int size);


void Addcap (int p_Comentario_OID, int p_capitulo_OID);

void Addpel (int p_Comentario_OID, int p_pelicula_OID);

void Addart (int p_Comentario_OID, int p_articulo_OID);
}
}
