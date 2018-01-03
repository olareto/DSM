
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using SMPGenNHibernate.EN.SMP;
using SMPGenNHibernate.CAD.SMP;
using SMPGenNHibernate.CEN.SMP;



/*PROTECTED REGION ID(usingSMPGenNHibernate.CP.SMP_usuario_new_CP) ENABLED START*/
//  references to other libraries
using System.Collections.Generic;
/*PROTECTED REGION END*/

namespace SMPGenNHibernate.CP.SMP
{
public partial class UsuarioCP : BasicCP
{
public SMPGenNHibernate.EN.SMP.UsuarioEN New_CP (string p_nombre, string p_apellidos, String p_contrasenya, string p_email, string p_direccion, string p_tarjeta, string p_imagen)
{
        /*PROTECTED REGION ID(SMPGenNHibernate.CP.SMP_usuario_new_CP) ENABLED START*/

        IUsuarioCAD usuarioCAD = null;
        UsuarioCEN usuarioCEN = null;

        SMPGenNHibernate.EN.SMP.UsuarioEN result = null;


        try
        {
                SessionInitializeTransaction ();
                usuarioCAD = new UsuarioCAD (session);
                usuarioCEN = new  UsuarioCEN (usuarioCAD);

                ListaCAD listaCAD = new ListaCAD (session);
                ListaCEN listaCEN = new ListaCEN (listaCAD);


                CarritoCAD CarritoCAD = new CarritoCAD (session);
                CarritoCEN CarritoCEN = new CarritoCEN (CarritoCAD);

                string p_oid;
                //Initialized UsuarioEN
                UsuarioEN usuarioEN;
                usuarioEN = new UsuarioEN ();
                usuarioEN.Nombre = p_nombre;

                usuarioEN.Apellidos = p_apellidos;

                usuarioEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);

                usuarioEN.Email = p_email;

                usuarioEN.Direccion = p_direccion;

                usuarioEN.Tarjeta = p_tarjeta;

                usuarioEN.Imagen = p_imagen;

                //Call to UsuarioCAD

                p_oid = usuarioCAD.New_CP (usuarioEN);

                int id = listaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.Estado_videoEnum.siguiendo, p_oid);
                int id2 = listaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.Estado_videoEnum.favorito, p_oid);
                int id3 = listaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.Estado_videoEnum.visto, p_oid);



                IList<int> listas = new List<int>();
                listas.Add (id);
                listas.Add (id2);
                listas.Add (id3);



                usuarioCEN.Addlista (p_oid, listas);

                result = usuarioCAD.ReadOIDDefault (p_oid);



                SessionCommit ();
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
        return result;


        /*PROTECTED REGION END*/
}
}
}
