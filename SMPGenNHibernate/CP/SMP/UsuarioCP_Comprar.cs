
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using SMPGenNHibernate.EN.SMP;
using SMPGenNHibernate.CAD.SMP;
using SMPGenNHibernate.CEN.SMP;



/*PROTECTED REGION ID(usingSMPGenNHibernate.CP.SMP_usuario_comprar) ENABLED START*/
//  references to other libraries
using System.Collections.Generic;

/*PROTECTED REGION END*/

namespace SMPGenNHibernate.CP.SMP
{
public partial class UsuarioCP : BasicCP
{
public void Comprar (string p_oid)
{
        /*PROTECTED REGION ID(SMPGenNHibernate.CP.SMP_usuario_comprar) ENABLED START*/

        IUsuarioCAD usuarioCAD = null;
        ILineas_pedidoCAD listaCAD = null;

        UsuarioCEN usuarioCEN = null;
        Lineas_pedidoCEN listaCEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioCAD = new UsuarioCAD (session);
                listaCAD = new Lineas_pedidoCAD (session);

                usuarioCEN = new  UsuarioCEN (usuarioCAD);
                listaCEN = new Lineas_pedidoCEN (listaCAD);
                // Write here your custom transaction ...


                //throw new NotImplementedException ("Method Anyadircomentario() not yet implemented.");

                UsuarioEN usuarioEN = usuarioCEN.ReadOID (p_oid);
                CarritoEN carritoEN = usuarioEN.Carrito;
                IList<Lineas_pedidoEN> listas = new List<Lineas_pedidoEN>();
                listas = carritoEN.Lineas_pedido;
                foreach (Lineas_pedidoEN aux in listas) {
                        aux.Articulo_0.Stock = aux.Articulo_0.Stock - aux.Cantidad;
                        listaCEN.Destroy (aux.Id);
                }
                SessionCommit ();

                //explicacion vaciar carrito, reduzca el stock de los articulos comprados.
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
