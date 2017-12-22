
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using SMPGenNHibernate.EN.SMP;
using SMPGenNHibernate.CAD.SMP;
using SMPGenNHibernate.CEN.SMP;



/*PROTECTED REGION ID(usingSMPGenNHibernate.CP.SMP_Temporada_anyadircap) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace SMPGenNHibernate.CP.SMP
{
public partial class TemporadaCP : BasicCP
{
public void Anyadircap (int p_oid, string p_nombre, Nullable<DateTime> p_fecha, string p_descripcion, string p_imagen)
{
        /*PROTECTED REGION ID(SMPGenNHibernate.CP.SMP_Temporada_anyadircap) ENABLED START*/

        ITemporadaCAD temporadaCAD = null;
        TemporadaCEN temporadaCEN = null;



        try
        {
                SessionInitializeTransaction ();
                temporadaCAD = new TemporadaCAD (session);
                temporadaCEN = new  TemporadaCEN (temporadaCAD);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method Anyadircap() not yet implemented.");



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
