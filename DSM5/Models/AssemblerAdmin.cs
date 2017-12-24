using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMPGenNHibernate.EN.SMP;

namespace DSM5.Models
{
    public class AssemblerAdmin
    {
        public Admin ConvertENToModelUI(AdminEN en)
        {
            Admin art = new Admin();
            //art.id = en.;
            
            art.Nombre = en.Nombre;
            art.Apellidos = en.Apellidos;
            art.Password = en.Contrasenya;
            art.Email = en.Email;
            art.Direccion = en.Direccion;
            art.Tarjeta = en.Tarjeta;
            art.Imagen = en.Imagen;
           
            return art;


        }
        public IList<Admin> ConvertListENToModel (IList<AdminEN> ens){
            IList<Admin> arts = new List<Admin>();
            foreach (AdminEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
        
    }
}