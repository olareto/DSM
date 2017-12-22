
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using SMPGenNHibernate.EN.SMP;
using SMPGenNHibernate.CAD.SMP;
using SMPGenNHibernate.CEN.SMP;



/*PROTECTED REGION ID(usingSMPGenNHibernate.CP.SMP_Temporada_borrarcap) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace SMPGenNHibernate.CP.SMP
{
public partial class TemporadaCP : BasicCP
{
public void Borrarcap (int p_oid, int p_id_cap)
{
        /*PROTECTED REGION ID(SMPGenNHibernate.CP.SMP_Temporada_borrarcap) ENABLED START*/

        ITemporadaCAD temporadaCAD = null;
        TemporadaCEN temporadaCEN = null;



        try
        {
                SessionInitializeTransaction ();
                temporadaCAD = new TemporadaCAD (session);
                temporadaCEN = new  TemporadaCEN (temporadaCAD);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method Borrarcap() not yet implemented.");



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
