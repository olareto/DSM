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
    public class EventoController : BasicController
    {
        // GET: Articulo
        public ActionResult Index()
        {
            EventoCEN cen = new EventoCEN();
            IList<EventoEN> enlinst=cen.ReadAll(0, int.MaxValue);
            AssemblerEvento ass = new AssemblerEvento();
            IList<Evento> listart = ass.ConvertListENToModel(enlinst);

            //articuloAsembler.covert

            System.Web.HttpContext.Current.Session["controller"] = "Evento";
            System.Web.HttpContext.Current.Session["action"] = "Index";
            System.Web.HttpContext.Current.Session["arg"] = null;
            return View(listart);
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            EventoCAD cad = new EventoCAD(session);

            EventoCEN cen = new EventoCEN(cad);
            EventoEN en = cen.ReadOID(id);

            AssemblerEvento ass = new AssemblerEvento();
            Evento sol = ass.ConvertENToModelUI(en);


            IList<ComentarioEN> ten = en.Comentario;

            AssemblerComentario assc = new AssemblerComentario();
            IList<Comentario> solc = assc.ConvertListENToModel(ten);

            SessionClose();
         
            // ViewData["action"] = "Details";
            ViewBag.coment = solc;

            System.Web.HttpContext.Current.Session["comen"] = id;


            return View(sol);
        }

        // GET: Articulo/Create
        public ActionResult Create()
        {
            EventoEN en = new EventoEN();
            AssemblerEvento ass = new AssemblerEvento();
            Evento sol = ass.ConvertENToModelUI(en);

            ViewData["controller"] = System.Web.HttpContext.Current.Session["controller"] as String;
            ViewData["action"] = System.Web.HttpContext.Current.Session["action"] as String;
            ViewData["arg"] = System.Web.HttpContext.Current.Session["arg"];


            return View(sol);
        }

        // POST: Articulo/Create
        [HttpPost]
        public ActionResult Create(Evento collection)
        {
            try
            {
                // TODO: Add insert logic here
                EventoCEN cen = new EventoCEN();
                
                cen.New_(collection.Nombre, collection.Precio, collection.Descripcion, collection.Imagen, (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum)collection.Valoracion, collection.Stock, collection.descriplarga, collection.imagran, collection.Tipo);
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

            EventoCEN cen = new EventoCEN();

            EventoEN en = new EventoEN();
            en = cen.ReadOID(id);

            // SessionInitializeTransaction();

            //IProducto productoCAD = new productoCAD(session);

            // ProductoEN en = new Pro;
            AssemblerEvento ass = new AssemblerEvento();
            Evento sol = ass.ConvertENToModelUI(en);

            ViewData["controller"] = System.Web.HttpContext.Current.Session["controller"] as String;
            ViewData["action"] = System.Web.HttpContext.Current.Session["action"] as String;
            ViewData["arg"] = System.Web.HttpContext.Current.Session["arg"];


            return View(sol);
        }

        // POST: Articulo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Evento collection)
        {
            try
            {
                // TODO: Add update logic here
                EventoCEN cen = new EventoCEN();

                EventoEN en = cen.get_IEventoCAD().ReadOIDDefault(id);




                cen.Modify(id,collection.Nombre, collection.Precio, collection.Descripcion, collection.Imagen, (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum)collection.Valoracion, collection.Stock, collection.descriplarga, collection.imagran, collection.Tipo);

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

            EventoCEN cen = new EventoCEN();

            EventoEN en = new EventoEN();
            en = cen.ReadOID(id);
            AssemblerEvento ass = new AssemblerEvento();
            Evento sol = ass.ConvertENToModelUI(en);
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
                EventoCEN cen = new EventoCEN();

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
        public ActionResult Resultadobusqueda()
        {

            System.Web.HttpContext.Current.Session["controller"] = "Evento";
            System.Web.HttpContext.Current.Session["action"] = "Resultadobusqueda";
            System.Web.HttpContext.Current.Session["arg"] = null;

            IList<Evento> res = System.Web.HttpContext.Current.Session["resu"] as IList<Evento>;
            if (res == null)
            {
                res = new List<Evento>();
            }
            ViewData["controller"] = System.Web.HttpContext.Current.Session["controller"] as String;
            ViewData["action"] = System.Web.HttpContext.Current.Session["action"] as String;
            ViewData["arg"] = System.Web.HttpContext.Current.Session["arg"];

            return View(res);
        }
        // GET: Articulo/Filtrar/5
        ////////////////

        public ActionResult Filtrar()
        {

            FiltroEvento res = new FiltroEvento();


            //articuloAsembler.covert
            ViewData["controller"] = System.Web.HttpContext.Current.Session["controller"] as String;
            ViewData["action"] = System.Web.HttpContext.Current.Session["action"] as String;
            ViewData["arg"] = System.Web.HttpContext.Current.Session["arg"];
            return View(res);
        }

        // POST: Articulo/Filtrar/5
        [HttpPost]
        public ActionResult Filtrar(FiltroEvento collection)
        {
            try
            {
                EventoCEN cen = new EventoCEN();
                IList<EventoEN> res = null, aux = null;
                // TODO: Add delete logic here
                res = cen.ReadAll(0, int.MaxValue);

                if (!(collection.Preciobol == false || collection.Preciomin <= 0 || collection.Preciomax <= 0 || collection.Preciomax <= collection.Preciomin))
                {
                    aux = cen.Filtroprecio(collection.Preciomin, collection.Preciomax);
                    res = res.Intersect(aux).ToList();
                }
                if (collection.Nombrebol == true && collection.Nombre != null)
                {
                    aux = cen.Filtronombre(collection.Nombre);
                    res = res.Intersect(aux).ToList();
                }
                if (collection.Tipobol == true && collection.Tipo != null)
                {
                    aux = cen.Filtrotipo(collection.Tipo);
                    res = res.Intersect(aux).ToList();
                }

                if (collection.Valoracionbol == true && collection.Valoracion > 0 && collection.Valoracion < 6)
                {
                    aux = cen.Filtrovalor((SMPGenNHibernate.Enumerated.SMP.ValoracionEnum)collection.Valoracion);
                    res = res.Intersect(aux).ToList();
                }
                AssemblerEvento ass = new AssemblerEvento();
                IList<Evento> listart = ass.ConvertListENToModel(res);

                System.Web.HttpContext.Current.Session["resu"] = listart;
                return RedirectToAction("Resultadobusqueda", "Evento", null);


            }
            catch
            {

                return View();
            }

        }
       
    }

}
