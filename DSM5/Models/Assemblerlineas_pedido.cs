using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMPGenNHibernate.EN.SMP;

namespace DSM5.Models
{
    public class AssemblerLineas_pedido
    {
        public Lineas_pedido ConvertENToModelUI(Lineas_pedidoEN en)
        {
            Lineas_pedido art = new Lineas_pedido();
            art.cantidad = en.Cantidad;
            art.id = en.Id;
            if (en.Carrito != null)
            {
                art.carrito = en.Carrito.Id;
            }
            if (en.Producto != null)
            {
                art.articulo = en.Producto.Id;
                art.tipo = "Producto";
            }
            if (en.Evento != null)
            {
                art.articulo = en.Evento.Id;
                art.tipo = "Evento";
            }

            return art;


        }
        public IList<Lineas_pedido> ConvertListENToModel (IList<Lineas_pedidoEN> ens){
            IList<Lineas_pedido> carritos = new List<Lineas_pedido>();
            foreach (Lineas_pedidoEN en in ens)
            {
                carritos.Add(ConvertENToModelUI(en));
            }
            return carritos;
        }
        
    }
}