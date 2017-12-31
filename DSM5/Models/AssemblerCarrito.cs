using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMPGenNHibernate.EN.SMP;

namespace DSM5.Models
{
    public class AssemblerCarrito
    {
        public Carrito ConvertENToModelUI(CarritoEN en)
        {
            Carrito art = new Carrito();
            art.id = en.Id;
            art.Precio = en.Precio;
            if (en.Usuario != null)
                art.Usuario = en.Usuario.Email;

            return art;


        }
        public IList<Carrito> ConvertListENToModel (IList<CarritoEN> ens){
            IList<Carrito> carritos = new List<Carrito>();
            foreach (CarritoEN en in ens)
            {
                carritos.Add(ConvertENToModelUI(en));
            }
            return carritos;
        }
        
    }
}