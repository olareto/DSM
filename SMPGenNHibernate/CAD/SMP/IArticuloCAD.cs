
using System;
using SMPGenNHibernate.EN.SMP;

namespace SMPGenNHibernate.CAD.SMP
{
public partial interface IArticuloCAD
{
ArticuloEN ReadOIDDefault (int id
                           );

void ModifyDefault (ArticuloEN articulo);



int New_ (ArticuloEN articulo);

void Modify (ArticuloEN articulo);


void Destroy (int id
              );


ArticuloEN ReadOID (int id
                    );


System.Collections.Generic.IList<ArticuloEN> ReadAll (int first, int size);


void Eliminarcomentario (int p_articulo_OID, System.Collections.Generic.IList<int> p_comentario_OIDs);

System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ArticuloEN> Filtronombre (string p_nombre);


System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ArticuloEN> Filtroprecio (double? p_min, double ? p_max);


System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ArticuloEN> Filtrovalor (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum ? p_valor);


void Addcomentario (int p_articulo_OID, System.Collections.Generic.IList<int> p_comentario_OIDs);
}
}
