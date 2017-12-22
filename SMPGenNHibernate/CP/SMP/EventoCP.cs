
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using SMPGenNHibernate.Exceptions;
using SMPGenNHibernate.EN.SMP;
using SMPGenNHibernate.CAD.SMP;
using SMPGenNHibernate.CEN.SMP;


namespace SMPGenNHibernate.CP.SMP
{
public partial class EventoCP : BasicCP
{
public EventoCP() : base ()
{
}

public EventoCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
