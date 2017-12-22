
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
public partial class ArticuloCP : BasicCP
{
public ArticuloCP() : base ()
{
}

public ArticuloCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
