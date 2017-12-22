
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using SMPGenNHibernate.EN.SMP;
using SMPGenNHibernate.CAD.SMP;
using SMPGenNHibernate.CEN.SMP;



/*PROTECTED REGION ID(usingSMPGenNHibernate.CP.SMP_Serie_anyadirtemporada) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace SMPGenNHibernate.CP.SMP
{
public partial class SerieCP : BasicCP
{
public void Anyadirtemporada (int p_oid, string p_nombre)
{
        /*PROTECTED REGION ID(SMPGenNHibernate.CP.SMP_Serie_anyadirtemporada) ENABLED START*/

        ISerieCAD serieCAD = null;
        SerieCEN serieCEN = null;



        try
        {
                SessionInitializeTransaction ();
                serieCAD = new SerieCAD (session);
                serieCEN = new  SerieCEN (serieCAD);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method Anyadirtemporada() not yet implemented.");



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
