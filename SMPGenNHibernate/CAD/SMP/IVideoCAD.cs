
using System;
using SMPGenNHibernate.EN.SMP;

namespace SMPGenNHibernate.CAD.SMP
{
public partial interface IVideoCAD
{
VideoEN ReadOIDDefault (int id
                        );

void ModifyDefault (VideoEN video);



int New_ (VideoEN video);

void Modify (VideoEN video);


void Destroy (int id
              );


VideoEN ReadOID (int id
                 );


System.Collections.Generic.IList<VideoEN> ReadAll (int first, int size);
}
}
