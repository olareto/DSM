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
    public class CarritoController : BasicController
    {
        // GET: Articulo
        public ActionResult Index()
        {
            CarritoCEN cen = new CarritoCEN();
            IList<CarritoEN> enlinst=cen.ReadAll(0, 6);
            AssemblerCarrito ass = new AssemblerCarrito();
            IList<Carrito> listart = ass.ConvertListENToModel(enlinst);

            //articuloAsembler.covert
            return View(listart);
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int id)
        {
            CarritoCEN cen = new CarritoCEN();

            CarritoEN en = new CarritoEN();
            
            en = cen.ReadOID(id);

            AssemblerCarrito ass = new AssemblerCarrito();
            Carrito sol=ass.ConvertENToModelUI(en);
            ViewData["id_us"] = sol.Usuario;
            return View(sol);
        }

        // GET: Articulo/Create
        public ActionResult Create()
        {
            CarritoEN en = new CarritoEN();
            AssemblerCarrito ass = new AssemblerCarrito();
            Carrito sol = ass.ConvertENToModelUI(en);
            return View(sol);
        }

        // POST: Articulo/Create
        [HttpPost]
        public ActionResult Create(Carrito collection)
        {
            try
            {
                // TODO: Add insert logic here
                CarritoCEN cen = new CarritoCEN();
                
                cen.New_(collection.Usuario, collection.Precio);
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
            
            CarritoCEN cen = new CarritoCEN();

            CarritoEN en = new CarritoEN();
            en = cen.ReadOID(id);

            // SessionInitializeTransaction();

            //IProducto productoCAD = new productoCAD(session);

            // ProductoEN en = new Pro;
            AssemblerCarrito ass = new AssemblerCarrito();
            Carrito sol = ass.ConvertENToModelUI(en);
            ViewData["id_us"] = sol.Usuario;
            return View(sol);
        }

        // POST: Articulo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Carrito collection)
        {
            try
            {
                // TODO: Add update logic here
                CarritoCEN cen = new CarritoCEN();
                cen.Modify(id, collection.Precio);
                //cen.New_(collection.Nombre, collection.Precio, collection.Descripcion, collection.Imagen, collection.Valor, collection.Stock, collection.Talla);
                //return RedirectToAction("Index");
                return RedirectToAction("Details", "Carrito", new { id = id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Articulo/Delete/5
        public ActionResult Delete(int id)
        {

            CarritoCEN cen = new CarritoCEN();

            CarritoEN en = new CarritoEN();
            en = cen.ReadOID(id);
            AssemblerCarrito ass = new AssemblerCarrito();
            Carrito sol = ass.ConvertENToModelUI(en);
            return View(sol);
        }

        // POST: Articulo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                CarritoCEN cen = new CarritoCEN();

                cen.Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
