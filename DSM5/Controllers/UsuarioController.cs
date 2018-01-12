using DSM5.Models;
using SMPGenNHibernate.CAD.SMP;
using SMPGenNHibernate.CEN.SMP;
using SMPGenNHibernate.CP.SMP;
using SMPGenNHibernate.EN.SMP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSM5.Controllers
{
    public class UsuarioController : BasicController
    {
        // GET: Articulo
        public ActionResult Index()
        {

          
            if(System.Web.HttpContext.Current.Session["log"]!=null && (Boolean)System.Web.HttpContext.Current.Session["log"])
            {
                //Usuario hola= System.Web.HttpContext.Current.Session["usuario"]as Usuario;
                String hola = System.Web.HttpContext.Current.Session["correo"] as String;


                

                ViewData["correo"] = System.Web.HttpContext.Current.Session["correo"] as string;
                ViewData["log"] = (Boolean)System.Web.HttpContext.Current.Session["log"];
                ViewData["admin"] = (Boolean)System.Web.HttpContext.Current.Session["admin"];


                return RedirectToAction("Details", "Usuario", new { id=hola });
            }
            return RedirectToAction("log", "Usuario",null);
           
        }

        // GET: Articulo/Details/5
        public ActionResult Details(string id)
        {


            SessionInitialize();
            UsuarioCAD cad = new UsuarioCAD(session);
            UsuarioCEN cen = new UsuarioCEN(cad);
            
            UsuarioEN en = new UsuarioEN();
            
            en = cen.ReadOID(id);

            // CarritoCEN cenc = new CarritoCEN();
            //CarritoEN enc = new CarritoEN();
            //enc = en.Carrito;
           
            AssemblerUsuario ass = new AssemblerUsuario();
            Usuario sol =ass.ConvertENToModelUI(en);
            
            SessionClose();
            return View(sol);
        }

        // GET: Articulo/Create
        public ActionResult Create()
        {
            
            Usuario sol = new Usuario();
            return View(sol);
        }

        // POST: Articulo/Create
        [HttpPost]
        public ActionResult Create(Usuario collection)
        {
            try
            {
                // TODO: Add insert logic here
                UsuarioCEN cen = new UsuarioCEN();
                UsuarioCP cp = new UsuarioCP();
                string id=cp.New_CP( collection.Nombre, collection.Apellidos, collection.Password, collection.Email, collection.Direccion, collection.Tarjeta, collection.Imagen).Email;
               
              
                CarritoCEN CarritoCEN = new CarritoCEN();
                int id4 = CarritoCEN.New_(id, 0);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Createadmin()
        {

            Usuario sol = new Usuario();
            return View(sol);
        }

        // POST: Articulo/Create
        [HttpPost]
        public ActionResult Createadmin(Usuario collection)
        {
            try
            {
                // TODO: Add insert logic here
                AdminCEN cen = new AdminCEN();
                AdminCP cp = new AdminCP();
                string id = cp.New_CP(collection.Nombre, collection.Apellidos, collection.Password, collection.Email, collection.Direccion, collection.Tarjeta, collection.Imagen).Email;


                CarritoCEN CarritoCEN = new CarritoCEN();
                int id4 = CarritoCEN.New_(id, 0);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Articulo/Edit/5
        public ActionResult Edit(string id)
        {
            SessionInitialize();
            UsuarioCAD cad = new UsuarioCAD(session);
            

            UsuarioCEN cen = new UsuarioCEN(cad);

            UsuarioEN en = new UsuarioEN();
            en = cen.ReadOID(id);

            // SessionInitializeTransaction();

            //IProducto productoCAD = new productoCAD(session);

            // ProductoEN en = new Pro;
            AssemblerUsuario ass = new AssemblerUsuario();
            Usuario sol = ass.ConvertENToModelUI(en);
            SessionClose();
            return View(sol);
        }

        // POST: Articulo/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Usuario collection)
        {
            try
            {
                // TODO: Add update logic here
                UsuarioCEN cen = new UsuarioCEN();

                cen.Modify(id, collection.Nombre, collection.Apellidos, collection.Password, collection.Direccion, collection.Tarjeta, collection.Imagen);
                //cen.New_(collection.Nombre, collection.Precio, collection.Descripcion, collection.Imagen, collection.Valor, collection.Stock, collection.Talla);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Articulo/Delete/5
        public ActionResult Delete(string id)
        {
            SessionInitialize();
            UsuarioCAD cad = new UsuarioCAD(session);
            

            UsuarioCEN cen = new UsuarioCEN(cad);

            UsuarioEN en = new UsuarioEN();
            en = cen.ReadOID(id);
            AssemblerUsuario ass = new AssemblerUsuario();
            Usuario sol = ass.ConvertENToModelUI(en);
            SessionClose();
            return View(sol);
        }

        // POST: Articulo/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                /**
                UsuarioCEN cen = new UsuarioCEN();
                cen.Destroy(id);
               **/
                // TODO: Add delete logic here
                
                SessionInitialize();
                //UsuarioCAD cad = new UsuarioCAD(session);
                UsuarioCEN cen = new UsuarioCEN();

                UsuarioEN en = new UsuarioEN();

                en = cen.ReadOID(id);
                bool si = false;
                if (en is AdminEN)
                {
                    si=true;
                    
                }
            
                SessionClose();
                if (si==true)
                {
                    return RedirectToAction("borraradmin", "Usuario", new { id = id });
                }
                else
                {
                    return RedirectToAction("borrarusu", "Usuario",new { id=id});
                }
    
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Articulo/Resultadobusqueda/5
        public ActionResult borraradmin(String id)
        {
            AdminCEN cena = new AdminCEN();
            CarritoCEN carr = new CarritoCEN();

            int carrito = cena.ReadOID(id).Carrito.Id;
            carr.Destroy(carrito);
            cena.Destroy(id);


            return RedirectToAction("Index");
        }

        public ActionResult borrarusu(String id)
        {
            UsuarioCEN cenn = new UsuarioCEN();

            CarritoCEN carr = new CarritoCEN();

            int carrito = cenn.ReadOID(id).Carrito.Id;
            carr.Destroy(carrito);

            cenn.Destroy(id);


            return RedirectToAction("Index");
        }
        public ActionResult Resultadobusqueda()
        {

            System.Web.HttpContext.Current.Session["controller"] = "Evento";
            System.Web.HttpContext.Current.Session["action"] = "Resultadobusqueda";
            System.Web.HttpContext.Current.Session["arg"] = null;

            IList<Usuario> res = System.Web.HttpContext.Current.Session["resu"] as IList<Usuario>;
            if (res == null)
            {
                res = new List<Usuario>();
            }
            ViewData["controller"] = System.Web.HttpContext.Current.Session["controller"] as String;
            ViewData["action"] = System.Web.HttpContext.Current.Session["action"] as String;
            ViewData["arg"] = System.Web.HttpContext.Current.Session["arg"];

            return View(res);
        }
        // GET: Articulo/Filtrar/5
        ////////////////

        public ActionResult Filtrar()
        {

            FiltroUsuario res = new FiltroUsuario();
            

            //articuloAsembler.covert
            return View(res);
        }
        // POST: Articulo/Filtrar/5
        [HttpPost]
        public ActionResult Filtrar(FiltroUsuario collection)
        {
            try
            {
                SessionInitialize();
                UsuarioCAD cad = new UsuarioCAD(session);
                UsuarioCEN cen = new UsuarioCEN(cad);
                IList<UsuarioEN> res = null, aux = null;
                // TODO: Add delete logic here
                res = cen.ReadAll(0, int.MaxValue);

                
                if (collection.Nombrebol == true && collection.Nombre != null)
                {
                    

                    aux = cen.Filtronombre(collection.Nombre);
                    res = res.Intersect(aux).ToList();
                }
                
                AssemblerUsuario ass = new AssemblerUsuario();
                AssemblerAdmin assa = new AssemblerAdmin();
                IList<Usuario> listart = new List<Usuario>();

                for (int i = 0; i < res.Count; i++)
                {
                    if (res.ElementAt(i) is AdminEN)
                    {
                        AdminEN hola = (AdminEN)res.ElementAt(i);
                        listart.Add(assa.ConvertENToModelUI(hola));
                    }
                    else
                    {
                        listart.Add(ass.ConvertENToModelUI(res.ElementAt(i)));
                    }

                }


                //IList<Usuario> listart = ass.ConvertListENToModel(res);
                SessionClose();
                System.Web.HttpContext.Current.Session["resu"] = listart;
                return RedirectToAction("Resultadobusqueda", "Usuario", null);

            }
            catch
            {

                return View();
            }


        }

        public ActionResult deslog()
        {
            System.Web.HttpContext.Current.Session["usuario"] = null;
            System.Web.HttpContext.Current.Session["log"] = false;
            System.Web.HttpContext.Current.Session["admin"] = false;
            System.Web.HttpContext.Current.Session["correo"] = null;
            System.Web.HttpContext.Current.Session["nombre"] = null;
            return RedirectToAction("Index", "Usuario");
        }

        public ActionResult addcarr(string idus,int idpro)
        {
            if (idus == null)
            {
                return RedirectToAction("log", "Usuario", null);
            }
            SessionInitialize();
            UsuarioCAD cad = new UsuarioCAD(session);
            


            UsuarioCEN cen = new UsuarioCEN(cad);
            UsuarioEN en = cen.ReadOID(idus);
            AssemblerUsuario ass = new AssemblerUsuario();
            Usuario sol = ass.ConvertENToModelUI(en);
            SessionClose();
            return RedirectToAction("addlinea", "Carrito", new { id=sol.carrito,idpro=idpro });
            //return View(sol);
        }


        public ActionResult mostrarlista(string idus,string tipo)
        {
            SessionInitialize();
            UsuarioCAD cad = new UsuarioCAD(session);

            UsuarioCEN cen = new UsuarioCEN(cad);
            UsuarioEN en = cen.ReadOID(idus);
            AssemblerUsuario ass = new AssemblerUsuario();


           
            IList<Pelicula> listappp = null;
            IList<Serie> listasss = null;
            AssemblerPelicula assp = new AssemblerPelicula();
            AssemblerSerie asss = new AssemblerSerie();


            Usuario sol = ass.ConvertENToModelUI(en);
            int idlist = -1;
            IList<PeliculaEN> listap = null;
            IList<SerieEN> listas = null;
            if (tipo == "sig")
            {
                System.Web.HttpContext.Current.Session["lista"] = "Seguidos";
                idlist = sol.siguiendo;
                listap = en.Lista.ElementAt(0).Pelicula;
                listas = en.Lista.ElementAt(0).Serie;
            }
            else if (tipo == "fav")
            {
                System.Web.HttpContext.Current.Session["lista"] = "Favoritos";
                idlist = sol.favorito;
                listap = en.Lista.ElementAt(1).Pelicula;
                listas = en.Lista.ElementAt(1).Serie;
            }
            else if (tipo == "visto")
            {
                System.Web.HttpContext.Current.Session["lista"] = "Vistos";
                idlist = sol.visto;
                listap = en.Lista.ElementAt(2).Pelicula;
                listas = en.Lista.ElementAt(2).Serie;
            }
            listappp = assp.ConvertListENToModel(listap) ;
            listasss = asss.ConvertListENToModel(listas);

            ViewBag.peli = listappp;
            ViewBag.serie = listasss;
            ViewData["correo"] = System.Web.HttpContext.Current.Session["correo"];
            ViewData["type"] = tipo;
            SessionClose();
            return View();
        }

        public ActionResult dellist(string idus, int idpro, string tipo, string t)
        {

            ListaCEN cenl = new ListaCEN();
            SessionInitialize();
            UsuarioCAD cad = new UsuarioCAD(session);
            UsuarioCEN cen = new UsuarioCEN(cad);
            UsuarioEN en = cen.ReadOID(idus);

            AssemblerUsuario ass = new AssemblerUsuario();
            Usuario us = ass.ConvertENToModelUI(en);

            IList<int> vamos = new List<int>();
            vamos.Add(idpro);

            if (t == "peli")
            {
                if (tipo == "sig")
                {
                    cenl.Delpel(us.siguiendo,vamos);
                }
                else if (tipo == "fav")
                {
                    cenl.Delpel(us.favorito, vamos);
                }
                else if (tipo == "visto")
                {
                    cenl.Delpel(us.visto, vamos);
                }
            }
            else
            {
                if (tipo == "sig")
                {
                    cenl.Delserie(us.siguiendo, vamos);
                }
                else if (tipo == "fav")
                {
                    cenl.Delserie(us.favorito, vamos);
                }
                else if (tipo == "visto")
                {
                    cenl.Delserie(us.visto, vamos);
                }
            }

            SessionClose();



            return RedirectToAction("mostrarlista", "Usuario", new { idus=idus,tipo=tipo});
        }
        public ActionResult addlist(string idus, int idpro,string lista)
        {
            if (idus == null)
            {
                return RedirectToAction("log", "Usuario", null);
            }
            SessionInitialize();
            UsuarioCAD cad = new UsuarioCAD(session);

            UsuarioCEN cen = new UsuarioCEN(cad);
            UsuarioEN en = cen.ReadOID(idus);
            AssemblerUsuario ass = new AssemblerUsuario();
            Usuario sol = ass.ConvertENToModelUI(en);
            int idlist=-1;
            IList<PeliculaEN> listap=null;
            IList<SerieEN> listas=null;
            if (lista== "sig")
            {
                idlist = sol.siguiendo;
                listap = en.Lista.ElementAt(0).Pelicula;
                listas=en.Lista.ElementAt(0).Serie;
            }
            else if(lista=="fav"){
                idlist = sol.favorito;
                listap = en.Lista.ElementAt(1).Pelicula;
                listas = en.Lista.ElementAt(1).Serie;
            }
            else if(lista == "visto")
            {
                idlist = sol.visto;
                listap = en.Lista.ElementAt(2).Pelicula;
                listas = en.Lista.ElementAt(2).Serie;
            }




            ListaCEN cenl = new ListaCEN();

            PeliculaCEN cenp = new PeliculaCEN();
            PeliculaEN enp = cenp.ReadOID(idpro);
            SerieCEN cens = new SerieCEN();
            SerieEN ens = cens.ReadOID(idpro);







            AssemblerSerie asss = new AssemblerSerie();
            IList<Serie> sols = asss.ConvertListENToModel( listas);


            AssemblerPelicula assp = new AssemblerPelicula();
            IList<Pelicula> solp = assp.ConvertListENToModel(listap);
            



            string tipo = null;
            Boolean si = false;
            foreach (Serie linea in sols)
            {
                if (linea.id == idpro)
                {
                    return RedirectToAction("Details", "Serie", new { id =  idpro });
                 
                }
            }
            foreach (Pelicula linea in solp)
            {
                if (linea.id == idpro)
                {
                    return RedirectToAction("Details", "Pelicula", new { id = idpro });

                }
            }

            if (si == false)
            {

                IList<int> vamos = new List<int>();
                if (enp != null)
                {
                    vamos.Add(idpro);
                    cenl.Addpel(idlist, vamos);
                    tipo = "Pelicula";
                }
                else
                {
                    vamos.Add(idpro);
                    cenl.Addserie(idlist, vamos);
                    tipo = "Serie";
                }
               
            }

            SessionClose();




            return RedirectToAction("Details", tipo, new { id = idpro });
            //return View(sol);
        }

        public ActionResult log()
        {

            Registro sol = new Registro();
            return View(sol);
        }

        // POST: Articulo/Create
        [HttpPost]
        public ActionResult log(Registro collection)
        {
            try
            {
                SessionInitialize();
                UsuarioCAD cad = new UsuarioCAD(session);
                
                // TODO: Add insert logic here
                UsuarioCEN cen = new UsuarioCEN(cad);
                UsuarioEN en = new UsuarioEN();
                AssemblerUsuario ass = new AssemblerUsuario();
                Usuario us;

                
               

                if (cen.Login(collection.email, collection.Password)) {
                    en = cen.ReadOID(collection.email);
                    us = ass.ConvertENToModelUI(en);
                    if (en is AdminEN) { 
                   

                    System.Web.HttpContext.Current.Session["usuario"] = us;
                    System.Web.HttpContext.Current.Session["correo"] = us.Email;
                    System.Web.HttpContext.Current.Session["log"] = true;
                    System.Web.HttpContext.Current.Session["admin"] = true;
                    System.Web.HttpContext.Current.Session["carrito"] = us.carrito;
                        System.Web.HttpContext.Current.Session["nombre"] = us.Nombre;

                        SessionClose();

                }
                else
                {
                    

                    System.Web.HttpContext.Current.Session["usuario"] = us;
                    System.Web.HttpContext.Current.Session["correo"] = us.Email;
                    System.Web.HttpContext.Current.Session["log"] = true;
                    System.Web.HttpContext.Current.Session["admin"] = false;
                    System.Web.HttpContext.Current.Session["carrito"] = us.carrito;
                        System.Web.HttpContext.Current.Session["nombre"] = us.Nombre;
                        SessionClose();
                }
                    return RedirectToAction("Details", "Usuario", new { id = collection.email });
                }
                else
                {
                    System.Web.HttpContext.Current.Session["usuario"] = null;
                    System.Web.HttpContext.Current.Session["correo"] = null;
                    System.Web.HttpContext.Current.Session["log"] = false;
                    System.Web.HttpContext.Current.Session["admin"] = false;
                    System.Web.HttpContext.Current.Session["carrito"] = null;
                    SessionClose();
                    return RedirectToAction("log", "Usuario");
                }




               // return RedirectToAction("Index");
                
            }
            catch
            {
                return View();
            }
        }


    }
}
