
using System;
using SMPGenNHibernate.EN.SMP;

namespace SMPGenNHibernate.CAD.SMP
{
public partial interface IPeliculaCAD
{
PeliculaEN ReadOIDDefault (int id
                           );

void ModifyDefault (PeliculaEN pelicula);



int New_ (PeliculaEN pelicula);

void Modify (PeliculaEN pelicula);


void Destroy (int id
              );


PeliculaEN ReadOID (int id
                    );


System.Collections.Generic.IList<PeliculaEN> ReadAll (int first, int size);


void Eliminarcomentario (int p_Pelicula_OID, System.Collections.Generic.IList<int> p_comentario_OIDs);

void Addcomentario (int p_Pelicula_OID, System.Collections.Generic.IList<int> p_comentario_OIDs);
}
}
