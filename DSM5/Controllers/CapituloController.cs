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

            //articuloAsembler.covert
            return View(listart);
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int id)
        {


            CapituloCEN cen = new CapituloCEN();

            CapituloEN en = new CapituloEN();
            
            en = cen.ReadOID(id);
            AssemblerCapitulo ass = new AssemblerCapitulo();
            Capitulo sol =ass.ConvertENToModelUI(en);
           
            return View(sol);
        }

        // GET: Articulo/Create
        public ActionResult Create(int id)
        {
            CapituloEN en = new CapituloEN();
            AssemblerCapitulo ass = new AssemblerCapitulo();
            Capitulo sol = ass.ConvertENToModelUI(en);
            ViewData["id_serie"] = id;
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
                
                cen.New_(id, collection.Nombre,(DateTime) collection.fecha, collection.descripcion, collection.imagen);
                return RedirectToAction("mostrar_cap", "Temporada", new { id = id });
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

                CapituloEN en = new CapituloEN();
                en = cen.ReadOID(id);
                AssemblerCapitulo ass = new AssemblerCapitulo();
                Capitulo sol = ass.ConvertENToModelUI(en);
                cen.Modify(collection.id, collection.Nombre, collection.fecha, collection.descripcion, collection.imagen);
                //cen.New_(collection.Nombre, collection.Precio, collection.Descripcion, collection.Imagen, collection.Valor, collection.Stock, collection.Talla);
                //return RedirectToAction("Index");
                int idbueno = sol.serie;
                
                return RedirectToAction("mostrar_cap", "Temporada", new {id= idbueno } );
                
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
                CapituloEN en = new CapituloEN();
                en = cen.ReadOID(id);
                AssemblerCapitulo ass = new AssemblerCapitulo();
                Capitulo sol = ass.ConvertENToModelUI(en);
                int idbueno = sol.serie;
                cen.Destroy(id);
                return RedirectToAction("mostrar_cap", "Temporada", new { id = idbueno });
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
            ViewData["id_serie"] = id;
            return View(sol);
        }

      


    }
}
