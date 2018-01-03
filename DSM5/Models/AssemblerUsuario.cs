using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMPGenNHibernate.EN.SMP;

namespace DSM5.Models
{
    public class AssemblerUsuario
    {
        public Usuario ConvertENToModelUI(UsuarioEN en)
        {
            Usuario art = new Usuario();
            //art.id = en.;
            




            art.Nombre = en.Nombre;
            art.Apellidos = en.Apellidos;
            art.Password = en.Contrasenya;
            art.Email = en.Email;
            art.Direccion = en.Direccion;
            art.Tarjeta = en.Tarjeta;
            art.Imagen = en.Imagen;
            if (en.Lista!=null)
            {
                art.siguiendo=en.Lista.ElementAt(0).Id;
                art.favorito= en.Lista.ElementAt(1).Id;
                art.visto= en.Lista.ElementAt(2).Id;
            }
            


            if (en.Carrito != null)
                art.carrito = en.Carrito.Id;
           
            return art;


        }
        public IList<Usuario> ConvertListENToModel (IList<UsuarioEN> ens){
            IList<Usuario> arts = new List<Usuario>();
            foreach (UsuarioEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
        
    }
}