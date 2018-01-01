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
    public class PeliculaController : BasicController
    {
        // GET: Pelicula
        public ActionResult Index()
        {
            PeliculaCEN cen = new PeliculaCEN();
            IList<PeliculaEN> enlinst = cen.ReadAll(0, 12);
            AssemblerPelicula ass = new AssemblerPelicula();
            IList<Pelicula> listart = ass.ConvertListENToModel(enlinst);

            System.Web.HttpContext.Current.Session["controller"] = "Pelicula";
            System.Web.HttpContext.Current.Session["action"] = "Index";
            System.Web.HttpContext.Current.Session["arg"] = null;
            //articuloAsembler.covert

            return View(listart);
        }

        // GET: Pelicula/Details/5
        public ActionResult Details(int id)
        {

            SessionInitialize();
            PeliculaCAD cad = new PeliculaCAD(session);

            PeliculaCEN cen = new PeliculaCEN(cad);
            PeliculaEN en = cen.ReadOID(id);

            AssemblerPelicula ass = new AssemblerPelicula();
            Pelicula sol = ass.ConvertENToModelUI(en);


            IList<ComentarioEN> ten = en.Comentario;

            AssemblerComentario assc = new AssemblerComentario();
            IList<Comentario> solc = assc.ConvertListENToModel(ten);

            SessionClose();
            ViewData["controller"] = System.Web.HttpContext.Current.Session["controller"] as String;
            ViewData["action"] = System.Web.HttpContext.Current.Session["action"] as String;
            ViewData["arg"] = System.Web.HttpContext.Current.Session["arg"];
            ViewData["id_serie"] = id;
            // ViewData["action"] = "Details";
            ViewBag.coment = solc;
            return View(sol);

        }

        // GET: Pelicula/Create
        public ActionResult Create()
        {
            PeliculaEN en = new PeliculaEN();
            AssemblerPelicula ass = new AssemblerPelicula();
            Pelicula sol = ass.ConvertENToModelUI(en);
            ViewData["controller"] = System.Web.HttpContext.Current.Session["controller"] as String;
            ViewData["action"] = System.Web.HttpContext.Current.Session["action"] as String;
            ViewData["arg"] = System.Web.HttpContext.Current.Session["arg"];
            return View(sol);
           
        }

        // POST: Pelicula/Create
        [HttpPost]
        public ActionResult Create(Pelicula collection)
        {
            try
            {
                // TODO: Add insert logic here
                PeliculaCEN cen = new PeliculaCEN();

                cen.New_((SMPGenNHibernate.Enumerated.SMP.ValoracionEnum)collection.Valoracion, collection.Nombre, collection.Imagen);

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

        // GET: Pelicula/Edit/5
        public ActionResult Edit(int id)
        {
            PeliculaCEN cen = new PeliculaCEN();

            PeliculaEN en = new PeliculaEN();
            en = cen.ReadOID(id);

            // SessionInitializeTransaction();

            //IProducto productoCAD = new productoCAD(session);

            // ProductoEN en = new Pro;
            AssemblerPelicula ass = new AssemblerPelicula();
            Pelicula sol = ass.ConvertENToModelUI(en);
            ViewData["controller"] = System.Web.HttpContext.Current.Session["controller"] as String;
            ViewData["action"] = System.Web.HttpContext.Current.Session["action"] as String;
            ViewData["arg"] = System.Web.HttpContext.Current.Session["arg"];
            return View(sol);
        }

        // POST: Pelicula/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Pelicula collection)
        {
            try
            {

                // TODO: Add update logic here
                PeliculaCEN cen = new PeliculaCEN();

                cen.New_((SMPGenNHibernate.Enumerated.SMP.ValoracionEnum)collection.Valoracion, collection.Nombre, collection.Imagen);

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

        // GET: Pelicula/Delete/5
        public ActionResult Delete(int id)
        {
            PeliculaCEN cen = new PeliculaCEN();

            PeliculaEN en = new PeliculaEN();
            en = cen.ReadOID(id);
            AssemblerPelicula ass = new AssemblerPelicula();
            Pelicula sol = ass.ConvertENToModelUI(en);
            ViewData["controller"] = System.Web.HttpContext.Current.Session["controller"] as String;
            ViewData["action"] = System.Web.HttpContext.Current.Session["action"] as String;
            ViewData["arg"] = System.Web.HttpContext.Current.Session["arg"];
            return View(sol);
        }

        // POST: Pelicula/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Pelicula collection)
        {
            try
            {
                // TODO: Add delete logic here
                PeliculaCEN cen = new PeliculaCEN();

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
        // GET: Articulo/Resultadobusqueda/5
        public ActionResult Resultadobusqueda(IList<Pelicula> res)
        {


            return View(res);
        }
        // GET: Articulo/Filtrar/5
        ////////////////

        public ActionResult Filtrar()
        {

            FiltroPelicula res = new FiltroPelicula();


            //articuloAsembler.covert
            return View(res);
        }
        // POST: Articulo/Filtrar/5
        [HttpPost]
        public ActionResult Filtrar(FiltroPelicula collection)
        {
            try
            {
                PeliculaCEN cen = new PeliculaCEN();
                IList<PeliculaEN> res = null, aux = null;
                // TODO: Add delete logic here
                res = cen.ReadAll(0, int.MaxValue);


                AssemblerPelicula ass = new AssemblerPelicula();
                IList<Pelicula> listart = ass.ConvertListENToModel(res);
                return View("Resultadobusqueda", listart);

            }
            catch
            {

                return View();
            }


        }
    }
}
