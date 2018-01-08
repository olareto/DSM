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
    public class TemporadaController : BasicController
    {
        // GET: Articulo
        public ActionResult Index()
        {
            TemporadaCEN cen = new TemporadaCEN();
            IList<TemporadaEN> enlinst=cen.ReadAll(0, int.MaxValue);
            AssemblerTemporada ass = new AssemblerTemporada();
            IList<Temporada> listart = ass.ConvertListENToModel(enlinst);

            System.Web.HttpContext.Current.Session["controller2"] = "Temporada";
            System.Web.HttpContext.Current.Session["action2"] = "Index";
            System.Web.HttpContext.Current.Session["arg2"] = null;

            //articuloAsembler.covert
            return View(listart);
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int id)
        {

             
            TemporadaCEN cen = new TemporadaCEN();

            TemporadaEN en = new TemporadaEN();
            System.Web.HttpContext.Current.Session["idtemp"]=id;
            en = cen.ReadOID(id);
            AssemblerTemporada ass = new AssemblerTemporada();
            Temporada sol =ass.ConvertENToModelUI(en);

            

            return View(sol);
        }

        // GET: Articulo/Create
        public ActionResult Create(int id)
        {
            TemporadaEN en = new TemporadaEN();
            AssemblerTemporada ass = new AssemblerTemporada();
            Temporada sol = ass.ConvertENToModelUI(en);
           
            return View(sol);
        }

        // POST: Articulo/Create
        [HttpPost]
        public ActionResult Create(int id,Temporada collection)
        {
            try
            {
                // TODO: Add insert logic here
                TemporadaCEN cen = new TemporadaCEN();
                
                cen.New_(id, collection.Nombre);
                string action = "Details";
                string controller = "Serie";
                int arg = (int)System.Web.HttpContext.Current.Session["id_serie"];


                return RedirectToAction(action, controller, new { id= arg });
            }
            catch
            {
                return View();
            }
        }
        
        
        
        // GET: Articulo/Edit/5
        public ActionResult Edit( int id)
        {

            TemporadaCEN cen = new TemporadaCEN();

            TemporadaEN en = new TemporadaEN();
            en = cen.ReadOID(id);

            // SessionInitializeTransaction();

            //IProducto productoCAD = new productoCAD(session);

            // ProductoEN en = new Pro;
            AssemblerTemporada ass = new AssemblerTemporada();
            Temporada sol = ass.ConvertENToModelUI(en);
            
            return View(sol);
        }

        // POST: Articulo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Temporada collection)
        {
            try
            {
                // TODO: Add update logic here

                TemporadaCEN cen = new TemporadaCEN();

               
                
                
                cen.Modify(collection.id,collection.Nombre);
                //cen.New_(collection.Nombre, collection.Precio, collection.Descripcion, collection.Imagen, collection.Valor, collection.Stock, collection.Talla);
                //return RedirectToAction("Index");

                string action = "Details";
                string controller = "Serie";
                int arg = (int)System.Web.HttpContext.Current.Session["id_serie"];


                return RedirectToAction(action, controller, new { id = arg });

            }
            catch
            {
                return View();
            }
        }

        // GET: Articulo/Delete/5
        public ActionResult Delete(int id)
        {

            TemporadaCEN cen = new TemporadaCEN();

            TemporadaEN en = new TemporadaEN();
            en = cen.ReadOID(id);
            AssemblerTemporada ass = new AssemblerTemporada();
            Temporada sol = ass.ConvertENToModelUI(en);
           
            return View(sol);
        }

        // POST: Articulo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                TemporadaCEN cen = new TemporadaCEN();
               
                cen.Destroy(id);
                string action = "Details";
                string controller = "Serie";
                int arg = (int)System.Web.HttpContext.Current.Session["id_serie"];


                return RedirectToAction(action, controller, new { id = arg });
            }
            catch
            {
                return View();
            }
        }


        // GET: Articulo/mostrar_cap/5
        public ActionResult mostrar_cap(int id)
        {
            //lazy-fetching = false;
            SessionInitialize();
            TemporadaCAD cad = new TemporadaCAD(session);

            TemporadaCEN cen = new TemporadaCEN(cad);
            TemporadaEN en = cen.ReadOID(id);

            IList<CapituloEN> ten = en.Capitulo;

            AssemblerCapitulo ass = new AssemblerCapitulo();
            IList<Capitulo> sol = ass.ConvertListENToModel(ten);

            SessionClose();
           

            System.Web.HttpContext.Current.Session["idtemp"] = id;


            return View(sol);
        }

      


    }
}
