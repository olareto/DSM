
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using SMPGenNHibernate.EN.SMP;
using SMPGenNHibernate.CAD.SMP;
using SMPGenNHibernate.CEN.SMP;



/*PROTECTED REGION ID(usingSMPGenNHibernate.CP.SMP_Pelicula_anyadircomentario) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace SMPGenNHibernate.CP.SMP
{
public partial class PeliculaCP : BasicCP
{
public void Anyadircomentario (int p_oid, string p_comentario, string p_nombre)
{
        /*PROTECTED REGION ID(SMPGenNHibernate.CP.SMP_Pelicula_anyadircomentario) ENABLED START*/

        IPeliculaCAD peliculaCAD = null;
        PeliculaCEN peliculaCEN = null;



        try
        {
                SessionInitializeTransaction ();
                peliculaCAD = new PeliculaCAD (session);
                peliculaCEN = new  PeliculaCEN (peliculaCAD);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method Anyadircomentario() not yet implemented.");



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
