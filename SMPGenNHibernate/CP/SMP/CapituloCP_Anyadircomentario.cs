
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using SMPGenNHibernate.EN.SMP;
using SMPGenNHibernate.CAD.SMP;
using SMPGenNHibernate.CEN.SMP;



/*PROTECTED REGION ID(usingSMPGenNHibernate.CP.SMP_Capitulo_anyadircomentario) ENABLED START*/
//  references to other libraries
using System.Collections.Generic;

/*PROTECTED REGION END*/

namespace SMPGenNHibernate.CP.SMP
{
public partial class CapituloCP : BasicCP
{
public void Anyadircomentario (int p_oid, string p_comentario, string p_nombre)
{
        /*PROTECTED REGION ID(SMPGenNHibernate.CP.SMP_Capitulo_anyadircomentario) ENABLED START*/

        ICapituloCAD capituloCAD = null;
        CapituloCEN capituloCEN = null;



        try
        {
                SessionInitializeTransaction ();
                capituloCAD = new CapituloCAD (session);
                capituloCEN = new  CapituloCEN (capituloCAD);



                // Write here your custom transaction ...


                //throw new NotImplementedException ("Method Anyadircomentario() not yet implemented.");

                ComentarioCAD comentarioCAD = new ComentarioCAD (session);

                ComentarioCEN comentarioCEN = new ComentarioCEN (comentarioCAD);

                CapituloEN capitulo = capituloCAD.ReadOIDDefault (p_oid);

                //capitulo.Comentario.Add(comentario);
                capituloCEN = new CapituloCEN (capituloCAD);

                int id = comentarioCEN.New_ (p_comentario, p_nombre, new DateTime (1993, 12, 3));

                capituloCEN.Addcomentario (p_oid, new List<int>() {
                                id
                        });

                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
