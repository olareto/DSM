
using System;
using SMPGenNHibernate.EN.SMP;

namespace SMPGenNHibernate.CAD.SMP
{
public partial interface IProductoCAD
{
ProductoEN ReadOIDDefault (int id
                           );

void ModifyDefault (ProductoEN producto);



int New_ (ProductoEN producto);

void Modify (ProductoEN producto);


void Destroy (int id
              );


System.Collections.Generic.IList<ProductoEN> ReadAll (int first, int size);


System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ProductoEN> Filtronombre (string p_nombre);


System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ProductoEN> Filtroprecio (double? p_min, double ? p_max);


System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ProductoEN> Filtrovalor (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum ? p_valor);


System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ProductoEN> Filtrotalla (string p_talla);


ProductoEN ReadOID (int id
                    );
}
}
