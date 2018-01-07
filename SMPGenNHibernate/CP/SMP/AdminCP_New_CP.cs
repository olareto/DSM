
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using SMPGenNHibernate.EN.SMP;
using SMPGenNHibernate.CAD.SMP;
using SMPGenNHibernate.CEN.SMP;



/*PROTECTED REGION ID(usingSMPGenNHibernate.CP.SMP_admin_new_CP) ENABLED START*/
//  references to other libraries
using System.Collections.Generic;
/*PROTECTED REGION END*/

namespace SMPGenNHibernate.CP.SMP
{
public partial class AdminCP : BasicCP
{
public SMPGenNHibernate.EN.SMP.AdminEN New_CP (string p_nombre, string p_apellidos, String p_contrasenya, string p_email, string p_direccion, string p_tarjeta, string p_imagen)
{
        /*PROTECTED REGION ID(SMPGenNHibernate.CP.SMP_admin_new_CP) ENABLED START*/

        IAdminCAD adminCAD = null;
        AdminCEN adminCEN = null;

        SMPGenNHibernate.EN.SMP.AdminEN result = null;


        try
        {
                SessionInitializeTransaction ();
                adminCAD = new AdminCAD (session);
                adminCEN = new  AdminCEN (adminCAD);


                ListaCAD listaCAD = new ListaCAD (session);
                ListaCEN listaCEN = new ListaCEN (listaCAD);


                UsuarioCAD usuarioCAD = new UsuarioCAD (session);
                UsuarioCEN usuarioCEN = new UsuarioCEN (usuarioCAD);

                CarritoCAD CarritoCAD = new CarritoCAD (session);
                CarritoCEN CarritoCEN = new CarritoCEN (CarritoCAD);

                string oid;
                //Initialized AdminEN
                AdminEN adminEN;
                adminEN = new AdminEN ();
                adminEN.Nombre = p_nombre;

                adminEN.Apellidos = p_apellidos;

                adminEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);

                adminEN.Email = p_email;

                adminEN.Direccion = p_direccion;

                adminEN.Tarjeta = p_tarjeta;

                adminEN.Imagen = p_imagen;

                //Call to AdminCAD

                oid = adminCAD.New_CP (adminEN);




                int id = listaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.Estado_videoEnum.siguiendo, oid);
                int id2 = listaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.Estado_videoEnum.favorito, oid);
                int id3 = listaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.Estado_videoEnum.visto, oid);



                IList<int> listas = new List<int>();
                listas.Add (id);
                listas.Add (id2);
                listas.Add (id3);



                usuarioCEN.Addlista (oid, listas);

                result = adminCAD.ReadOIDDefault (oid);

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
