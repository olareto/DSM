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
            if (en.Lista_0 != null)
            {
                art.siguiendo = en.Lista_0.ElementAt(0).Id;
                art.favorito = en.Lista_0.ElementAt(1).Id;
                art.visto = en.Lista_0.ElementAt(2).Id;
            }



            if (en.Carrito_0 != null)
                art.carrito = en.Carrito_0.Id;

            return art;


        }
        public IList<Admin> ConvertListENToModel(IList<AdminEN> ens)
        {
            IList<Admin> arts = new List<Admin>();
            foreach (AdminEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }

    }
}