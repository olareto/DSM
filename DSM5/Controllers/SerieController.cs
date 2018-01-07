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
    public class SerieController : BasicController
    {
        // GET: Articulo
        public ActionResult Index()
        {
            SerieCEN cen = new SerieCEN();
            IList<SerieEN> enlinst=cen.ReadAll(0, int.MaxValue);
            AssemblerSerie ass = new AssemblerSerie();
            IList<Serie> listart = ass.ConvertListENToModel(enlinst);
            int max = listart.Count;
            Random aleatorio = new Random();
            
            int uno = aleatorio.Next(1,max);
            int dos = aleatorio.Next(1, max);
            while (dos==uno)
            {
                dos = aleatorio.Next(1, max);
            }
            int tres = aleatorio.Next(1, max);
            while (dos == tres || uno==tres)
            {
                tres = aleatorio.Next(1, max);
            }

            
            IList<Serie> resu = new List<Serie>();
            resu.Add(listart.ElementAt(uno));
            resu.Add(listart.ElementAt(dos));
            resu.Add(listart.ElementAt(tres));
            ViewBag.serie = resu;

            System.Web.HttpContext.Current.Session["controller"] = "Serie";
            System.Web.HttpContext.Current.Session["action"] = "Index";
            System.Web.HttpContext.Current.Session["arg"] = null;

            return View(listart);

        }

        public ActionResult Index_Usu()
        {
            SerieCEN cen = new SerieCEN();
            IList<SerieEN> enlinst = cen.ReadAll(0, int.MaxValue);
            AssemblerSerie ass = new AssemblerSerie();
            IList<Serie> listart = ass.ConvertListENToModel(enlinst);



            int max = listart.Count;
            Random aleatorio = new Random();

            int uno = aleatorio.Next(1, max);
            int dos = aleatorio.Next(1, max);
            while (dos == uno)
            {
                dos = aleatorio.Next(1, max);
            }
            int tres = aleatorio.Next(1, max);
            while (dos == tres || uno == tres)
            {
                tres = aleatorio.Next(1, max);
            }


            IList<Serie> resu = new List<Serie>();
            resu.Add(listart.ElementAt(uno));
            resu.Add(listart.ElementAt(dos));
            resu.Add(listart.ElementAt(tres));
            ViewBag.serie = resu;


            return View(listart);

        }

        // GET: Articulo/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            SerieCAD cad = new SerieCAD(session);

            SerieCEN cen = new SerieCEN(cad);
            SerieEN en = cen.ReadOID(id);
            
            AssemblerSerie ass = new AssemblerSerie();
            Serie sol =ass.ConvertENToModelUI(en);

            IList<TemporadaEN> ten = en.Temporada;

            AssemblerTemporada assc = new AssemblerTemporada();
            IList<Temporada> solc = assc.ConvertListENToModel(ten);

            SessionClose();

            System.Web.HttpContext.Current.Session["id_serie"] = id;
            ViewBag.temp = solc;

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
                
                cen.New_((SMPGenNHibernate.Enumerated.SMP.ValoracionEnum)collection.Valoracion, collection.Nombre, collection.Imagen, collection.desclar, collection.descripcion, collection.genero, collection.fecha, collection.imagran, collection.fechafin, collection.finalizada);
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
                cen.Modify(id,(SMPGenNHibernate.Enumerated.SMP.ValoracionEnum)collection.Valoracion, collection.Nombre, collection.Imagen, collection.desclar, collection.descripcion, collection.genero, collection.fecha, collection.imagran, collection.fechafin, collection.finalizada);

                //cen.New_(collection.Nombre, collection.Precio, collection.Descripcion, collection.Imagen, collection.Valor, collection.Stock, collection.Talla);
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


                if (!(collection.anyobol == false || collection.anyomin <= 0 || collection.anyomax <= 0 || collection.anyomax <= collection.anyomin))
                {
                    aux = cen.Filtroanyo(collection.anyomin, collection.anyomax);
                    res = res.Intersect(aux).ToList();
                }
                if (collection.Nombrebol == true && collection.Nombre != null)
                {
                    aux = cen.Filtronombre(collection.Nombre);
                    res = res.Intersect(aux).ToList();
                }
                if (collection.generobol == true && collection.genero != null)
                {
                    aux = cen.Filtrogenero(collection.genero);
                    res = res.Intersect(aux).ToList();
                }

                if (collection.Valoracionbol == true && collection.Valoracion > 0 && collection.Valoracion < 6)
                {
                    aux = cen.Filtrovalor((SMPGenNHibernate.Enumerated.SMP.ValoracionEnum)collection.Valoracion);
                    res = res.Intersect(aux).ToList();
                }




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
            //lazy-fetching = false;
            SessionInitialize();
            SerieCAD cad = new SerieCAD(session); 

            SerieCEN cen = new SerieCEN(cad);
            SerieEN en  = cen.ReadOID(id);

            IList<TemporadaEN> ten =en.Temporada;
   
            AssemblerTemporada ass = new AssemblerTemporada();
            IList<Temporada> sol = ass.ConvertListENToModel(ten);

            SessionClose();
       
            System.Web.HttpContext.Current.Session["idserie"] = new { id = id };
            return View(sol);
        }

        // GET: Articulo/Create_temp
        public ActionResult Create_temp(int id)
        {
            TemporadaEN en = new TemporadaEN();
            AssemblerTemporada ass = new AssemblerTemporada();
            Temporada sol = ass.ConvertENToModelUI(en);
            //sol.serie = id;
            return View(sol);
        }

        // POST: Articulo/Create_temp
        [HttpPost]
        public ActionResult Create_temp(int id,Temporada collection)
        {
            try
            {
                TemporadaEN en = new TemporadaEN();
                // TODO: Add insert logic here
                TemporadaCEN cen = new TemporadaCEN();
                cen.New_(id, collection.Nombre);
                //IList<int> resu = new List<int>();
                //resu.Add(temp);
                //resu.Aggregate<int>(temp);
                //SerieCEN cens = new SerieCEN();
                //cens.Addtemporada(id, resu);

                return RedirectToAction("mostrar_temp", "Serie", new { id = id });
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Reproducir(int id)
        {
            SerieCEN cen = new SerieCEN();

            SerieEN en = new SerieEN();

            en = cen.ReadOID(id);
            AssemblerSerie ass = new AssemblerSerie();
            Serie sol = ass.ConvertENToModelUI(en);

            


            return View(sol);
        }

    }
}
