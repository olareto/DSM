using DSM5.Models;
using SMPGenNHibernate.CEN.SMP;
using SMPGenNHibernate.EN.SMP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSM5.Controllers
{
    public class ArticuloController : BasicController
    {
        // GET: Articulo
        public ActionResult Index()
        {
            ArticuloCEN cen = new ArticuloCEN();
            IList<ArticuloEN> enlinst=cen.ReadAll(0, 6);
            AssemblerArticulo ass = new AssemblerArticulo();
            IList<Articulo> listart = ass.ConvertListENToModel(enlinst);

            //articuloAsembler.covert
            return View(listart);
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Articulo/Create
        public ActionResult Create()
        {
            ArticuloEN en = new ArticuloEN();

            return View(en);
        }

        // POST: Articulo/Create
        [HttpPost]
        public ActionResult Create(ArticuloEN collection)
        {
            try
            {
                // TODO: Add insert logic here
                ArticuloCEN cen = new ArticuloCEN();
                cen.New_(collection.Nombre, collection.Precio, collection.Descripcion, collection.Imagen, collection.Valor, collection.Stock);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Articulo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Articulo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Articulo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Articulo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
