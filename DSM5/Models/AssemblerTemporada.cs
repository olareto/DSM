using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMPGenNHibernate.EN.SMP;

namespace DSM5.Models
{
    public class AssemblerTemporada
    {
        public Temporada ConvertENToModelUI(TemporadaEN en)
        {
            Temporada art = new Temporada();
            art.id = en.Id;
            if(en.Serie!=null)
                art.serie = en.Serie.Id;
            
            art.Nombre = en.Nombre;
            
         
            return art;


        }
        public IList<Temporada> ConvertListENToModel (IList<TemporadaEN> ens){
            IList<Temporada> arts = new List<Temporada>();
            foreach (TemporadaEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
        
    }
}