
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using SMPGenNHibernate.Exceptions;
using SMPGenNHibernate.EN.SMP;
using SMPGenNHibernate.CAD.SMP;


/*PROTECTED REGION ID(usingSMPGenNHibernate.CEN.SMP_Capitulo_anyadircomentario) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace SMPGenNHibernate.CEN.SMP
{
public partial class CapituloCEN
{
public void Anyadircomentario (int p_oid, string p_comentario, string p_nombre)
{
            /*PROTECTED REGION ID(SMPGenNHibernate.CEN.SMP_Capitulo_anyadircomentario) ENABLED START*/

            // Write here your custom code...

            ComentarioCEN comentarioCEN = null;
            comentarioCEN.New_(p_comentario, p_nombre, new DateTime(1993,12,3));



            CapituloEN capituloEN = null;

        capituloEN = new CapituloEN ();


        //Initialized CapituloEN
        capituloEN = _ICapituloCAD.ReadOIDDefault (p_oid);
        capituloEN.Comentario.Add(comentarioCEN);

        capituloEN.Id = p_oid;


        //Call to CapituloCAD

        _ICapituloCAD.Modify (capituloEN);

        //throw new NotImplementedException ("Method Anyadircomentario() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
