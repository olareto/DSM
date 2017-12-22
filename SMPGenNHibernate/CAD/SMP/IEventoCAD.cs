
using System;
using SMPGenNHibernate.EN.SMP;

namespace SMPGenNHibernate.CAD.SMP
{
public partial interface IEventoCAD
{
EventoEN ReadOIDDefault (int id
                         );

void ModifyDefault (EventoEN evento);



int New_ (EventoEN evento);

void Modify (EventoEN evento);


void Destroy (int id
              );


System.Collections.Generic.IList<EventoEN> ReadAll (int first, int size);


EventoEN ReadOID (int id
                  );


System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.EventoEN> Filtronombre (string p_nombre);


System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.EventoEN> Filtroprecio (double? p_min, double ? p_max);


System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.EventoEN> Filtrovalor (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum ? p_valor);


System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.EventoEN> Filtrotipo (string p_tipo);
}
}
