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
    public class EventoController : BasicController
    {
        // GET: Articulo
        public ActionResult Index()
        {
            EventoCEN cen = new EventoCEN();
            IList<EventoEN> enlinst=cen.ReadAll(0, 6);
            AssemblerEvento ass = new AssemblerEvento();
            IList<Evento> listart = ass.ConvertListENToModel(enlinst);

            //articuloAsembler.covert
            return View(listart);
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int id)
        {
            EventoCEN cen = new EventoCEN();

            EventoEN en = new EventoEN();
            
            en = cen.ReadOID(id);
            AssemblerEvento ass = new AssemblerEvento();
            Evento sol =ass.ConvertENToModelUI(en);
            
            return View(sol);
        }

        // GET: Articulo/Create
        public ActionResult Create()
        {
            EventoEN en = new EventoEN();
            AssemblerEvento ass = new AssemblerEvento();
            Evento sol = ass.ConvertENToModelUI(en);
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
                
                cen.New_(collection.Nombre, collection.Precio, collection.Descripcion, collection.Imagen, (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum)collection.Valoracion, collection.Stock, collection.Tipo);
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

            EventoCEN cen = new EventoCEN();

            EventoEN en = new EventoEN();
            en = cen.ReadOID(id);

            // SessionInitializeTransaction();

            //IProducto productoCAD = new productoCAD(session);

            // ProductoEN en = new Pro;
            AssemblerEvento ass = new AssemblerEvento();
            Evento sol = ass.ConvertENToModelUI(en);
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
                cen.Modify(id, collection.Nombre, collection.Precio, collection.Descripcion, collection.Imagen, (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum)collection.Valoracion, collection.Stock, collection.Tipo);
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

            EventoCEN cen = new EventoCEN();

            EventoEN en = new EventoEN();
            en = cen.ReadOID(id);
            AssemblerEvento ass = new AssemblerEvento();
            Evento sol = ass.ConvertENToModelUI(en);
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
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Articulo/Resultadobusqueda/5
        public ActionResult Resultadobusqueda(IList<Evento> res)
        {
         
           
            
            return View(res);
        }
        // GET: Articulo/Filtrar/5
        ////////////////

        public ActionResult Filtrar()
        {

            FiltroEvento res = new FiltroEvento();


            //articuloAsembler.covert
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
                return View("Resultadobusqueda", listart );
             
            }
            catch
            {

                return View();
            }

        }
       
    }

}
