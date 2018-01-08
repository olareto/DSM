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
            IList<CapituloEN> enlinst=cen.ReadAll(0, int.MaxValue);
            AssemblerCapitulo ass = new AssemblerCapitulo();
            IList<Capitulo> listart = ass.ConvertListENToModel(enlinst);



            System.Web.HttpContext.Current.Session["controller2"] = "Capitulo";
            System.Web.HttpContext.Current.Session["action2"] = "Index";
            System.Web.HttpContext.Current.Session["arg2"] = null;

            //articuloAsembler.covert
            return View(listart);
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int id)
        {


            System.Web.HttpContext.Current.Session["comen"] = id;

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
           
            ViewBag.coment = solc;
            return View(sol);
        }

        // GET: Articulo/Create
        public ActionResult Create(int id)
        {
            CapituloEN en = new CapituloEN();
            AssemblerCapitulo ass = new AssemblerCapitulo();
            Capitulo sol = ass.ConvertENToModelUI(en);

           
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
                

        

                cen.New_(id, collection.Nombre,new DateTime (collection.fecha.Year, collection.fecha.Month, collection.fecha.Day), collection.descripcion, collection.imagen, collection.link);

                string action = "mostrar_cap";
                string controller = "Temporada";
                Object arg = System.Web.HttpContext.Current.Session["idtemp"];


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

            
                cen.Modify(collection.id, collection.Nombre, new DateTime(collection.fecha.Year, collection.fecha.Month, collection.fecha.Day), collection.descripcion, collection.imagen, collection.link);
                //cen.New_(collection.Nombre, collection.Precio, collection.Descripcion, collection.Imagen, collection.Valor, collection.Stock, collection.Talla);
                //return RedirectToAction("Index");


                string action = "mostrar_cap";
                string controller = "Temporada";
                Object arg = System.Web.HttpContext.Current.Session["idtemp"];


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
                string action = "mostrar_cap";
                string controller = "Temporada";
                Object arg = System.Web.HttpContext.Current.Session["idtemp"];


                return RedirectToAction(action, controller, arg);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Reproducir(int id)
        {
            CapituloCEN cen = new CapituloCEN();

            CapituloEN en = new CapituloEN();

            en = cen.ReadOID(id);
            AssemblerCapitulo ass = new AssemblerCapitulo();
            Capitulo sol = ass.ConvertENToModelUI(en);




            return View(sol);
        }




    }
}
