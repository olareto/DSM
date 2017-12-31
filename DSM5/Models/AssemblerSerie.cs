using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMPGenNHibernate.EN.SMP;

namespace DSM5.Models
{
    public class AssemblerSerie
    {
        public Serie ConvertENToModelUI(SerieEN en)
        {
            Serie art = new Serie();
            art.id = en.Id;
            art.Nombre = en.Nombre;
            art.Valoracion =(int) en.Valoracion;
            art.Imagen = en.Imagen;
         
            return art;
            

        }
        public IList<Serie> ConvertListENToModel (IList<SerieEN> ens){
            IList<Serie> arts = new List<Serie>();
            foreach (SerieEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
        
    }
}