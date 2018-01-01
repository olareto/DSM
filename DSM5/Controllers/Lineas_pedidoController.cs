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
    public class Lineas_pedidoController : BasicController
    {
        // GET: Articulo
        public ActionResult Index()
        {
            Lineas_pedidoCEN cen = new Lineas_pedidoCEN();
            IList<Lineas_pedidoEN> enlinst=cen.ReadAll(0, 6);
            AssemblerLineas_pedido ass = new AssemblerLineas_pedido();
            IList<Lineas_pedido> listart = ass.ConvertListENToModel(enlinst);

            //articuloAsembler.covert
            return View(listart);
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int id)
        {
            Lineas_pedidoCEN cen = new Lineas_pedidoCEN();

            Lineas_pedidoEN en = new Lineas_pedidoEN();
            
            en = cen.ReadOID(id);

            AssemblerLineas_pedido ass = new AssemblerLineas_pedido();
            Lineas_pedido sol =ass.ConvertENToModelUI(en);
            //ViewData["id_us"] = sol.Usuario;
            return View(sol);
        }

        // GET: Articulo/Create
        public ActionResult Create()
        {
            Lineas_pedidoEN en = new Lineas_pedidoEN();
            AssemblerLineas_pedido ass = new AssemblerLineas_pedido();
            Lineas_pedido sol = ass.ConvertENToModelUI(en);
            return View(sol);
        }

        // POST: Articulo/Create
        [HttpPost]
        public ActionResult Create(Lineas_pedido collection)
        {
            try
            {
                // TODO: Add insert logic here
                Lineas_pedidoCEN cen = new Lineas_pedidoCEN();
                //ni idea
                //cen.New_(collection.Usuario, collection.Precio);
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

            Lineas_pedidoCEN cen = new Lineas_pedidoCEN();

            Lineas_pedidoEN en = new Lineas_pedidoEN();
            en = cen.ReadOID(id);

            // SessionInitializeTransaction();

            //IProducto productoCAD = new productoCAD(session);

            // ProductoEN en = new Pro;
            AssemblerLineas_pedido ass = new AssemblerLineas_pedido();
            Lineas_pedido sol = ass.ConvertENToModelUI(en);
           // ViewData["id_us"] = sol.Usuario;
            return View(sol);
        }

        // POST: Articulo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Lineas_pedido collection)
        {
            try
            {
                // TODO: Add update logic here
                Lineas_pedidoCEN cen = new Lineas_pedidoCEN();
                cen.Modify(id, collection.cantidad);
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

            Lineas_pedidoCEN cen = new Lineas_pedidoCEN();

            Lineas_pedidoEN en = new Lineas_pedidoEN();
            en = cen.ReadOID(id);
            AssemblerLineas_pedido ass = new AssemblerLineas_pedido();
            Lineas_pedido sol = ass.ConvertENToModelUI(en);
            return View(sol);
        }

        // POST: Articulo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Lineas_pedidoCEN cen = new Lineas_pedidoCEN();

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
