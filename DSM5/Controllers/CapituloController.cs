using DSM5.Models;
using SMPGenNHibernate.CAD.SMP;
using SMPGenNHibernate.CEN.SMP;
using SMPGenNHibernate.EN.SMP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSM5.Controllers
{
    public class CapituloController : BasicController
    {
        // GET: Articulo
        public ActionResult Index()
        {
            CapituloCEN cen = new CapituloCEN();
            IList<CapituloEN> enlinst=cen.ReadAll(0, 6);
            AssemblerCapitulo ass = new AssemblerCapitulo();
            IList<Capitulo> listart = ass.ConvertListENToModel(enlinst);



            System.Web.HttpContext.Current.Session["controller"] = "Capitulo";
            System.Web.HttpContext.Current.Session["action"] = "Index";
            System.Web.HttpContext.Current.Session["arg"] = null;

            //articuloAsembler.covert
            return View(listart);
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int id)
        {




            SessionInitialize();
            CapituloCAD cad = new CapituloCAD(session);

            CapituloCEN cen = new CapituloCEN(cad);
            CapituloEN en = cen.ReadOID(id);

            AssemblerCapitulo ass = new AssemblerCapitulo();
            Capitulo sol = ass.ConvertENToModelUI(en);


            IList<ComentarioEN> ten = en.Comentario;

            AssemblerComentario assc = new AssemblerComentario();
            IList<Comentario> solc = assc.ConvertListENToModel(ten);

            SessionClose();
            ViewData["id_serie"] = id;

            ViewData["controller"] = System.Web.HttpContext.Current.Session["controller"] as String;
            ViewData["action"] = System.Web.HttpContext.Current.Session["action"] as String;
            ViewData["arg"] = System.Web.HttpContext.Current.Session["arg"];
            ViewBag.coment = solc;












            return View(sol);
        }

        // GET: Articulo/Create
        public ActionResult Create(int id)
        {
            CapituloEN en = new CapituloEN();
            AssemblerCapitulo ass = new AssemblerCapitulo();
            Capitulo sol = ass.ConvertENToModelUI(en);
           
            ViewData["controller"] = System.Web.HttpContext.Current.Session["controller"] as String;
            ViewData["action"] = System.Web.HttpContext.Current.Session["action"] as String;
            ViewData["arg"] = System.Web.HttpContext.Current.Session["arg"];
            sol.id = id;
            return View(sol);
        }

        // POST: Articulo/Create
        [HttpPost]
        public ActionResult Create(int id, Capitulo collection)
        {
            try
            {
                // TODO: Add insert logic here
                CapituloCEN cen = new CapituloCEN();
                

        

                cen.New_(id, collection.Nombre,new DateTime (collection.fecha.Year, collection.fecha.Month, collection.fecha.Day), collection.descripcion, collection.imagen);

                string action = System.Web.HttpContext.Current.Session["action"] as String;
                string controller = System.Web.HttpContext.Current.Session["controller"] as String;
                Object arg = System.Web.HttpContext.Current.Session["arg"];


                return RedirectToAction(action, controller, arg);
            }
            catch
            {
                return View();
            }
        }
        
        
        
        // GET: Articulo/Edit/5
        public ActionResult Edit( int id)
        {

            CapituloCEN cen = new CapituloCEN();

            CapituloEN en = new CapituloEN();
            en = cen.ReadOID(id);

            // SessionInitializeTransaction();

            //IProducto productoCAD = new productoCAD(session);

            // ProductoEN en = new Pro;
            AssemblerCapitulo ass = new AssemblerCapitulo();
            Capitulo sol = ass.ConvertENToModelUI(en);
            ViewData["controller"] = System.Web.HttpContext.Current.Session["controller"] as String;
            ViewData["action"] = System.Web.HttpContext.Current.Session["action"] as String;
            ViewData["arg"] = System.Web.HttpContext.Current.Session["arg"];

            return View(sol);
        }

        // POST: Articulo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Capitulo collection)
        {
            try
            {
                // TODO: Add update logic here

                CapituloCEN cen = new CapituloCEN();

            
                cen.Modify(collection.id, collection.Nombre, new DateTime(collection.fecha.Year, collection.fecha.Month, collection.fecha.Day), collection.descripcion, collection.imagen);
                //cen.New_(collection.Nombre, collection.Precio, collection.Descripcion, collection.Imagen, collection.Valor, collection.Stock, collection.Talla);
                //return RedirectToAction("Index");
                

                string action = System.Web.HttpContext.Current.Session["action"] as String;
                string controller = System.Web.HttpContext.Current.Session["controller"] as String;
                Object arg = System.Web.HttpContext.Current.Session["arg"];


                return RedirectToAction(action, controller, arg);

            }
            catch
            {
                return View();
            }
        }

        // GET: Articulo/Delete/5
        public ActionResult Delete(int id)
        {

            CapituloCEN cen = new CapituloCEN();

            CapituloEN en = new CapituloEN();
            en = cen.ReadOID(id);
            AssemblerCapitulo ass = new AssemblerCapitulo();
            Capitulo sol = ass.ConvertENToModelUI(en);
            ViewData["controller"] = System.Web.HttpContext.Current.Session["controller"] as String;
            ViewData["action"] = System.Web.HttpContext.Current.Session["action"] as String;
            ViewData["arg"] = System.Web.HttpContext.Current.Session["arg"];
            return View(sol);
        }

        // POST: Articulo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                CapituloCEN cen = new CapituloCEN();
               
                cen.Destroy(id);
                string action = System.Web.HttpContext.Current.Session["action"] as String;
                string controller = System.Web.HttpContext.Current.Session["controller"] as String;
                Object arg = System.Web.HttpContext.Current.Session["arg"];


                return RedirectToAction(action, controller, arg);
            }
            catch
            {
                return View();
            }
        }



      


    }
}
