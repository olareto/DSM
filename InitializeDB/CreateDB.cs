
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
                string dstw = "Treinta a�os despu�s de derrotar al Imperio Gal�ctico, Han Solo y sus aliados enfrentan una nueva amenaza del malvado Kylo Ren y su ej�rcito de Stormtroopers.";
                string despider = "Tras los acontecimientos del Capit�n Am�rica: Guerra civil, Peter Parker, con la ayuda de su mentor Tony Stark, intenta equilibrar su vida como un estudiante normal de secundaria en Queens, Nueva York, con la lucha contra el crimen como su superh�roe alter ego Spider- El hombre como una nueva amenaza, el Buitre, emerge.";
                string djumanji = "Las tornas se vuelven cuando cuatro adolescentes son absorbidos por el mundo de Jumanji: enfrentado a rinocerontes, mambas negras y una interminable variedad de trampas y acertijos de la jungla. Para sobrevivir, jugar�n como personajes del juego.";
                string dcoco = "A pesar de la desconcertante prohibici�n de la generaci�n de m�sica de su familia, Miguel sue�a con convertirse en un m�sico consumado como su �dolo, Ernesto de la Cruz. Desesperado por demostrar su talento, Miguel se encuentra en la deslumbrante y colorida Tierra de los Muertos siguiendo una misteriosa cadena de eventos. En el camino, se encuentra con el encantador tramposo H�ctor, y juntos, partieron en un viaje extraordinario para descubrir la historia real detr�s de la historia familiar de Miguel.";
                string dperfdesc = "La historia se desarrolla a lo largo de una noche, durante un eclipse lunar, en el hogar de Alfonso y Eva, una pareja profesional bien curada preocupada por su hija adolescente y por la monoton�a de sus vidas. A ellos se unen cinco invitados: Eduardo y Blanco, Antonio y Ana y Pepe. Es una cena como cualquier otra, hasta que alguien tenga una idea intrigante: �y si ponen sus tel�fonos m�viles a disposici�n del grupo, dej�ndolos en el medio de la mesa para que todos los vean?";
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
                string dhappy = "Nick Sax es un ex polic�a borracho y corrupto que se convierte en un sicario, y que est� a la deriva en un mundo de asesinatos casuales, sexo desalmado y traici�n. Despu�s de que un trabajo falla, su vida ebria es cambiada para siempre por un caballo alado peque�o, implacablemente positivo e imaginario llamado Happy.";
                string ddam = "Seth Davenport parece ser un peque�o predicador de la ciudad de Iowa, pero tiene ambiciones de comenzar una insurrecci�n en toda regla contra el status quo. Pero �l no sabe que un magnate industrial ha contratado a un rompehuelgas profesional mortal llamado Creeley Turner para detener esa insurrecci�n por cualquier medio necesario. Y desconocido para quienes los rodean, estos dos hombres comparten un pasado sangriento secreto.";
                string dvh = "Vanessa Helsing, pariente lejana del famoso cazador de vampiros Abraham Van Helsing, es resucitada solo para descubrir que los vampiros se han adue�ado del mundo.";
                string drw = "Despu�s de descubrir que sus padres son s�per villanos disfrazados, un grupo de adolescentes se junta para huir de sus hogares a fin de expiar las acciones de sus padres y descubrir los secretos de sus or�genes.";
                string dgot = "Siete familias nobles luchan por el control de la tierra m�tica de Poniente. La fricci�n entre las casas conduce a una guerra a gran escala. Todo mientras un mal muy antiguo despierta en el extremo norte. En medio de la guerra, una orden militar descuidada de inadaptados, la Guardia de la Noche, es todo lo que se interpone entre los reinos de los hombres y los helados horrores m�s all�.";
                string dbgbg = "�Qu� sucede cuando los compa�eros de cuarto hiperinteligentes Sheldon y Leonard conocen a Penny, una belleza de esp�ritu libre que se mueve en la casa de al lado, y se dan cuenta de que no saben casi nada sobre la vida fuera del laboratorio. Completan la tripulaci�n el fan�tico Wolowitz, que piensa que es tan sexy como �l, y Koothrappali, que no puede hablar en presencia de una mujer.";
                string dhimym = "El a�o es 2030. Ted Mosby transmite la historia de c�mo conoci� a su esposa a su hija e hijo. La historia comienza en el a�o 2005, cuando el entonces arquitecto Ted, de veintisiete a�os, se anim� a querer casarse despu�s de sus mejores amigos de Wesleyan, el abogado Marshall Eriksen, que era su compa�ero de habitaci�n en ese momento y maestro de jard�n de infantes. Lily Aldrin, se comprometi� despu�s de nueve a�os de salir juntos.";
                string d13 = "Sigue al adolescente Clay Jensen, en su b�squeda para descubrir la historia detr�s de su compa�era de clase y enamoramiento, Hannah, y su decisi�n de poner fin a su vida.";
                string dst = "Cuando un ni�o desaparece, su madre, un jefe de polic�a y sus amigos deben enfrentar fuerzas terror�ficas para recuperarlo.";
                string dRYM = "Una serie animada que sigue las haza�as de un s�per cient�fico y su nieto no tan brillante. ";
                string dysh = "La vida temprana del ni�o genio Sheldon Cooper, m�s tarde visto en The Big Bang Theory (2007).";
                string dbmir = "Una serie de antolog�a de televisi�n que muestra el lado oscuro de la vida y la tecnolog�a.";
                string dvik = "Vikingos sigue las aventuras de Ragnar Lothbrok, el m�s grande h�roe de su edad. La serie cuenta las sagas de la banda de hermanos vikingos de Ragnar y su familia, mientras se eleva para convertirse en rey de las tribus vikingas. Adem�s de ser un valiente guerrero, Ragnar encarna las tradiciones n�rdicas de devoci�n a los dioses, seg�n la leyenda, �l era un descendiente directo de Od�n, el dios de la guerra y los guerreros.";
                string dmrr = "El Sr. Robot sigue a Elliot, un joven programador que trabaja de ingeniero de ciberseguridad de d�a y un hacker vigilante por la noche. Elliot se encuentra en una encrucijada cuando el misterioso l�der de un grupo clandestino de hackers lo recluta para destruir la corporaci�n a la que se le paga por proteger.";

                //string idUsuario = usuarioCEN.New_("usuario", "apellidos", "contrasenya", "correo", "direcccion", "pago", "imagen");
                //adminCEN.New_ ("usuario", "apellidos", "contrasenya", "correo", "direcccion", "pago", "imagen"));
                int idevento = eventoCEN.New_ ("evento", 72, "descripcion", "imagen", SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.dos, 8, "desclarga", "imagran", "tipo");
                int idCarrito = carritoCEN.New_ (idUsuario, 50000);

                int idArticulo = articuloCEN.New_ ("articulo", 69, "descripcion", "imagen", SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, 999, "desclarga","imagran");

                int idlineas_pedido = lineas_pedidoCEN.New_ (idCarrito, 3);


                int idoferta = ofertaCEN.New_ (idArticulo, new DateTime (1993, 12, 3), new DateTime (1993, 12, 3), 99);

                int idproducto = productoCEN.New_ ("producto", 69, "descripcion", "imagen", SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, 999, "desclarga", "imagran", "talla");

                int idlista = listaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.Estado_videoEnum.visto, idUsuario);
                int idcomentario = comentarioCEN.New_ ("comentario", "autor", new DateTime (1993, 12, 3));

                int idpelicula = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Star Wars:Episodio VII", "i5.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idpelicula2 = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "Jumanji", "i2.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idpelicula3 = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "COCO", "i7.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idpelicula4 = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "Perfectos desconocidos", "i3.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idpelicula5 = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Dando la nota 3", "i4.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idpelicula6 = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "Ferdinand", "ferdi.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idpelicula7 = peliculaCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "Wonder Wheel", "i8.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idpelicula8 = peliculaCEN.New_(SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "Spider-Man: Homecoming", "spider.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idpelicula9 = peliculaCEN.New_(SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Wonder Woman", "ww.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idpelicula10 = peliculaCEN.New_(SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "it", "it.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idpelicula11 = peliculaCEN.New_(SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "feliz dia de tu muerte", "hday.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idpelicula12 = peliculaCEN.New_(SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.tres, "Despicable Me 3", "gru.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idpelicula13 = peliculaCEN.New_(SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Harry Potter y las reliquias de la muerte: Parte 1", "hrr1.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idpelicula14 = peliculaCEN.New_(SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Harry Potter y las reliquias de la muerte: Parte 2", "hrr2.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idpelicula15 = peliculaCEN.New_(SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "Blade Runner 2049 ", "blad.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idpelicula16 = peliculaCEN.New_(SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "Baywatch ", "bay.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");

                int idvideo = videoCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "nombre", "hola", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");

                int idserie = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.tres, "La To Vegas", "s1.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idserie2 = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "Happy", "s2.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idserie3 = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Lucifer", "luci.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idserie4 = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "Damnation", "s4.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idserie5 = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "Van Helsing", "vh.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idserie6 = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Runaways", "rwa.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idserie7 = serieCEN.New_ (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "The Big Bang", "bigbang.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idserie8 = serieCEN.New_(SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Game of Thrones", "got.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idserie9 = serieCEN.New_(SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "HowIMeetYourMother", "himym.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idserie10 = serieCEN.New_(SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cuatro, "13 Reason Why", "reason.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idserie11 = serieCEN.New_(SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Stranger Things", "st.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idserie12 = serieCEN.New_(SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Rick y Morty", "RYM.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idserie13 = serieCEN.New_(SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Young Sheldon", "ysh.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idserie14 = serieCEN.New_(SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Black Mirror", "bmir.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idserie15 = serieCEN.New_(SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Vikings", "vik.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");
                int idserie16 = serieCEN.New_(SMPGenNHibernate.Enumerated.SMP.ValoracionEnum.cinco, "Mr.Robot", "mrr.jpg", "desclarga", "descripcion", "genero", new DateTime (1993, 12, 3), "imagrande");



                int idtemporada = temporadaCEN.New_ (idserie, "nombre");
                int idtemporada2 = temporadaCEN.New_ (idserie2, "nombre");
                int idcapitulo = capituloCEN.New_ (idtemporada, "nombre", new DateTime (1993, 12, 3), "descripccion", "imagen");
                int idcapitulo2 = capituloCEN.New_ (idtemporada2, "nombre", new DateTime (1993, 12, 3), "descripccion", "imagen");
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
