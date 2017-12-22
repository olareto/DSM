
using System;
using SMPGenNHibernate.EN.SMP;

namespace SMPGenNHibernate.CAD.SMP
{
public partial interface ICarritoCAD
{
CarritoEN ReadOIDDefault (int id
                          );

void ModifyDefault (CarritoEN carrito);



int New_ (CarritoEN carrito);

void Modify (CarritoEN carrito);


void Destroy (int id
              );


CarritoEN ReadOID (int id
                   );


System.Collections.Generic.IList<CarritoEN> ReadAll (int first, int size);


void Eliminarlinea (int p_carrito_OID, System.Collections.Generic.IList<int> p_lineas_pedido_OIDs);

void Addlinea (int p_carrito_OID, System.Collections.Generic.IList<int> p_lineas_pedido_OIDs);
}
}
