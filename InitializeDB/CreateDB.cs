
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using SMPGenNHibernate.EN.SMP;
using SMPGenNHibernate.CEN.SMP;
using SMPGenNHibernate.CAD.SMP;
using SMPGenNHibernate.CP.SMP;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                #region declaraciones

                IUsuarioCAD _IUsuarioCAD = new UsuarioCAD ();
                IAdminCAD _IAdminCAD = new AdminCAD ();
                IEventoCAD _IEventoCAD = new EventoCAD ();
                ICarritoCAD _ICarritoCAD = new CarritoCAD ();
                ILineas_pedidoCAD _ILineas_pedidoCAD = new Lineas_pedidoCAD ();
                IArticuloCAD _IArticuloCAD = new ArticuloCAD ();
                IOfertaCAD _IOfertaCAD = new OfertaCAD ();
                IProductoCAD _IProductoCAD = new ProductoCAD ();
                IListaCAD _IListaCAD = new ListaCAD ();
                IComentarioCAD _IComentarioCAD = new ComentarioCAD ();
                IPeliculaCAD _IPeliculaCAD = new PeliculaCAD ();
                IVideoCAD _IVideoCAD = new VideoCAD ();
                ICapituloCAD _ICapituloCAD = new CapituloCAD ();
                ITemporadaCAD _ITemporadaCAD = new TemporadaCAD ();
                ISerieCAD _ISerieCAD = new SerieCAD ();



                //UsuarioEN usuarioEN = new UsuarioEN ();
                UsuarioCEN usuarioCEN = new UsuarioCEN (_IUsuarioCAD);

                UsuarioCP usuarioCP = new UsuarioCP ();


                AdminEN adminEN = new AdminEN ();
                AdminCEN adminCEN = new AdminCEN (_IAdminCAD);

                EventoEN eventoEN = new EventoEN ();
                EventoCEN eventoCEN = new EventoCEN (_IEventoCAD);

                CarritoEN carritoEN = new CarritoEN ();
                CarritoCEN carritoCEN = new CarritoCEN (_ICarritoCAD);

                Lineas_pedidoEN lineas_pedidoEN = new Lineas_pedidoEN ();
                Lineas_pedidoCEN lineas_pedidoCEN = new Lineas_pedidoCEN (_ILineas_pedidoCAD);

                ArticuloEN articuloEN = new ArticuloEN ();
                ArticuloCEN articuloCEN = new ArticuloCEN (_IArticuloCAD);

                OfertaEN ofertaEN = new OfertaEN ();
                OfertaCEN ofertaCEN = new OfertaCEN (_IOfertaCAD);

                ProductoEN productoEN = new ProductoEN ();
                ProductoCEN productoCEN = new ProductoCEN (_IProductoCAD);

                ListaEN listaEN = new ListaEN ();
                ListaCEN listaCEN = new ListaCEN (_IListaCAD);

                ComentarioEN comentarioEN = new ComentarioEN ();
                ComentarioCEN comentarioCEN = new ComentarioCEN (_IComentarioCAD);

                PeliculaEN peliculaEN = new PeliculaEN ();
                PeliculaCEN peliculaCEN = new PeliculaCEN (_IPeliculaCAD);

                VideoEN videoEN = new VideoEN ();
                VideoCEN videoCEN = new VideoCEN (_IVideoCAD);

                CapituloEN capituloEN = new CapituloEN ();
                CapituloCEN capituloCEN = new CapituloCEN (_ICapituloCAD);

                TemporadaEN temporadaEN = new TemporadaEN ();
                TemporadaCEN temporadaCEN = new TemporadaCEN (_ITemporadaCAD);

                SerieEN serieEN = new SerieEN ();
                SerieCEN serieCEN = new SerieCEN (_ISerieCAD);
                #endregion
                #region Todos los new
                //Cliente 1

                // usuarioEN = new UsuarioEN();
                // usuarioEN.Nombre = "german";
                //usuarioEN.Apellidos = "es gay";
                //usuarioEN.Contrasenya = "lo_es";

                System.Console.WriteLine ("Creando Usuario");
                UsuarioEN usuarioEN = usuarioCP.New_CP ("usuario", "apellidos", "contrasenya", "correo", "direcccion", "pago", "imagen");

                string idUsuario = usuarioEN.Email;

                //string idUsuario = usuarioCEN.New_("usuario", "apellidos", "contrasenya", "correo", "direcccion", "pago", "imagen");
                //adminCEN.New_ ("usuario", "apellidos", "contrasenya", "correo", "direcccion", "pago", "imagen"));
                int idevento = eventoCEN.New_ ("evento", 72, "descripcion", "imagen", SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.dos, 8, "tipo");
                int idCarrito = carritoCEN.New_ (idUsuario, 50000);

                int idArticulo = articuloCEN.New_ ("articulo", 69, "descripcion", "imagen", SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, 999);

                int idlineas_pedido = lineas_pedidoCEN.New_ (idCarrito, 3);


                int idoferta = ofertaCEN.New_ (idArticulo, new DateTime (1993, 12, 3), new DateTime (1993, 12, 3), 99);

                int idproducto = productoCEN.New_ ("producto", 69, "descripcion", "imagen", SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, 999, "talla");
                lineas_pedidoCEN.Addproducto (idlineas_pedido, idproducto);
                int idlista = listaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.Estado_videoEnum.visto, idUsuario);
                int idcomentario = comentarioCEN.New_ ("comentario", "autor", new DateTime (1993, 12, 3));
                int idpelicula = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Star Wars 8", "i5.jpg");
                int idpelicula2 = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "Jumanji", "i2.jpg");
                int idpelicula3 = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.tres, "COCO", "i7.jpg");
                int idpelicula4 = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "Perfectos desconocidos", "i3.jpg");
                int idpelicula5 = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "Noseq la nota final", "i4.jpg");
                int idpelicula6 = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "Ferdinand", "i6.jpg");
                int idpelicula7 = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "Algo de una ventana", "i8.jpg");
                int idvideo = videoCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "nombre", "hola");
                int idserie = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Las Vegas", "s1.jpg");
                int idserie2 = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Happy", "s2.jpg");
                int idserie3 = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "The Miniaturist", "s3.jpg");
                int idserie4 = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Damnation", "s4.jpg");
                int idserie5 = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Van Helsing", "s5.jpg");
                int idserie6 = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Runaways", "s6.jpg");
                int idserie7 = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Accidente", "s7.jpg");

                int idtemporada = temporadaCEN.New_ (idserie, "nombre");
                int idcapitulo = capituloCEN.New_ (idtemporada, "nombre", new DateTime (1993, 12, 3), "descripccion", "imagen");

                #endregion


                /*
                 * Usuario
                 * A
                 * dmin
                 * Evento
                 * Carrito
                 * Lineas_pedido
                 * Articulo
                 * Oferta
                 * Producto
                 * Lista
                 * Comentario
                 * Pelicula
                 * Video
                 * Capitulo
                 * Temporada
                 * Serie
                 */



                #region Comprobaciones funciones
                // poner todas las funciones para comprobarlas aqui
                //

                usuarioCP.Comprar (idUsuario);

                bool resultadonice = usuarioCEN.Login (idUsuario, "correro");
                System.Console.WriteLine ("resultado malo=" + resultadonice);

                bool resultadobad = usuarioCEN.Login (idUsuario, "lo_ezfdsfdsa");
                System.Console.WriteLine ("resultado malo=" + resultadobad);

                bool resultadojonon = usuarioCEN.Login (idUsuario, "contrasenya");
                System.Console.WriteLine ("resultado bueno=" + resultadojonon);


                //esquema comporbacion
                /**
                 * //if (usuarioCEN.Login(OID, "dsm"))
                 * System.Console.WriteLine ("LOGIN CORRECTO");
                 * // else
                 * System.Console.WriteLine ("LOGIN INCORRECTO");
                 **/
                #endregion
                #region Comprobaciones filtros
                //poner todos los filtros aqui
                IList<ArticuloEN> hola, hola1, hola2;
                hola = articuloCEN.Filtronombre ("pene");
                hola1 = articuloCEN.Filtrovalor (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco);
                hola2 = articuloCEN.Filtroprecio (50, 2222);

                IList<ProductoEN> hola3, hola4, hola5, hola6;
                hola3 = productoCEN.Filtronombre ("pene");
                hola4 = productoCEN.Filtrovalor (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco);
                hola5 = productoCEN.Filtroprecio (50, 2222);
                hola6 = productoCEN.Filtrotalla ("talla");

                #endregion
                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
