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
    public class SerieController : BasicController
    {
        // GET: Articulo
        public ActionResult Index()
        {
            SerieCEN cen = new SerieCEN();
            IList<SerieEN> enlinst=cen.ReadAll(0, 6);
            AssemblerSerie ass = new AssemblerSerie();
            IList<Serie> listart = ass.ConvertListENToModel(enlinst);

            //articuloAsembler.covert
            return View(listart);
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int id)
        {
            SerieCEN cen = new SerieCEN();

            SerieEN en = new SerieEN();
            
            en = cen.ReadOID(id);
            AssemblerSerie ass = new AssemblerSerie();
            Serie sol =ass.ConvertENToModelUI(en);
            
            return View(sol);
        }

        // GET: Articulo/Create
        public ActionResult Create()
        {
            SerieEN en = new SerieEN();
            AssemblerSerie ass = new AssemblerSerie();
            Serie sol = ass.ConvertENToModelUI(en);
            return View(sol);
        }

        // POST: Articulo/Create
        [HttpPost]
        public ActionResult Create(Serie collection)
        {
            try
            {
                // TODO: Add insert logic here
                SerieCEN cen = new SerieCEN();
                
                cen.New_((SMPGenNHibernate.Enumerated.SMP.ValoracionEnum)collection.Valoracion, collection.Nombre);
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

            SerieCEN cen = new SerieCEN();

            SerieEN en = new SerieEN();
            en = cen.ReadOID(id);

            // SessionInitializeTransaction();

            //IProducto productoCAD = new productoCAD(session);

            // ProductoEN en = new Pro;
            AssemblerSerie ass = new AssemblerSerie();
            Serie sol = ass.ConvertENToModelUI(en);
            return View(sol);
        }

        // POST: Articulo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Serie collection)
        {
            try
            {
                // TODO: Add update logic here
                SerieCEN cen = new SerieCEN();
                cen.Modify(id,(SMPGenNHibernate.Enumerated.SMP.ValoracionEnum)collection.Valoracion, collection.Nombre);
                //cen.New_(collection.Nombre, collection.Precio, collection.Descripcion, collection.Imagen, collection.Valor, collection.Stock, collection.Talla);
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

            SerieCEN cen = new SerieCEN();

            SerieEN en = new SerieEN();
            en = cen.ReadOID(id);
            AssemblerSerie ass = new AssemblerSerie();
            Serie sol = ass.ConvertENToModelUI(en);
            return View(sol);
        }

        // POST: Articulo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                SerieCEN cen = new SerieCEN();

                cen.Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Articulo/Resultadobusqueda/5
        public ActionResult Resultadobusqueda(IList<Serie> res)
        {

      
            return View(res);
        }
        // GET: Articulo/Filtrar/5
        ////////////////

        public ActionResult Filtrar()
        {

            FiltroSerie res = new FiltroSerie();


            //articuloAsembler.covert
            return View(res);
        }
        // POST: Articulo/Filtrar/5
        [HttpPost]
        public ActionResult Filtrar(FiltroSerie collection)
        {
            try
            {
                SerieCEN cen = new SerieCEN();
                IList<SerieEN> res = null, aux = null;
                // TODO: Add delete logic here
                res = cen.ReadAll(0, int.MaxValue);


                AssemblerSerie ass = new AssemblerSerie();
                IList<Serie> listart = ass.ConvertListENToModel(res);
                return View("Resultadobusqueda", listart);

            }
            catch
            {

                return View();
            }


        }




    }
}
