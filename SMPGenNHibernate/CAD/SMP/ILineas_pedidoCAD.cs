
using System;
using SMPGenNHibernate.EN.SMP;

namespace SMPGenNHibernate.CAD.SMP
{
public partial interface ILineas_pedidoCAD
{
Lineas_pedidoEN ReadOIDDefault (int id
                                );

void ModifyDefault (Lineas_pedidoEN lineas_pedido);



int New_ (Lineas_pedidoEN lineas_pedido);

void Modify (Lineas_pedidoEN lineas_pedido);


void Destroy (int id
              );


Lineas_pedidoEN ReadOID (int id
                         );


System.Collections.Generic.IList<Lineas_pedidoEN> ReadAll (int first, int size);


void Addevento (int p_lineas_pedido_OID, int p_evento_OID);

void Delevento (int p_lineas_pedido_OID, int p_evento_OID);

void Addproducto (int p_lineas_pedido_OID, int p_producto_OID);

void Delproducto (int p_lineas_pedido_OID, int p_producto_OID);
}
}
