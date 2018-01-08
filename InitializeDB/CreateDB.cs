
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
                AdminCP adminCP = new AdminCP ();

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

                adminEN = adminCP.New_CP ("aaa", "aaa", "aaa", "aaa", "aaa", "aaa", "aaa");

                string idAdmin = adminEN.Email;

                string dstw = "Treinta años despues de derrotar al Imperio Gal�ctico, Han Solo y sus aliados enfrentan una nueva amenaza del malvado Kylo Ren y su ej�rcito de Stormtroopers.";
                string despider = "Tras los acontecimientos del Capit�n Am�rica: Guerra civil, Peter Parker, con la ayuda de su mentor Tony Stark, intenta equilibrar su vida como un estudiante normal de secundaria en Queens, Nueva York, con la lucha contra el crimen como su superh�roe alter ego Spider- El hombre como una nueva amenaza, el Buitre, emerge.";
                string djumanji = "Las tornas se vuelven cuando cuatro adolescentes son absorbidos por el mundo de Jumanji: enfrentado a rinocerontes, mambas negras y una interminable variedad de trampas y acertijos de la jungla. Para sobrevivir, jugar�n como personajes del juego.";
                string dc = "A pesar de la desconcertante prohibici�n de la generaci�n de m�sica de su familia, Miguel sue�a con convertirse en un m�sico consumado como su �dolo, Ernesto de la Cruz.";
                string dperfdesc = "La historia se desarrolla a lo largo de una noche, durante un eclipse lunar, en el hogar de Alfonso y Eva, una pareja profesional bien curada preocupada por su hija adolescente y por la monoton�a de sus vidas.";
                string ddandonota = "Despu�s de ganar los campeonatos del mundo, los Bellas se dividen y descubren que no hay perspectivas de trabajo para hacer m�sica con la boca. Pero cuando tengan la oportunidad de reunirse para una gira USO en el extranjero, este grupo de genios incre�bles se unir�n para hacer algo de m�sica, y algunas decisiones cuestionables, una �ltima vez.";
                string dferdi = "Ferdinand, un peque�o toro, prefiere sentarse tranquilamente bajo un �rbol de corcho oliendo las flores, saltando, resoplando y golpe�ndose la cabeza con otros toros. A medida que Ferdinand crece grande y fuerte, su temperamento se mantiene suave, pero un d�a cinco hombres vienen a elegir el toro m�s grande, m�s r�pido y m�s rudo para las corridas de toros en Madrid y Fernando es elegido por error. Basado en el cl�sico libro infantil de 1936 de Munro Leaf.";
                string dww = "La historia de cuatro personajes cuyas vidas se entrelazan en medio del ajetreo y el bullicio del parque de atracciones Coney Island en la d�cada de 1950: Ginny, una ex actriz emocionalmente vol�til que ahora trabaja como camarera en una casa de almejas; Humpty, el operador operador de carrusel de Ginny; Mickey, un joven y guapo socorrista que sue�a con convertirse en dramaturgo; y Carolina, la hija de Humpty que estuvo lejos, que ahora se esconde de los mafiosos en el departamento de su padre.";
                string dit = "En una peque�a ciudad de Maine, siete ni�os conocidos como The Losers Club se enfrentan cara a cara con problemas de la vida, matones y un monstruo que toma la forma de un payaso llamado Pennywise.";
                string dwoman = "Una princesa de Amazon llega al mundo del Hombre para convertirse en la m�s grande de los superh�roes femeninos.";
                string dhday = "Una estudiante universitaria revive el d�a de su asesinato una y otra vez mientras trata de descubrir la identidad de su asesino. ";
                string dgru = "Gru y su esposa Lucy deben evitar que la ex estrella infantil de los 80, Balthazar Bratt, alcance la dominaci�n mundial.";
                string dhrr1 = "Harry, Ron y Hermione se alejan de su �ltimo a�o en Hogwarts para encontrar y destruir los Horcruxes restantes, poniendo fin a la apuesta de Voldemort por la inmortalidad. Pero con el amado Dumbledore de Harry muerto y los inescrupulosos Mort�fagos de Voldemort suelto, el mundo es m�s peligroso que nunca.";
                string dhrr2 = "Harry, Ron y Hermione contin�an su b�squeda para vencer al malvado Voldemort de una vez por todas. Justo cuando las cosas comienzan a parecer desesperanzadas para los j�venes magos, Harry descubre un tr�o de objetos m�gicos que le otorgan poderes para competir con las formidables habilidades de Voldemort.";
                string dblad = "Treinta a�os despu�s de los acontecimientos de la primera pel�cula, un nuevo corredor de cuchillas, el oficial K de LAPD, descubre un secreto oculto desde hace mucho tiempo que tiene el potencial de sumergir lo que queda de la sociedad en el caos. El descubrimiento de K lo lleva en una b�squeda para encontrar a Rick Deckard, un ex corredor de armas de LAPD que ha estado desaparecido durante 30 a�os.";
                string dbay = "El salvavidas devoto, Mitch Buchannon, golpea la cabeza con un nuevo recluta temerario. Juntos, descubren un complot criminal local que amenaza el futuro de la Bah�a.";


                string dluci = "Lucifer, el �ngel ca�do original, est� aburrido e infeliz en el infierno y decide retirarse a Los �ngeles y abrir una discoteca de lujo. Despu�s de que se produce un asesinato fuera de su club, conoce a una intrigante detective de homicidios llamada Chloe, y se asocia con ella para resolver casos.";

                string dvegas = "Situado en el vuelo de la noche del viernes desde LAX a Las Vegas y el vuelo de regreso el domingo, un grupo de marginados que intentan encontrar su lugar en el mundo, todos comparten el mismo objetivo: volver a ser un ganador en el casino de la vida. ";
                string dhappy = "Nick Sax es un ex policia borracho y corrupto que se convierte en un sicario, y que esta a la deriva en un mundo de asesinatos casuales, sexo desalmado y traicion. Despues de que un trabajo falla, su vida ebria es cambiada para siempre por un caballo alado peque�o, implacablemente positivo e imaginario llamado Happy.";
                string ddam = "Seth Davenport parece ser un peque�o predicador de la ciudad de Iowa, pero tiene ambiciones de comenzar una insurreccion en toda regla contra el status quo. Pero el no sabe que un magnate industrial ha contratado a un rompehuelgas profesional mortal llamado Creeley Turner para detener esa insurreccion por cualquier medio necesario. Y desconocido para quienes los rodean, estos dos hombres comparten un pasado sangriento secreto.";
                string dvh = "Vanessa Helsing, pariente lejana del famoso cazador de vampiros Abraham Van Helsing, es resucitada solo para descubrir que los vampiros se han adue�ado del mundo.";
                string drw = "Despues de descubrir que sus padres son super villanos disfrazados, un grupo de adolescentes se junta para huir de sus hogares a fin de expiar las acciones de sus padres y descubrir los secretos de sus origenes.";
                string dgot = "Siete familias nobles luchan por el control de la tierra mitica de Poniente. La friccion entre las casas conduce a una guerra a gran escala. Todo mientras un mal muy antiguo despierta en el extremo norte. En medio de la guerra, una orden militar descuidada de inadaptados, la Guardia de la Noche, es todo lo que se interpone entre los reinos de los hombres y los helados horrores mas alla.";
                string dbgbg = "�Que sucede cuando los compa�eros de cuarto hiperinteligentes Sheldon y Leonard conocen a Penny, una belleza de espiritu libre que se mueve en la casa de al lado, y se dan cuenta de que no saben casi nada sobre la vida fuera del laboratorio. Completan la tripulacion el fanatico Wolowitz, que piensa que es tan sexy como el, y Koothrappali, que no puede hablar en presencia de una mujer.";
                string dhimym = "El a�o es 2030. Ted Mosby transmite la historia de como conocio a su esposa a su hija e hijo. La historia comienza en el a�o 2005, cuando el entonces arquitecto Ted, de veintisiete a�os, se anima a querer casarse despues de sus mejores amigos de Wesleyan, el abogado Marshall Eriksen, que era su compa�ero de habitacion en ese momento y maestro de jardin de infantes. Lily Aldrin, se comprometio despues de nueve a�os de salir juntos.";
                string d13 = "Sigue al adolescente Clay Jensen, en su busqueda para descubrir la historia detras de su compa�era de clase y enamoramiento, Hannah, y su decision de poner fin a su vida.";
                string dst = "Cuando un ni�o desaparece, su madre, un jefe de policia y sus amigos deben enfrentar fuerzas terrorificas para recuperarlo.";
                string dRYM = "Una serie animada que sigue las haza�as de un super cientifico y su nieto no tan brillante. ";
                string dysh = "La vida temprana del ni�o genio Sheldon Cooper, mas tarde visto en The Big Bang Theory (2007).";
                string dbmir = "Una serie de antologic�a de television que muestra el lado oscuro de la vida y la tecnologia.";
                string dvik = "Vikingos sigue las aventuras de Ragnar Lothbrok, el mas grande heroe de su edad. La serie cuenta las sagas de la banda de hermanos vikingos de Ragnar y su familia, mientras se eleva para convertirse en rey de las tribus vikingas. Ademas de ser un valiente guerrero, Ragnar encarna las tradiciones nordicas de devocion a los dioses, segun la leyenda, el era un descendiente directo de Odin, el dios de la guerra y los guerreros.";
                string dmrr = "El Sr. Robot sigue a Elliot, un joven programador que trabaja de ingeniero de ciberseguridad de dia y un hacker vigilante por la noche. Elliot se encuentra en una encrucijada cuando el misterioso lider de un grupo clandestino de hackers lo recluta para destruir la corporacion a la que se le paga por proteger.";

                //string idUsuario = usuarioCEN.New_("usuario", "apellidos", "contrasenya", "correo", "direcccion", "pago", "imagen");
                //adminCEN.New_ ("usuario", "apellidos", "contrasenya", "correo", "direcccion", "pago", "imagen"));
                int idevento = eventoCEN.New_ ("Musical Rey León", 70, "Musical del Rey León", "reyleon.jpg", SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, 8, "El musical mas popular del momento, recuerda la experiencia disney a manos de esta gran experiencia.", "imagran", "Musical");
                int idevento2 = eventoCEN.New_ ("Entradas al parque de Harry Potter", 60, "Entrada del Parque Harry Potter", "HarryPotterParque.jpg", SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, 8, "Visita el parque de atracciones de Harry Potter, con todas la recreaciones y el mundo de los libros.", "imagran", "Parque");
                int idevento3 = eventoCEN.New_ ("Daniel Radcliffe visita la Ua", 5, "Visita guiada a la ua", "UA.jpg", SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.dos, 8, "Aprovecha la oportunidad de conocer a Daniel Radcliffe.", "imagran", "Estudios");
                int idevento4 = eventoCEN.New_ ("Estreno Star Wars L", 25, "Estreno Star Wars", "EstrenoStarWars.jpg", SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, 8, "Se el primero en ver la pelicula de Star Wars, que no te la cuenten.", "imagran", "Cine");
                int idevento5 = eventoCEN.New_ ("Sinfonía Harry Potter", 60, "Sinfonia Harry Potter", "sinharry.jpg", SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, 8, "Disfruta de todas las canciones de Harry Potter gracias a la film symphony orchestra.", "imagran", "Musica Orquesta");
                int idevento6 = eventoCEN.New_ ("Comic Con Madrid", 15, "Comic Con Madrid", "comic.jpg", SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, 8, "Despierta tu lado friki y visita la comic con de Madrid, donde podras ver todos tus animes, mangas y comics preferidos.", "imagran", "Evento");

                int idCarrito = carritoCEN.New_ (idUsuario, 0);
                int idCarrito2 = carritoCEN.New_ (idAdmin, 0);



                int idArticulo = articuloCEN.New_ ("articulo", 69, "descripcion", "imagen", SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, 999, "desclarga", "imagran");

                int idlineas_pedido = lineas_pedidoCEN.New_ (idCarrito, 3);


                int idoferta = ofertaCEN.New_ (idArticulo, new DateTime (1993, 12, 3), new DateTime (1993, 12, 3), 99);

                int idproducto = productoCEN.New_ ("FunkoPop Balrog", 40, "Figura Balrog", "Balrog.png", SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.tres, 80, "desclarga", "imagran", "Media");
                int idproducto2 = productoCEN.New_ ("Camiseta Legolas", 35, "Camiseta Legolas", "CamisetaLegolas.png", SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, 80, "desclarga", "imagran", "S,M,L,XL");
                int idproducto3 = productoCEN.New_ ("Casco Darth Vader", 68, "Casco Darth Vader", "CascoDarthVader.png", SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, 30, "desclarga", "imagran", "Media");
                int idproducto4 = productoCEN.New_ ("FunkoPop Frodo", 29, "FunkoPop Frodo", "FunkoPopFrodo.png", SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.dos, 100, "desclarga", "imagran", "Peque�a");
                int idproducto5 = productoCEN.New_ ("Figura Harley Quinn", 30, "Figura Harley Quinn", "HarleyQuinn.png", SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.tres, 80, "desclarga", "imagran", "Peque�a");
                int idproducto6 = productoCEN.New_ ("Llavero Morty", 8, "Excepcional llavero de Morty de la serie de Rick y Morty. Ideal para adornar estuches estudiantiles o para usar de llavero", "LlaveroMorty2.png", SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.dos, 80, "desclarga", "imagran", "Estándar");
                int idproducto7 = productoCEN.New_ ("Espada Laser Roja", 100, "Espada Laser", "EspadaLaserRoja.png", SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, 20, "desclarga", "imagran", "Estándar");
                int idproducto8 = productoCEN.New_ ("Risk Juego de Tronos", 39, "Juega en ambos mapas, participando en una guerra épica con un máximo de 7 jugadores. Advertencias: -Este juguete contiene piezas pequeñas. Riesgo de asfixia.Materiales Plástico:-Cartón-Papel-MetalEdad recomendada: Edad desde 18 hasta 99 años.", "RiskGoT.png", SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.tres, 80, "desclarga", "imagran", "Estándar");
                int idproducto9 = productoCEN.New_ ("Jersey Rick", 180, "Ricka y morty camiseta Opinión No Significa Nada La Camiseta rick y morty divertido camisetas ropa camisetas hombre de manga corta t-shirt", "JerseyRick.png", SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, 20, "desclarga", "imagran", "media");
                int idproducto10 = productoCEN.New_ ("Sudadera Harley Quinn", 35, "Sudadera Harley Quinn", "SudaderaHarleyQuinn.png", SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.tres, 80, "desclarga", "imagran", "S,M,L,XL");
                int idproducto11 = productoCEN.New_ ("Sombrero Ace", 24, "Sombrero Ace", "SombreroAce.png", SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, 15, "desclarga", "imagran", "Estándar");
                int idproducto12 = productoCEN.New_ ("Varita Sauco", 200, "Varita Sauco", "VaritaSauco.png", SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, 20, "desclarga", "imagran", "Estándar");

                int idlista = listaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.Estado_videoEnum.visto, idUsuario);
                int idlista2 = listaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.Estado_videoEnum.siguiendo, idUsuario);
                int idlista3 = listaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.Estado_videoEnum.favorito, idUsuario);

                int idcomentario = comentarioCEN.New_ ("comentario", "autor", new DateTime (1993, 12, 3));







                int idpelicula = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Star Wars:Episodio VII", "i5.jpg", "desclarga", dstw, "Ciencia ficcion", 2015, "estarwa.jpg", "https://www.youtube.com/embed/sGbxmsDFVnE");
                int idpelicula2 = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "Jumanji", "i2.jpg", "desclarga", djumanji, "Ciencia ficcion", 2017, "jumanji.jpg", "https://www.youtube.com/embed/leIrosWRbYQ");
                int idpelicula3 = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "COCO", "i7.jpg", "desclarga", dc, "Animacion", 2017, "coco.jpg", "https://www.youtube.com/embed/-hTHtv1hmqc");
                int idpelicula4 = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "Perfectos desconocidos", "i3.jpg", "desclarga", dperfdesc, "Tragicomedia", 2017, "perfectdesc.jpg", "https://www.youtube.com/embed/UqkXCILU_oE");
                int idpelicula5 = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Dando la nota 3", "i4.jpg", "desclarga", ddandonota, "Comedia", 2017, "dandolanota.jpg", "https://www.youtube.com/embed/1FgDZ2adeow");
                int idpelicula6 = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "Ferdinand", "ferdi.jpg", "desclarga", dferdi, "Animacion", 2017, "ferdinand.jpg", "https://www.youtube.com/embed/9XcmEC8o98U");
                int idpelicula7 = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "Wonder Wheel", "i8.jpg", "desclarga", dww, "Dramatico", 2017, "wonderwheel.jpg", "https://www.youtube.com/embed/7Y7VfCEb3Kg");
                int idpelicula8 = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "Spider-Man: Homecoming", "spider.jpg", "desclarga", despider, "Ciencia Ficcion", 2017, "man.jpg", "https://www.youtube.com/embed/Xhvucc6KrVw");
                int idpelicula9 = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Wonder Woman", "ww.jpg", "desclarga", dwoman, "Ciencia Ficcion", 2017, "woman.jpg", "https://www.youtube.com/embed/gOfmwQijKFg");
                int idpelicula10 = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "it", "it.jpg", "desclarga", dit, "Terror", 2017, "ittt.jpg", "https://www.youtube.com/embed/_oBZ_zTz0Nw");
                int idpelicula11 = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "Feliz dia de tu muerte", "hday.jpg", "desclarga", dhday, "Terror", 2017, "muerte.jpg", "https://www.youtube.com/embed/QzMX83gWxxA");
                int idpelicula12 = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.tres, "Despicable Me 3", "gru.jpg", "desclarga", dgru, "Animacion", 2017, "gru3.jpg", "https://www.youtube.com/embed/6DBi41reeF0");
                int idpelicula13 = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Harry Potter y las reliquias de la muerte: Parte 1", "hrr1.jpg", "desclarga", dhrr1, "Fantasia", 2010, "harry1.jpg", "https://www.youtube.com/embed/f3O0odK1VIQ");
                int idpelicula14 = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Harry Potter y las reliquias de la muerte: Parte 2", "hrr2.jpg", "desclarga", dhrr2, " Fantasia", 2011, "harry2.jpg", "https://www.youtube.com/embed/HguSMW8XveQ");
                int idpelicula15 = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "Blade Runner 2049 ", "blad.jpg", "desclarga", dblad, "Ciencia Ficcion", 2017, "bladerun.jpg", "https://www.youtube.com/embed/PkqHVGFAhbU");
                int idpelicula16 = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "Baywatch ", "bay.jpg", "desclarga", dbay, "Comedia", 2017, "playa.jpg", "https://www.youtube.com/embed/p4ijrL4zscE");

                int idvideo = videoCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "nombre", "hola", "desclarga", "descripcion", "genero", 1993, "imagrande");

                int idserie = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.tres, "La To Vegas", "s1.jpg", "desclarga", dvegas, "Comedia", 2017, "latovegas.jpg", 2000, false);
                int idserie2 = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "Happy", "s2.jpg", "desclarga", dhappy, "Comedia", 2017, "happy.jpg", 2000, false);
                int idserie3 = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Lucifer", "luci.jpg", "desclarga", dluci, "Fantastico", 2016, "lucifer.jpg", 2000, false);
                int idserie4 = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "Damnation", "s4.jpg", "desclarga", ddam, "Drama", 2017, "damnation.jpg", 2000, false);
                int idserie5 = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "Van Helsing", "vh.jpg", "desclarga", dvh, "Accion", 2016, "vanhel.jpg", 2000, false);
                int idserie6 = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Runaways", "rwa.jpg", "desclarga", drw, "Ciencia Ficcion", 2017, "runaways.jpg", 2000, false);
                int idserie7 = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "The Big Bang", "bigbang.jpg", "desclarga", dbgbg, "Comedia", 2007, "thebigbang.jpg", 2000, false);
                int idserie8 = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Game of Thrones", "got.jpg", "desclarga", dgot, "Fantastico", 2011, "game.jpg", 2000, false);
                int idserie9 = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "HowIMeetYourMother", "himym.jpg", "desclarga", dhimym, "Comedia", 2005, "comoconoci.jpg", 2014, true);
                int idserie10 = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "13 Reason Why", "reason.jpg", "desclarga", d13, "Drama", 2017, "13reasonwhy.jpg", 2017, true);
                int idserie11 = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Stranger Things", "st.jpg", "desclarga", dst, "Ciencia Ficcion", 2016, "stranger.jpg", 2017, true);
                int idserie12 = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Rick y Morty", "RYM.jpg", "desclarga", dRYM, "Animacion", 2013, "rick.jpg", 2000, false);
                int idserie13 = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Young Sheldon", "ysh.jpg", "desclarga", dysh, "Comedia", 2017, "young.jpg", 2000, false);
                int idserie14 = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Black Mirror", "bmir.jpg", "desclarga", dbmir, "Ciencia Ficcion", 2011, "black.jpg", 2000, false);
                int idserie15 = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Vikings", "vik.jpg", "desclarga", dvik, "Accion", 2013, "vikings.jpg", 2000, false);
                int idserie16 = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Mr.Robot", "mrr.jpg", "desclarga", dmrr, "Suspense", 2015, "mr.rob.jpg", 2000, false);



                // idtemporada01 -> serie 0 temporada 1; idtemporada11 -> serie 1 temporada 1 .....

                int idtemporada01 = temporadaCEN.New_(idserie, "Temporada 1");
                int idtemporada02 = temporadaCEN.New_(idserie2, "Temporada 1");
                int idtemporada03 = temporadaCEN.New_(idserie3, "Temporada 1");
                int idtemporada04 = temporadaCEN.New_(idserie3, "Temporada 2");
                int idtemporada05 = temporadaCEN.New_(idserie3, "Temporada 3");
                int idtemporada06 = temporadaCEN.New_(idserie4, "Temporada 1");
                int idtemporada07 = temporadaCEN.New_(idserie5, "Temporada 1");
                int idtemporada08 = temporadaCEN.New_(idserie5, "Temporada 2");
                int idtemporada09 = temporadaCEN.New_(idserie6, "Temporada 1");
                int idtemporada10 = temporadaCEN.New_(idserie7, "Temporada 1");
                int idtemporada11 = temporadaCEN.New_(idserie7, "Temporada 2");
                int idtemporada12 = temporadaCEN.New_(idserie7, "Temporada 3");
                int idtemporada13 = temporadaCEN.New_(idserie7, "Temporada 4");
                int idtemporada14 = temporadaCEN.New_(idserie7, "Temporada 5");
                int idtemporada15 = temporadaCEN.New_(idserie7, "Temporada 6");
                int idtemporada16 = temporadaCEN.New_(idserie8, "Temporada 1");
                int idtemporada17 = temporadaCEN.New_(idserie8, "Temporada 2");
                int idtemporada18 = temporadaCEN.New_(idserie8, "Temporada 3");
                int idtemporada19 = temporadaCEN.New_(idserie8, "Temporada 4");
                int idtemporada20 = temporadaCEN.New_(idserie8, "Temporada 5");
                int idtemporada21 = temporadaCEN.New_(idserie8, "Temporada 6");
                int idtemporada22 = temporadaCEN.New_(idserie9, "Temporada 1");
                int idtemporada23 = temporadaCEN.New_(idserie9, "Temporada 2");
                int idtemporada24 = temporadaCEN.New_(idserie9, "Temporada 3");
                int idtemporada25 = temporadaCEN.New_(idserie9, "Temporada 4");
                int idtemporada26 = temporadaCEN.New_(idserie9, "Temporada 5");
                int idtemporada27 = temporadaCEN.New_(idserie9, "Temporada 6");
                int idtemporada28 = temporadaCEN.New_(idserie10, "Temporada 1");
                int idtemporada29 = temporadaCEN.New_(idserie11, "Temporada 1");
                int idtemporada30 = temporadaCEN.New_(idserie11, "Temporada 2");
                int idtemporada31 = temporadaCEN.New_(idserie12, "Temporada 1");
                int idtemporada32 = temporadaCEN.New_(idserie12, "Temporada 2");
                int idtemporada33 = temporadaCEN.New_(idserie12, "Temporada 3");
                int idtemporada34 = temporadaCEN.New_(idserie13, "Temporada 1");
                int idtemporada35 = temporadaCEN.New_(idserie14, "Temporada 1");
                int idtemporada36 = temporadaCEN.New_(idserie14, "Temporada 2");
                int idtemporada37 = temporadaCEN.New_(idserie14, "Temporada 3");
                int idtemporada38 = temporadaCEN.New_(idserie14, "Temporada 4");
                int idtemporada39 = temporadaCEN.New_(idserie15, "Temporada 1");
                int idtemporada40 = temporadaCEN.New_(idserie15, "Temporada 2");
                int idtemporada41 = temporadaCEN.New_(idserie15, "Temporada 3");
                int idtemporada42 = temporadaCEN.New_(idserie15, "Temporada 4");
                int idtemporada43 = temporadaCEN.New_(idserie15, "Temporada 5");
                int idtemporada44 = temporadaCEN.New_(idserie16, "Temporada 1");
                int idtemporada45 = temporadaCEN.New_(idserie16, "Temporada 2");
                int idtemporada46 = temporadaCEN.New_(idserie16, "Temporada 3");
               

                string cveg1 = "El estreno de la serie presenta a la tripulación de la aerolínea de bajo presupuesto y sus pasajeros excéntricos que, cada fin de semana, toman el vuelo de ida y vuelta desde Los Ángeles a Las Vegas con un objetivo en mente: volver a ser un ganador. No será fácil, pero este improbable grupo de malhechores y soñadores eventualmente pasará de ser extraños en un avión a ser de apoyo, aunque no convencionales, en familia, bueno, al menos de viernes a domingo.";
                string ch1 = "Un sicario debe asociarse con un caballo imaginario de alas azules para rescatar a un niño desaparecido";
                string ch2 = "Sax se estrella en un juego de póquer de alto riesgo para ganar armas y dinero en efectivo para escapar de Nueva York mientras Happy intenta convencerlo de que es un padre. La ex esposa Amanda y su ex amante Merry se unen para rescatar a Hailey.";
                string ch3 = "Sax recorre un oscuro pasado mientras él y Happy siguen a su hija. Merry y Amanda hacen un descubrimiento escalofriante. Very Bad Santa coacciona la información de Hailey sobre su padre.";
                string ch4 = "Sax y Happy siguen sus fortunas a Chinatown. La hermana de Blue aparece buscando venganza por el asesinato de sus hijos. La búsqueda de Merry la acerca cada vez más a Very Bad Santa.";
                string cl1 = "Al salir del infierno, Lucifer Morningstar se retira a Los Ángeles para una vida más emocionante. Cuando el asesinato de un amigo lo conecta con la detective del LAPD Chloe Decker, Lucifer se siente intrigado con la idea de castigar a los criminales, enviando al diablo a una lucha entre el bien y el mal.";
                string cl2 = "Cuando el hijo de una estrella de cine es asesinado después de ser perseguido por los paparazzi, Chloe echa un vistazo al caso con un poco de ayuda de Lucifer. Mientras tanto, Maze y Amenadiel continúan alentando a Lucifer a volver al infierno.";
                string cl3 = "Cuando un futuro quarterback súper estrella de 22 años se despierta y encuentra a una niña muerta flotando en su piscina, recurre a su amigo, Lucifer, en busca de ayuda. Lucifer recluta a Chloe para investigar el caso, lo que lleva al mundo de los grandes deportes de dinero y las personas que literalmente matan para ser el número uno.";
                string cl4 = "En un esfuerzo por superar su enamoramiento con Chloe, Lucifer decide que él debe seducirla. Mientras tanto, los dos se juntan en una caja de niña desaparecida y Amenadiel confronta a Maze sobre sus preocupaciones sobre Lucifer.";
                string cl5 = "Lucifer se distrae con el escape de su madre del infierno, mientras él y Chloe investigan el asesinato de una actriz suplente. Mientras tanto, la fe de Chloe en Lucifer es probada por el nuevo médico forense, Ella. Además, Amenadiel espera controlar el lado salvaje de Lucifer, ya que ambos lidian con la ausencia de Maze.";
                string cl6 = "Cuando la madre de Lucifer, Charlotte, aparece en la escena de un grizzly asesinato que suplica inocencia, Lucifer duda de creer en su historia. No queriendo dejarla sola, le ordena a Maze que cuide de ella, y no que la torture, permitiéndole investigar el caso con Chloe.";
                string cl7 = "Lucifer y Chloe investigan un asesinato horrible después de un video de las superficies del crimen en las redes sociales. Cuando aparece un segundo video, se dan cuenta de que tienen un asesino en serie en sus manos. Mientras tanto, la madre de Lucifer regresa como Charlotte Richards. Además, Amenadiel, luchando con su pérdida de poder, tiene una cita con Linda.";
                string cl8 = "Después de que los cuerpos de dos jóvenes trasplantes de L.A. se encuentran envenenados, Chloe y Lucifer buscan al asesino. Cuando Maze convence a Chloe para que tome unas copas, lo que el detective percibe como un acto de amistad, pero en realidad es parte de una apuesta entre Maze y Lucifer, los dos toman una decisión impactante.";
                string cl9 = "Después de que un confundido Lucifer se despierta en el medio del desierto con sus alas hacia atrás, recluta la ayuda de Chloe para ayudar a descubrir qué le sucedió y por qué. Al hacer su propia investigación, se encuentran con una escena del crimen que podría estar relacionada con el secuestro de Lucifer. Cuando el Departamento de Policía de Lancaster se involucra, el Teniente recién llegado Marcus Pierce no logra causar una gran impresión en todos con su actitud severa. La investigación sale mal cuando Lucifer se encuentra en otra situación comprometedora y se revela algo mucho más oscuro.";
                string cl10 = "Después de que Lucifer retira sus alas una vez más, Linda se preocupa porque él está demasiado enfocado en rastrear al Sinnerman y descuidar su propio bienestar. Las tensiones continúan aumentando entre Lucifer y Chloe, pero se dan cuenta de que deben poner sus diferencias de lado para resolver un caso en el que Lucifer toma un interés repentino. Sin embargo, una vez que se revela el pasado del Detective Pierce, todos se dan cuenta de que el Sinnerman es mucho más peligroso de lo que pensaban.";
                string cdam1 = "When a farmer's strike led by a local preacher escalates, a man from his past is sent to restore order. ";
                string cdam2 = "Seth y los granjeros rechazan al grupo de vigilantes de la Legión Negra; Creeley intenta aprender más sobre la nueva vida de su hermano.";
                string cdam3 = "Cuando las fincas locales enfrentan ejecuciones hipotecarias, Seth y Amelia intentan recuperarlas; Creeley y Bessie se enfrentan a la Legión Negra.";
                string cdam4 = "Las negociaciones comienzan entre los agricultores y el banco. Pero las cosas se vuelven sangrientas cuando Creeley divide a los granjeros.";
                string cvan1 = "Es Vanessa Helsing vs vampiros en la Seattle post-apocalíptica.";
                string cvan2 = "En los días previos a The Rising, Vanessa es atacada y dejada por un intruso. Cuando Doc descubre anomalías en los análisis de sangre de Vanessa, Axel y los infantes de marina vienen a recuperar el cuerpo, solo para quedar abandonados en el hospital cuando se desata el infierno fuera del edificio.";
                string cvan3 = "La fuente de energía del hospital está dañada, poniendo en peligro las luces UV protectoras. Vanessa y Axel se dirigen a Seattle para recoger partes, dejando a los demás para luchar contra los vampiros entre ellos.";
                string cvan4 = "Vanessa y Mohamad buscan a Dylan mientras la ciudadela de Dmitri se derrumba a su alrededor; Flesh adquiere un aliado inesperado en uno de los Combatientes de la Resistencia; Taka choca con Vampire Elite.";
                string cvan5 = "Vanessa lucha para sacar a su hija de la ciudadela; Dmitri y Antanasia traman un plan para detener a Vanessa; Mohamad arriesga su vida para salvar a Vanessa y Dylan.";
                string cvan6 = "Vanessa toma una decisión horrible para salvar a su hija; Axel y un antiguo aliado luchan por sobrevivir en la naturaleza; un grupo de delincuentes juveniles se encuentran cara a cara con un vampiro sádico.";
                string crun1 = "Un grupo de seis adolescentes de Los Ángeles, fracturados por una trágica pérdida, se reúnen solo para descubrir que sus padres pueden estar ocultando un terrible secreto que pone patas arriba su mundo.";
                string crun2 = "Una nueva versión de 101, como se ve desde la perspectiva de los padres. Todos están nerviosos, pero después de esta noche, si todo sale según lo planeado, no tendrán que preocuparse por sus obligaciones nuevamente.";
                string crun3 = "Los niños se tambalean después de los eventos de anoche. Cuando comienza una investigación, descubren que sus padres pueden tener más cosas que esconder de lo que podrían haber imaginado.";
                string cbig1 = "Los brillantes compañeros físicos de física, Leonard y Sheldon, conocen a su nueva vecina, Penny, quien comienza a mostrarles que, por mucho que sepan sobre ciencia, saben muy poco sobre la vida real.";
                string cbig2 = "Leonard se ofrece como voluntario para firmar un paquete en un intento de causar una buena impresión en Penny, pero cuando él recluta a Sheldon para que lo ayude, su intento de caballería sale terriblemente mal.";
                string cbig3 = "Leonard le pide salir a una mujer después de enterarse de que Penny está saliendo con alguien.";
                string cbig4 = "La primera cita de Penny con Leonard sale mal; Penny encuentra que Sheldon es un confidente involuntario. ";
                string cbig5 = "Cuando Sheldon descubre que los tipos manipularon los datos de su expedición que recibió del Ártico, se va a Texas deshonrado. Esto hace que los chicos lo sigan, lo que amenaza la esperanza de Leonard de pasar un rato romántico con Penny y la amistad de los chicos con Sheldon.";
                string cbig6 = "Penny etiqueta en la primera cita de Sheldon; Wolowitz encuentra un nuevo uso para un brazo robótico.";
                string cbig7 = "Penny está preocupada por lo dañada que será su amistad con los muchachos después de acostarse con Raj mientras Sheldon se convierte en el líder del equipo de paintball.";
                string cbig8 = "Raj se enfrenta a su soledad cuando sus amigos salen a citas; mientras que en el espacio, Wolowitz se ve involucrado en una pelea entre Bernadette y su madre.";
                string cgot1 = "Ned Stark, Lord of Winterfell, descubre que su mentor, Jon Arryn, ha muerto y que el Rey Robert se dirige hacia el norte para ofrecer la posición de Ned Arryn como Mano del Rey. Al otro lado del Mar Estrecho en Pentos, Viserys Targaryen planea casarse con su hermana Daenerys al líder guerrero nómada Dothraki, Khal Drogo para forjar una alianza para tomar el trono.";
                string cgot2 = "Después de haber aceptado convertirse en la Mano del Rey, Ned deja Invernalia con sus hijas Sansa y Arya, mientras Catelyn se queda atrás en Invernalia. Jon Snow se dirige al norte para unirse a la hermandad de la Guardia Nocturna. Tyrion decide renunciar al viaje al sur con su familia, en lugar de unirse a Jon en la comitiva que se dirige al Muro. Viserys espera su momento con la esperanza de recuperar el trono, mientras que Daenerys centra su atención en aprender cómo complacer a su nuevo marido, Drogo.";
                string cgot3 = "Al llegar a Desembarco del Rey, Ned se sorprende al enterarse del despilfarro de la Corona por parte de sus nuevos asesores. En Castle Black, Jon Snow impresiona a Tyrion a expensas de reclutas más verdes. Sospechando que los Lannister tuvieron algo que ver en la caída de Bran, Catelyn sigue encubiertamente a su esposo a King's Landing, donde es interceptada por Petyr Baelish, un Littlefinger, un astuto aliado de toda la vida y propietario de un burdel. Cersei y Jaime reflexionan sobre las implicaciones de la recuperación de Bran; Arya estudia esgrima. En el camino a Vaes Dothrak, Daenerys se encuentra en desacuerdo con Viserys.";
                string cgot4 = "Mientras Robb Stark y su ejército del norte continúan la guerra contra los Lannisters, Tyrion llega a Desembarco del Rey para aconsejar a Joffrey y atemperar los excesos del joven rey. En la isla de Rocadragón, Stannis Baratheon trama una invasión para reclamar el trono de su difunto hermano, aliándose con el feroz Melisandre, una extraña sacerdotisa de un dios extraño. Al otro lado del mar, Daenerys, sus tres jóvenes dragones y los khalasar recorren los Red Waste en busca de aliados o agua. En el norte, Bran preside una raída Winterfell, mientras que más allá del Muro, Jon Snow y Night's Watch deben refugiarse con un salvaje retorcido.";
                string cgot5 = "Jon se encuentra con King-Beyond-the-Wall mientras sus Night Watch Brothers huyen hacia el sur. En Desembarco del Rey, Tyrion quiere una recompensa, Margaery muestra su naturaleza caritativa, Cersei organiza una cena y Littlefinger se ofrece para ayudar a Sansa. Al otro lado del Estrecho, Daenerys comienza su viaje hacia el oeste.";
                string cgot6 = "Tyrion da la bienvenida a un invitado sorpresa a Desembarco del Rey para la boda real, pero teme que haya venido a la Fortaleza Roja por algo más. Mientras tanto, Jon advierte a sus superiores escépticos de la Guardia Nocturna sobre un ataque inminente. Jaime lucha por recuperar su estado en casa. Arya encuentra una cara de su pasado, y Daario Naharis discute la estrategia con Daenerys en el viaje a la ciudad esclava Meereen.";
                string cgot7 = "Cersei y Jaime se ajustan a un mundo sin Tywin; Varys revela una conspiración a Tyrion; Daenerys enfrenta una nueva amenaza a su gobierno; Jon está atrapado entre dos reyes.";
                string cgot8 = "Jon Snow está muerto. Daenerys conoce a un hombre fuerte. Cersei ve a su hija otra vez.";
                string chow1 = "Es el año 2030 y un viejo Ted Mosby le está contando la historia a su hijo y a su hija sobre cómo conoció y finalmente se casará con su madre. Aquí es donde nos encontramos por primera vez con Ted, Lily, Marshall, Barney y Robin.";
                string chow2 = "En un intento desesperado por una segunda cita, Ted invita a Robin a una fiesta que está lanzando. Sin embargo, ella no aparece y sigue organizando fiestas con la esperanza de que finalmente llegue.";
                string chow3 = "Ted acepta dejar que Barney condimente su vida amorosa y termina en una loca aventura de volar a Filadelfia, encontrarse con la ley y visitar la Campana de la Libertad.";
                string chow4 = "La pandilla intenta ayudar a Marshall a superar a Lily, especialmente cuando encuentra un recibo de tarjeta de crédito que lleva a un hotel en la ciudad de Nueva York donde figuran algunos de sus cargos.";
                string chow5 = "Robin aparece con una cita y esto motiva a Ted a volver allí. También aprendemos algo importante sobre 'la Madre'.";
                string chow6 = "Ted y Stella se comprometen, pero Ted pronto descubre que no sabe nada de ella. Mientras tanto, Barney confiesa a Lily que está enamorado de Robin.";
                string chow7 = "Después de compartir un beso al principio del verano, Robin y Barney no están seguros de cómo manejar su atracción mutua. Después de algunas consideraciones le dicen a la pandilla que han decidido seguir siendo solo amigos, pero en secreto continúan viéndose entre ellos. Son capaces de salirse con la suya con su romance secreto durante un par de meses, pero se descubren cuando Ted, Marshall y Lily los visitan juntos. Le explican a la pandilla que están contentos con su relación casual, y no quisieron complicarla al definirla. Esto es inaceptable para Lily, quien los presiona para etiquetar su situación, y finalmente los encierra en la habitación de Robin para obligarlos a abordarlo. Mientras tanto, Ted está ansioso por sus primeros días como profesor en Columbia, lo que empeora cuando aparece en la clase equivocada y comienza su conferencia.";
                string chow8 = "Cuando Ted y Barney discuten sobre quién tiene dibs con una chica candente, Ted se da cuenta de que ella está allí con Cindy, una chica con la que anteriormente salió y que también es el compañero de habitación de su futura esposa. Mientras tanto, Robin tiene el corazón roto por Don, y Marshall no puede callar su deseo de formar una familia.";
                string crea1 = "Mientras la escuela llora la muerte de Hannah Baker, su amiga Clay recibe una caja de cintas con mensajes que grabó antes de suicidarse.";
                string crea2 = "Hannah hace amistad con Jessica y Alex, otros dos estudiantes nuevos. Justin no se presenta en la escuela, y la madre de Hannah encuentra algo preocupante.";
                string cstr1 = "En su camino a casa desde la casa de un amigo, el joven Will ve algo aterrador. Cerca de allí, un secreto siniestro acecha en las profundidades de un laboratorio gubernamental.";
                string cstr2 = "Lucas, Mike y Dustin intentan hablar con la chica que encontraron en el bosque. Hopper pregunta a una inquieta Joyce sobre una inquietante llamada telefónica.";
                string cstr3 = "Una Nancy cada vez más preocupada busca a Barb y descubre lo que Jonathan ha estado haciendo. Joyce está convencida de que Will intenta hablar con ella.";
                string cstr4 = "Mientras la ciudad se prepara para Halloween, un rival de alto puntaje sacude las cosas en el salón recreativo, y un escéptico Hopper inspecciona un campo de calabazas en descomposición.";
                string cstr5 = "Después de que Will ve algo terrible en la noche de trick-or-treat, Mike se pregunta si Eleven todavía está por ahí. Nancy lucha con la verdad sobre Barb.";
                string crick1 = "Rick se muda con la familia de su hija y se establece como una mala influencia para su nieto, Morty.";
                string crick2 = "Rick y Morty intentan deducir que el profesor de matemáticas de Morty le dio a Morty una 'A'. Mientras tanto, Rick le da a Jerry un dispositivo para entrenar a su perro, Snuffles.";
                string crick3 = "El día de Navidad, el amigo de Rick, Reuben, viene a su chequeo médico anual. Mientras tanto, Jerry se entera de que sus padres tienen un nuevo amigo.";
                string crick4 = "Rick y Morty intentan llegar al fondo de un misterio en este episodio de M. Night Shyamalan.";
                string crick5 = "Rick, Morty y Summer se meten en problemas cuando el tiempo se rompe por un ciclo de retroalimentación de la incertidumbre que divide la realidad en más de una imposibilidad igualmente posible. Mientras tanto, Beth y Jerry hacen todo lo posible para salvar a un ciervo golpeado por su vehículo.";
                string crick6 = "La familia Smith trata de arreglárselas sin Rick, lo cual es bastante doloroso por sí mismo sin tener en cuenta las sofocantes reglas puestas en práctica por la Federación. Mientras tanto, el pasado de Rick finalmente se revela cuando intenta salir de su prisión.";
                string crick7 = "Rick, Morty y Summer viajan a una dimensión post-apocalíptica y conocen a algunos enemigos peligrosos, al tiempo que evitan un desarrollo familiar reciente.";
                string crick8 = "Rick se convierte en un pepinillo, el mismo día que Beth lleva a los niños a terapia familiar.";
                string cyoung1 = "En el juego inaugural de la serie, Sheldon Cooper, de nueve años, es una mente única en generación que puede hacer matemáticas y ciencias avanzadas, pero aprende que no siempre es útil crecer en el este de Texas.";
                string cyoung2 = "Para apaciguar a su madre preocupada, Sheldon emplea las técnicas de un libro de autoayuda para tratar de hacer un amigo.";
                string cyoung3 = "Cuando George Sr. es llevado rápidamente a la sala de emergencias, Meemaw viene a cuidar a los niños, y los niños tienen la aventura de llegar solos al hospital.";
                string cblack1 = "Una parábola retorcida para la era de Twitter, The National Anthem analiza cómo la vida es mucho más difícil para los ricos y supuestamente poderosos ahora que la información se difunde tan rápido y la opinión pública es tan fuerte, poderosa y rápida de cambiar. Es un thriller político en el que el primer ministro enfrenta un gran dilema, y ​​eso es todo lo que puede revelarse por ahora ";
                string cblack2 = "Ambientado en una versión sarcástica de una realidad futura, 15 Million Merits es una sátira de espectáculos de entretenimiento y nuestra sed insaciable de distracción. En este mundo, todos están confinados a una vida de penosa fatiga física. La única forma de escapar de esta vida es ingresar al programa de talentos 'Hot Shot' y solo rezar para impresionar a los jueces.";
                string cblack3 = "Situado en una realidad alternativa donde todos tienen acceso a un sistema que registra todo lo que hacen, ven u oyen. Nunca se debe olvidar una cara, unas vacaciones o una noche de nuevo ... ¿pero siempre es algo bueno?";
                string cblack4 = "Martha y Ash son una joven pareja que se muda a una cabaña remota. El día después de la mudanza, Ash muere devolviendo la camioneta de alquiler. En el funeral, la amiga de Martha, Sarah, le cuenta acerca de un nuevo servicio que permite a las personas mantenerse en contacto con los fallecidos. Al usar todas sus comunicaciones en línea pasadas y perfiles de redes sociales, se puede crear un nuevo 'Ash'. Martha está disgustada con el concepto, pero luego, en un estado confuso y solitario, decide hablar con 'él' ";
                string cblack5 = "Oficinista inseguro Lacie vive en un mundo de pesadillas feliz, sonriente y obsesionado con el estado. Su vieja amiga Naomi es una de las élites de la sociedad, y Lacie puede haber encontrado una manera de unirse a ella ";
                string cblack6 = "El Capitán Robert Daly preside su equipo con sabiduría y coraje. Pero un nuevo recluta pronto descubrirá que nada en esta nave espacial es lo que parece.";
                string cvik1 = "En el siglo octavo de Escandinavia, Ragnar Lothbrok es un guerrero y un granjero que sueña con encontrar riquezas al contradecir la tradición de incursionar en el este. Ragnar ha estado trabajando en secreto en un proyecto que pondrá el mundo Viking en su cabeza. Pero primero Ragnar debe convencer al líder de su comunidad, el poderoso Earl Haraldson, que no está muy feliz de compartir el renombre que este viaje podría traer a Ragnar si es exitoso.";
                string cvik2 = "El escenario está listo para el primer viaje al oeste de Ragnar Lothbrok, ya que reúne a un equipo dispuesto a arriesgar sus vidas para viajar a lo desconocido. La paranoia de Earl Haraldson alcanza nuevas alturas, ya que es evidente que la confianza es difícil de conseguir en esta era oscura.";
                string cvik3 = "La batalla comienza entre Ragnar y las fuerzas del Rey Horik contra Jarl Borg. Borg se une a Rollo, y este enfrentamiento vikingo enfrenta al hermano contra el hermano. Solo puede haber un vencedor. Mientras tanto, la Princesa Aslaug hace su camino hacia Kattegat y trae consigo una sorpresa que deja a Ragnar en una difícil situación.";
                string cvik4 = "Las flotas de Ragnar y Lagertha parten de Kattegat una vez más hacia Wessex, pero esta vez traen colonos. El rey Ecbert recibe a los vikingos y propone un trato. A pesar de las dudas de algunos de los otros líderes, Ragnar lleva sus fuerzas a la batalla una vez más, pero esta vez como aliados de Wessex.";
                string cvik5 = "La entrada a Valhalla elude a Ragnar, pero mientras yace en su lecho de enfermo en Kattegat, los acontecimientos se desarrollan fuera de su control. Bjorn ordena el arresto de Floki por el asesinato de Athelstan mientras está en París, Rollo traiciona al último de sus seguidores vikingos para fortalecer su posición en la corte francesa. En Hedeby, Kalf anuncia el condado conjunto con Lagertha, pero ¿está el poder compartiendo la verdadera intención de Kalf y está Lagertha realmente dispuesto a compartir lo que una vez fue suyo?";
                string cvik6 = "Las tensiones se acumulan entre los hijos de Ragnar Lothbrok mientras los vikingos continúan amenazando el corazón de Inglaterra.";
                string cvik7 = "Mientras el ejército se mueve para tomar York, con el rey Aethelwulf y su familia aún escondidos, Heahmund, el obispo guerrero, debe reunir a los sajones para defender el reino.";
                string cmr1 = "Elliot, un ingeniero de seguridad cibernética de día y hacker vigilante por la noche, es reclutado por un misterioso grupo clandestino para destruir la empresa que le pagaron para proteger. Elliot debe decidir qué tan lejos irá para exponer las fuerzas que él cree que están corriendo (y arruinando) al mundo.";
                string cmr2 = "Elliot se debate entre aceptar una oferta de trabajo de Evil Corp y unirse al grupo de hackers de la sociedad. Al mismo tiempo, Elliot necesita tomar una decisión que pueda dañar a las personas que le rodean.";
                string cmr3 = "Un mes después y omfg, cinco / nueve ha cambiado el mundo; Elliot está en reclusión; Angela encuentra felicidad en Evil Corp .; fsociety entrega una carga maliciosa; ¿TANGO CAÍDO?";
                string cmr4 = "Elliot se da cuenta de su misión y necesita ayuda de Angela; Darlene se preocupa por que salgan limpios.";


                int idcapitulo = capituloCEN.New_ (idtemporada01, "Piloto", new DateTime (1993, 12, 3), cveg1, "cap1vegas.jpg", "https://www.youtube.com/embed/p4ijrL4zscE");

                int idcapitulo2 = capituloCEN.New_ (idtemporada02, "1-Saint Nick", new DateTime (1993, 12, 3), ch1, "happy1.jpg", "https://www.youtube.com/embed/t7OYkSgmM-w");
                int idcapitulo3 = capituloCEN.New_ (idtemporada02, "2-What Smiles Are For", new DateTime (1993, 12, 3), ch2, "happy2.jpg", "https://www.youtube.com/embed/t7OYkSgmM-w");
                int idcapitulo4 = capituloCEN.New_ (idtemporada02, "3-When Christmas Was Christmas", new DateTime (1993, 12, 3), ch3, "happy3.jpg", "https://www.youtube.com/embed/t7OYkSgmM-w");
                int idcapitulo5 = capituloCEN.New_ (idtemporada02, "4-Year of the Horse", new DateTime (1993, 12, 3), ch4, "happy4.jpg", "https://www.youtube.com/embed/t7OYkSgmM-w");

                int idcapitulo6 = capituloCEN.New_ (idtemporada03, "1-Piloto", new DateTime (1993, 12, 3), cl1, "luci1.jpg", "https://www.youtube.com/embed/K2kyWOMsy2Q");

                int idcapitulo7 = capituloCEN.New_(idtemporada03, "2-Lucifer, Stay. Good Devil.", new DateTime(1993, 12, 3), cl2, "luci2.jpg", "https://www.youtube.com/embed/K2kyWOMsy2Q");
                int idcapitulo8 = capituloCEN.New_(idtemporada03, "3-The Would-Be Prince of Darkness", new DateTime(1993, 12, 3), cl3, "luci3.jpg", "https://www.youtube.com/embed/K2kyWOMsy2Q");
                int idcapitulo9 = capituloCEN.New_(idtemporada03, "4-Lucifer, Stay. Good Devil.", new DateTime(1993, 12, 3), cl4, "luci2.jpg", "https://www.youtube.com/embed/K2kyWOMsy2Q");
                int idcapitulo10 = capituloCEN.New_(idtemporada04, "1-Everything's Coming Up Lucifer.", new DateTime(1993, 12, 3), cl5, "luci5.jpg", "https://www.youtube.com/embed/K2kyWOMsy2Q");
                int idcapitulo11 = capituloCEN.New_(idtemporada04, "2-Liar, Liar, Slutty Dress on Fire.", new DateTime(1993, 12, 3), cl6, "luci6.jpg", "https://www.youtube.com/embed/K2kyWOMsy2Q");
                int idcapitulo12 = capituloCEN.New_(idtemporada04, "3-Sin-Eater", new DateTime(1993, 12, 3), cl7, "luci7.jpg", "https://www.youtube.com/embed/K2kyWOMsy2Q");
                int idcapitulo13 = capituloCEN.New_(idtemporada04, "4-Lady Parts", new DateTime(1993, 12, 3), cl8, "luci8.jpg", "https://www.youtube.com/embed/K2kyWOMsy2Q");
                int idcapitulo14 = capituloCEN.New_(idtemporada05, "1-They're Back Again, Aren't They?", new DateTime(1993, 12, 3), cl9, "luci9.jpg", "https://www.youtube.com/embed/K2kyWOMsy2Q");
                int idcapitulo15 = capituloCEN.New_(idtemporada05, "2-The One with the Baby Carrot", new DateTime(1993, 12, 3), cl10, "luci10.jpg", "https://www.youtube.com/embed/K2kyWOMsy2Q");

                int idcapitulo16 = capituloCEN.New_(idtemporada06, "1-Sam Riley's Body", new DateTime(1993, 12, 3), cdam1, "dam1.jpg", "https://www.youtube.com/embed/n7yW7h0YkPI");
                int idcapitulo17 = capituloCEN.New_(idtemporada06, "2-Which Side Are You On", new DateTime(1993, 12, 3), cdam2, "dam2.jpg", "https://www.youtube.com/embed/n7yW7h0YkPI");
                int idcapitulo18 = capituloCEN.New_(idtemporada06, "3-One Penny", new DateTime(1993, 12, 3), cdam3, "dam3.jpg", "https://www.youtube.com/embed/n7yW7h0YkPI");
                int idcapitulo19 = capituloCEN.New_(idtemporada06, "4-The Emperor of Ice Cream", new DateTime(1993, 12, 3), cdam4, "dam4.jpg", "https://www.youtube.com/embed/n7yW7h0YkPI");

                int idcapitulo20 = capituloCEN.New_(idtemporada07, "1-Help Me", new DateTime(1993, 12, 3), cvan1, "van1.jpg", "https://www.youtube.com/embed/Jtic6uu8P5Q");
                int idcapitulo21 = capituloCEN.New_(idtemporada07, "2-Seen You", new DateTime(1993, 12, 3), cvan2, "van2.jpg", "https://www.youtube.com/embed/Jtic6uu8P5Q");
                int idcapitulo22 = capituloCEN.New_(idtemporada07, "3-Stay Inside", new DateTime(1993, 12, 3), cvan3, "van3.jpg", "https://www.youtube.com/embed/Jtic6uu8P5Q");
                int idcapitulo23 = capituloCEN.New_(idtemporada08, "1-Began Again", new DateTime(1993, 12, 3), cvan4, "van4.jpg", "https://www.youtube.com/embed/Jtic6uu8P5Q");
                int idcapitulo24 = capituloCEN.New_(idtemporada08, "2-In Redemption", new DateTime(1993, 12, 3), cvan5, "van5.jpg", "https://www.youtube.com/embed/Jtic6uu8P5Q");
                int idcapitulo25 = capituloCEN.New_(idtemporada08, "3-Love Bites", new DateTime(1993, 12, 3), cvan6, "van6.jpg", "https://www.youtube.com/embed/Jtic6uu8P5Q");

                int idcapitulo26 = capituloCEN.New_(idtemporada09, "1-Reunion", new DateTime(1993, 12, 3), crun1, "run1.jpg", "https://www.youtube.com/embed/pLzQaMbTg7Q");
                int idcapitulo27 = capituloCEN.New_(idtemporada09, "2-Rewind", new DateTime(1993, 12, 3), crun2, "run2.jpg", "https://www.youtube.com/embed/pLzQaMbTg7Q");
                int idcapitulo28 = capituloCEN.New_(idtemporada09, "3-Rewind", new DateTime(1993, 12, 3), crun3, "run3.jpg", "https://www.youtube.com/embed/pLzQaMbTg7Q");

                int idcapitulo29 = capituloCEN.New_(idtemporada10, "Pilot", new DateTime(1993, 12, 3), cbig1, "big1.jpg", "https://www.youtube.com/embed/_uQXxvZ3afQ");
                int idcapitulo30 = capituloCEN.New_(idtemporada10, "2-The Big Bran Hypothesis", new DateTime(1993, 12, 3), cbig2, "big2.jpg", "https://www.youtube.com/embed/_uQXxvZ3afQ");
                int idcapitulo31 = capituloCEN.New_(idtemporada10, "3-The Fuzzy Boots Corollary", new DateTime(1993, 12, 3), cbig3, "big3.jpg", "https://www.youtube.com/embed/_uQXxvZ3afQ");
                int idcapitulo32 = capituloCEN.New_(idtemporada11, "1-The Bad Fish Paradigm", new DateTime(1993, 12, 3), cbig4, "big4.jpg", "https://www.youtube.com/embed/_uQXxvZ3afQ");
                int idcapitulo33 = capituloCEN.New_(idtemporada12, "1-The Electric Can Opener Fluctuation", new DateTime(1993, 12, 3), cbig5, "big5.jpg", "https://www.youtube.com/embed/_uQXxvZ3afQ");
                int idcapitulo34 = capituloCEN.New_(idtemporada13, "1-The Robotic Manipulation", new DateTime(1993, 12, 3), cbig6, "big6.jpg", "https://www.youtube.com/embed/_uQXxvZ3afQ");
                int idcapitulo35 = capituloCEN.New_(idtemporada14, "1-The Skank Reflex Analysis", new DateTime(1993, 12, 3), cbig7, "big7.jpg", "https://www.youtube.com/embed/_uQXxvZ3afQ");
                int idcapitulo36 = capituloCEN.New_(idtemporada15, "1-The Date Night Variable", new DateTime(1993, 12, 3), cbig8, "big8.jpg", "https://www.youtube.com/embed/_uQXxvZ3afQ");

                int idcapitulo37 = capituloCEN.New_(idtemporada16, "1-Winter Is Coming", new DateTime(1993, 12, 3), cgot1, "got1.jpg", "https://www.youtube.com/embed/iGp_N3Ir7Do");
                int idcapitulo38 = capituloCEN.New_(idtemporada16, "2-The Kingsroad", new DateTime(1993, 12, 3), cgot2, "got2.jpg", "https://www.youtube.com/embed/iGp_N3Ir7Do");
                int idcapitulo39 = capituloCEN.New_(idtemporada16, "3-Lord Snow", new DateTime(1993, 12, 3), cgot3, "got3.jpg", "https://www.youtube.com/embed/iGp_N3Ir7Do");
                int idcapitulo40 = capituloCEN.New_(idtemporada17, "1-The North Remembers", new DateTime(1993, 12, 3), cgot4, "got4.jpg", "https://www.youtube.com/embed/iGp_N3Ir7Do");
                int idcapitulo41 = capituloCEN.New_(idtemporada18, "1-Valar Dohaeris", new DateTime(1993, 12, 3), cgot5, "got5.jpg", "https://www.youtube.com/embed/iGp_N3Ir7Do");
                int idcapitulo42 = capituloCEN.New_(idtemporada19, "1-Two Swords", new DateTime(1993, 12, 3), cgot6, "got6.jpg", "https://www.youtube.com/embed/iGp_N3Ir7Do");
                int idcapitulo43 = capituloCEN.New_(idtemporada20, "1-The Wars to Come", new DateTime(1993, 12, 3), cgot7, "got7.jpg", "https://www.youtube.com/embed/iGp_N3Ir7Do");
                int idcapitulo44 = capituloCEN.New_(idtemporada21, "1-The Red Woman", new DateTime(1993, 12, 3), cgot8, "got8.jpg", "https://www.youtube.com/embed/iGp_N3Ir7Do");

                int idcapitulo45 = capituloCEN.New_(idtemporada22, "Pilot", new DateTime(1993, 12, 3), chow1, "how1.jpg", "https://www.youtube.com/embed/apRiP2h-O5o");
                int idcapitulo46 = capituloCEN.New_(idtemporada22, "2-Purple Giraffe", new DateTime(1993, 12, 3), chow2, "how2.jpg", "https://www.youtube.com/embed/apRiP2h-O5o");
                int idcapitulo47 = capituloCEN.New_(idtemporada22, "3-Sweet Taste of Liberty", new DateTime(1993, 12, 3), chow3, "how3.jpg", "https://www.youtube.com/embed/apRiP2h-O5o");
                int idcapitulo48 = capituloCEN.New_(idtemporada23, "1-Where Were We?", new DateTime(1993, 12, 3), chow4, "how4.jpg", "https://www.youtube.com/embed/apRiP2h-O5o");
                int idcapitulo49 = capituloCEN.New_(idtemporada24, "1-Wait for It", new DateTime(1993, 12, 3), chow5, "how5.jpg", "https://www.youtube.com/embed/apRiP2h-O5o");
                int idcapitulo50 = capituloCEN.New_(idtemporada25, "1-Do I Know You?", new DateTime(1993, 12, 3), chow6, "how6.jpg", "https://www.youtube.com/embed/apRiP2h-O5o");
                int idcapitulo51 = capituloCEN.New_(idtemporada26, "1-Definitions", new DateTime(1993, 12, 3), chow7, "how7.jpg", "https://www.youtube.com/embed/apRiP2h-O5o");
                int idcapitulo52 = capituloCEN.New_(idtemporada27, "1-Big Days", new DateTime(1993, 12, 3), chow8, "how8.jpg", "https://www.youtube.com/embed/apRiP2h-O5o");

                int idcapitulo53 = capituloCEN.New_(idtemporada28, "1-Tape 1, Side A", new DateTime(1993, 12, 3), crea1, "rea1.jpg", "https://www.youtube.com/embed/taMknA8wFrY");
                int idcapitulo54 = capituloCEN.New_(idtemporada28, "2-Tape 1, Side B", new DateTime(1993, 12, 3), crea2, "rea2.jpg", "https://www.youtube.com/embed/taMknA8wFrY");

                int idcapitulo55 = capituloCEN.New_(idtemporada29, "1-Chapter One: The Vanishing of Will Byers", new DateTime(1993, 12, 3), cstr1, "str1.jpg", "https://www.youtube.com/embed/udmlXQj4new");
                int idcapitulo56 = capituloCEN.New_(idtemporada29, "2-Chapter Two: The Weirdo on Maple Street", new DateTime(1993, 12, 3), cstr2, "str2.jpg", "https://www.youtube.com/embed/udmlXQj4new");
                int idcapitulo57 = capituloCEN.New_(idtemporada29, "3-Chapter Three: Holly, Jolly", new DateTime(1993, 12, 3), cstr3, "str3.jpg", "https://www.youtube.com/embed/udmlXQj4new");
                int idcapitulo58 = capituloCEN.New_(idtemporada30, "1-Chapter One: MADMAX", new DateTime(1993, 12, 3), cstr4, "str4.jpg", "https://www.youtube.com/embed/UMb3G8WQMsI");
                int idcapitulo59 = capituloCEN.New_(idtemporada30, "1-Chapter Two: Trick or Treat, Freak", new DateTime(1993, 12, 3), cstr5, "str5.jpg", "https://www.youtube.com/embed/UMb3G8WQMsI");

                int idcapitulo60 = capituloCEN.New_(idtemporada31, "Piloto", new DateTime(1993, 12, 3), crick1, "rick1.jpg", "https://www.youtube.com/embed/ZX-j8VPXCwA");
                int idcapitulo61 = capituloCEN.New_(idtemporada31, "2-Lawnmower Dog", new DateTime(1993, 12, 3), crick2, "rick2.jpg", "https://www.youtube.com/embed/0VBQRnP-xj0");
                int idcapitulo62 = capituloCEN.New_(idtemporada31, "3-Anatomy Park", new DateTime(1993, 12, 3), crick3, "rick3.jpg", "https://www.youtube.com/embed/7wMatAhhHSI");
                int idcapitulo63 = capituloCEN.New_(idtemporada31, "4-M. Night Shaym-Aliens!", new DateTime(1993, 12, 3), crick4, "rick4.jpg", "https://www.youtube.com/embed/0yySbBKW6Zw");
                int idcapitulo64 = capituloCEN.New_(idtemporada32, "1-A Rickle in Time", new DateTime(1993, 12, 3), crick5, "rick5.jpg", "https://www.youtube.com/embed/sztQVOdVbkU");
                int idcapitulo65 = capituloCEN.New_(idtemporada33, "1-The Rickshank Rickdemption", new DateTime(1993, 12, 3), crick6, "rick6.jpg", "https://www.youtube.com/embed/veoymnykMe0");
                int idcapitulo66 = capituloCEN.New_(idtemporada33, "2-Rickmancing the Stone", new DateTime(1993, 12, 3), crick7, "rick7.jpg", "https://www.youtube.com/embed/3FcHfqDYJq4");
                int idcapitulo67 = capituloCEN.New_(idtemporada33, "2-Pickle Rick", new DateTime(1993, 12, 3), crick8, "rick8.jpg", "https://www.youtube.com/embed/bXeRpoWJK_I");

                int idcapitulo68 = capituloCEN.New_(idtemporada34, "Piloto", new DateTime(1993, 12, 3), cyoung1, "young1.jpg", "https://www.youtube.com/embed/ivtB0ucW1EQ");
                int idcapitulo69 = capituloCEN.New_(idtemporada34, "2-Rockets, Communists, and the Dewey Decimal System", new DateTime(1993, 12, 3), cyoung2, "young2.jpg", "https://www.youtube.com/embed/ivtB0ucW1EQ");
                int idcapitulo70 = capituloCEN.New_(idtemporada34, "3-Poker, Faith, and Eggs", new DateTime(1993, 12, 3), cyoung3, "young3.jpg", "https://www.youtube.com/embed/ivtB0ucW1EQ");

                int idcapitulo71 = capituloCEN.New_(idtemporada35, "1-The National Anthem", new DateTime(1993, 12, 3), cblack1, "black1.jpg", "https://www.youtube.com/embed/eLrfW3a9cqg");
                int idcapitulo72 = capituloCEN.New_(idtemporada35, "2-15 Million Merits", new DateTime(1993, 12, 3), cblack2, "black2.jpg", "https://www.youtube.com/embed/eLrfW3a9cqg");
                int idcapitulo73 = capituloCEN.New_(idtemporada35, "3-The Entire History of You", new DateTime(1993, 12, 3), cblack3, "black3.jpg", "https://www.youtube.com/embed/eLrfW3a9cqg");
                int idcapitulo74 = capituloCEN.New_(idtemporada36, "1-Be Right Back", new DateTime(1993, 12, 3), cblack4, "black4.jpg", "https://www.youtube.com/embed/eLrfW3a9cqg");
                int idcapitulo75 = capituloCEN.New_(idtemporada37, "1-Nosedive", new DateTime(1993, 12, 3), cblack5, "black5.jpg", "https://www.youtube.com/embed/eLrfW3a9cqg");
                int idcapitulo76 = capituloCEN.New_(idtemporada38, "1-USS Callister", new DateTime(1993, 12, 3), cblack6, "black6.jpg", "https://www.youtube.com/embed/eLrfW3a9cqg");

                int idcapitulo77 = capituloCEN.New_(idtemporada39, "1-Rites of Passage", new DateTime(1993, 12, 3), cvik1, "vik1.jpg", "https://www.youtube.com/embed/5aASH8HMJbo");
                int idcapitulo78 = capituloCEN.New_(idtemporada39, "2-Wrath of the Northmen", new DateTime(1993, 12, 3), cvik2, "vik2.jpg", "https://www.youtube.com/embed/5aASH8HMJbo");
                int idcapitulo79 = capituloCEN.New_(idtemporada40, "1-Brother's War", new DateTime(1993, 12, 3), cvik3, "vik3.jpg", "https://www.youtube.com/embed/5aASH8HMJbo");
                int idcapitulo80 = capituloCEN.New_(idtemporada41, "1-Mercenary", new DateTime(1993, 12, 3), cvik4, "vik4.jpg", "https://www.youtube.com/embed/5aASH8HMJbo");
                int idcapitulo81 = capituloCEN.New_(idtemporada42, "1-A Good Treason", new DateTime(1993, 12, 3), cvik5, "vik5.jpg", "https://www.youtube.com/embed/5aASH8HMJbo");
                int idcapitulo82 = capituloCEN.New_(idtemporada43, "1-The Departed (Part 1)", new DateTime(1993, 12, 3), cvik6, "vik6.jpg", "https://www.youtube.com/embed/5aASH8HMJbo");
                int idcapitulo83 = capituloCEN.New_(idtemporada43, "2-The Departed (Part 2)", new DateTime(1993, 12, 3), cvik7, "vik7.jpg", "https://www.youtube.com/embed/5aASH8HMJbo");

                int idcapitulo84 = capituloCEN.New_(idtemporada44, "1-eps1.0_hellofriend.mov", new DateTime(1993, 12, 3), cmr1, "mr1.jpg", "https://www.youtube.com/embed/nejl8EUqf5M");
                int idcapitulo85 = capituloCEN.New_(idtemporada44, "2-eps1.1_ones-and-zer0es.mpeg", new DateTime(1993, 12, 3), cmr2, "mr2.jpg", "https://www.youtube.com/embed/nejl8EUqf5M");
                int idcapitulo86 = capituloCEN.New_(idtemporada45, "1-eps2.0_unm4sk-pt1.tc", new DateTime(1993, 12, 3), cmr3, "mr3.jpg", "https://www.youtube.com/embed/nejl8EUqf5M");
                int idcapitulo87 = capituloCEN.New_(idtemporada46, "1-eps3.0_power-saver-mode.h", new DateTime(1993, 12, 3), cmr4, "mr4.jpg", "https://www.youtube.com/embed/nejl8EUqf5M");
                

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
