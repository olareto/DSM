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
    public class PeliculaController : BasicController
    {
        // GET: Pelicula
        public ActionResult Index()
        {
            PeliculaCEN cen = new PeliculaCEN();
            IList<PeliculaEN> enlinst = cen.ReadAll(0, 6);
            AssemblerPelicula ass = new AssemblerPelicula();
            IList<Pelicula> listart = ass.ConvertListENToModel(enlinst);

            //articuloAsembler.covert
            
            return View(listart);
        }

        // GET: Pelicula/Details/5
        public ActionResult Details(int id)
        {
            PeliculaCEN cen = new PeliculaCEN();

            PeliculaEN en = new PeliculaEN();

            en = cen.ReadOID(id);
            AssemblerPelicula ass = new AssemblerPelicula();
            Pelicula sol = ass.ConvertENToModelUI(en);

            return View(sol);
           
        }

        // GET: Pelicula/Create
        public ActionResult Create()
        {
            PeliculaEN en = new PeliculaEN();
            AssemblerPelicula ass = new AssemblerPelicula();
            Pelicula sol = ass.ConvertENToModelUI(en);
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

                return RedirectToAction("Index");
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

                return RedirectToAction("Index");
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

                return RedirectToAction("Index");
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
