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
    public class TemporadaController : BasicController
    {
        // GET: Articulo
        public ActionResult Index()
        {
            TemporadaCEN cen = new TemporadaCEN();
            IList<TemporadaEN> enlinst=cen.ReadAll(0, 6);
            AssemblerTemporada ass = new AssemblerTemporada();
            IList<Temporada> listart = ass.ConvertListENToModel(enlinst);

            //articuloAsembler.covert
            return View(listart);
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int id)
        {
            TemporadaCEN cen = new TemporadaCEN();

            TemporadaEN en = new TemporadaEN();
            
            en = cen.ReadOID(id);
            AssemblerTemporada ass = new AssemblerTemporada();
            Temporada sol =ass.ConvertENToModelUI(en);
            
            return View(sol);
        }

        // GET: Articulo/Create
        public ActionResult Create()
        {
            TemporadaEN en = new TemporadaEN();
            AssemblerTemporada ass = new AssemblerTemporada();
            Temporada sol = ass.ConvertENToModelUI(en);
            return View(sol);
        }

        // POST: Articulo/Create
        [HttpPost]
        public ActionResult Create(Temporada collection)
        {
            try
            {
                // TODO: Add insert logic here
                TemporadaCEN cen = new TemporadaCEN();
                
                cen.New_(327680,collection.Nombre);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
         // GET: Articulo/show/5
        public ActionResult show()
        {
            
            SerieCEN cen = new SerieCEN();
            SerieEN en = cen.ReadOID(327680);
           // Session session = SessionFactoryHelper.getSessionFactory().getCurrentSession();
          
            IList<TemporadaEN> ten = en.Temporada;
            //if (ten == null)
            //{
            //  ten = new List<TemporadaEN>();
            //}

            AssemblerTemporada ass = new AssemblerTemporada();
            IList<Temporada> sol = ass.ConvertListENToModel(ten);

            return View(sol);


         
        }
        // GET: Articulo/Edit/5
        public ActionResult Edit(int id)
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
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Articulo/Resultadobusqueda/5
        public ActionResult Resultadobusqueda(IList<Temporada> res)
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
        // GET: Articulo/mostrar_temp/5
        public ActionResult mostrar_temp(int id)
        {
            SerieCEN cen = new SerieCEN();

            SerieEN en = new SerieEN();
            IList<TemporadaEN> ten; 

            en = cen.ReadOID(id);
            ten =en.Temporada;


            AssemblerTemporada ass = new AssemblerTemporada();

            IList<Temporada> sol = ass.ConvertListENToModel(ten);

            return View(sol);
        }

        // GET: Articulo/Create_temp
        public ActionResult Create_temp(int id)
        {
            TemporadaEN en = new TemporadaEN();
            SerieCEN cens = new SerieCEN();

            en.Serie = cens.ReadOID(id);
           
            AssemblerTemporada ass = new AssemblerTemporada();
            Temporada sol = ass.ConvertENToModelUI(en);
            //sol.serie = id;
            return View(sol);
        }

        // POST: Articulo/Create_temp
        [HttpPost]
        public ActionResult Create_temp(Temporada collection)
        {
            try
            {

                TemporadaEN en = new TemporadaEN();
                SerieCEN cens = new SerieCEN();


                // TODO: Add insert logic here
                TemporadaCEN cen = new TemporadaCEN();
                int temp=cen.New_(collection.id, collection.Nombre);
                IList<int> resu = new List<int>();
                resu.Add(temp);
                //resu.Aggregate<int>(temp);
                cens.Addtemporada(collection.id, resu);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
