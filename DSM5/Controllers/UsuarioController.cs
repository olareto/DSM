using DSM5.Models;
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


                System.Web.HttpContext.Current.Session["usuario"] = null;
               // System.Web.HttpContext.Current.Session["correo"] = ad.Email;
                System.Web.HttpContext.Current.Session["log"] = false;
                System.Web.HttpContext.Current.Session["admin"] = false;

                ViewData["correo"] = System.Web.HttpContext.Current.Session["correo"] as string;
                ViewData["log"] = (Boolean)System.Web.HttpContext.Current.Session["log"];
                ViewData["admin"] = (Boolean)System.Web.HttpContext.Current.Session["admin"];


                return RedirectToAction("Details", "Usuario", new { id=hola });
            }
            UsuarioCEN cen = new UsuarioCEN();
            IList<UsuarioEN> enlinst=cen.ReadAll(0, 6);
            AssemblerUsuario ass = new AssemblerUsuario();
            IList<Usuario> listart = ass.ConvertListENToModel(enlinst);

            //articuloAsembler.covert
            return View(listart);
        }

        // GET: Articulo/Details/5
        public ActionResult Details(string id)
        {
            UsuarioCEN cen = new UsuarioCEN();

            UsuarioEN en = new UsuarioEN();
            
            en = cen.ReadOID(id);

            // CarritoCEN cenc = new CarritoCEN();
            //CarritoEN enc = new CarritoEN();
            //enc = en.Carrito;
           
            AssemblerUsuario ass = new AssemblerUsuario();
            Usuario sol =ass.ConvertENToModelUI(en);
            

            return View(sol);
        }

        // GET: Articulo/Create
        public ActionResult Create()
        {
            UsuarioEN en = new UsuarioEN();
            AssemblerUsuario ass = new AssemblerUsuario();
            Usuario sol = ass.ConvertENToModelUI(en);
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

        // GET: Articulo/Edit/5
        public ActionResult Edit(string id)
        {

            UsuarioCEN cen = new UsuarioCEN();

            UsuarioEN en = new UsuarioEN();
            en = cen.ReadOID(id);

            // SessionInitializeTransaction();

            //IProducto productoCAD = new productoCAD(session);

            // ProductoEN en = new Pro;
            AssemblerUsuario ass = new AssemblerUsuario();
            Usuario sol = ass.ConvertENToModelUI(en);
           
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

            UsuarioCEN cen = new UsuarioCEN();

            UsuarioEN en = new UsuarioEN();
            en = cen.ReadOID(id);
            AssemblerUsuario ass = new AssemblerUsuario();
            Usuario sol = ass.ConvertENToModelUI(en);
            return View(sol);
        }

        // POST: Articulo/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                UsuarioCEN cen = new UsuarioCEN();

                cen.Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Articulo/Resultadobusqueda/5
        public ActionResult Resultadobusqueda(IList<Usuario> res)
        {

      
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
                UsuarioCEN cen = new UsuarioCEN();
                IList<UsuarioEN> res = null, aux = null;
                // TODO: Add delete logic here
                res = cen.ReadAll(0, int.MaxValue);

                
                if (collection.Nombrebol == true && collection.Nombre != null)
                {
                    //aux = cen.Filtronombre(collection.Nombre);
                    //res = res.Intersect(aux).ToList();
                }
                
                AssemblerUsuario ass = new AssemblerUsuario();
                IList<Usuario> listart = ass.ConvertListENToModel(res);
                return View("Resultadobusqueda", listart);

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
            return RedirectToAction("Index", "Usuario");
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
                // TODO: Add insert logic here
                UsuarioCEN cen = new UsuarioCEN();
                UsuarioEN en = new UsuarioEN();
                AssemblerUsuario ass = new AssemblerUsuario();
                Usuario us;

                AdminCEN cena = new AdminCEN();
                AdminEN ena = new AdminEN();
                AssemblerAdmin assa = new AssemblerAdmin();
                Admin ad;

                if (cen.Login(collection.email, collection.Password)){
                    en = cen.ReadOID(collection.email);
                    us = ass.ConvertENToModelUI(en);


                    System.Web.HttpContext.Current.Session["usuario"] = us;
                    System.Web.HttpContext.Current.Session["correo"] = us.Email;
                    System.Web.HttpContext.Current.Session["log"] = true;
                    System.Web.HttpContext.Current.Session["admin"] = false;


                    return RedirectToAction("Details", "Usuario", new { id = collection.Password});

                }
                else if(cena.Login(collection.email, collection.Password))
                {
                    ena = cena.ReadOID(collection.email);
                    ad = assa.ConvertENToModelUI(ena);

                    System.Web.HttpContext.Current.Session["usuario"] = ad;
                    System.Web.HttpContext.Current.Session["correo"] = ad.Email;
                    System.Web.HttpContext.Current.Session["log"] = true;
                    System.Web.HttpContext.Current.Session["admin"] = true;

                    return RedirectToAction("Details", "Usuario", new { id = collection.Password });
                }
                else
                {
                    System.Web.HttpContext.Current.Session["usuario"] = null;
                    System.Web.HttpContext.Current.Session["correo"] = null;
                    System.Web.HttpContext.Current.Session["log"] = false;
                    System.Web.HttpContext.Current.Session["admin"] = false;
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
