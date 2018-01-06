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
    public class AdminController : BasicController
    {
        // GET: Articulo
        public ActionResult Index()
        {
            AdminCEN cen = new AdminCEN();
            IList<AdminEN> enlinst=cen.ReadAll(0, 6);
            AssemblerAdmin ass = new AssemblerAdmin();
            IList<Admin> listart = ass.ConvertListENToModel(enlinst);

            //articuloAsembler.covert
            return View(listart);
        }

        // GET: Articulo/Details/5
        public ActionResult Details(string id)
        {
            SessionInitialize();
            AdminCAD cad = new AdminCAD(session);
            AdminCEN cen = new AdminCEN(cad);

            AdminEN en = new AdminEN();

            en = cen.ReadOID(id);

            // CarritoCEN cenc = new CarritoCEN();
            //CarritoEN enc = new CarritoEN();
            //enc = en.Carrito;

            AssemblerAdmin ass = new AssemblerAdmin();
            Admin sol = ass.ConvertENToModelUI(en);

            SessionClose();
            return View(sol);
        }

        // GET: Articulo/Create
        public ActionResult Create()
        {
            
            Admin sol = new Admin();
            return View(sol);
        }

        // POST: Articulo/Create
        [HttpPost]
        public ActionResult Create(Admin collection)
        {
            try
            {
                // TODO: Add insert logic here
                AdminCEN cen = new AdminCEN();
                cen.New_( collection.Nombre, collection.Apellidos, collection.Password, collection.Email, collection.Direccion, collection.Tarjeta, collection.Imagen);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Articulo/Edit/5
        public ActionResult Edit(string id)
        {

            SessionInitialize();
            AdminCAD cad = new AdminCAD(session);
            AdminCEN cen = new AdminCEN(cad);

            AdminEN en = new AdminEN();

            en = cen.ReadOID(id);

            // CarritoCEN cenc = new CarritoCEN();
            //CarritoEN enc = new CarritoEN();
            //enc = en.Carrito;

            AssemblerAdmin ass = new AssemblerAdmin();
            Admin sol = ass.ConvertENToModelUI(en);

            SessionClose();
            return View(sol);
        }

        // POST: Articulo/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Admin collection)
        {
            try
            {
                // TODO: Add update logic here
                AdminCEN cen = new AdminCEN();

                cen.Modify(id, collection.Nombre, collection.Apellidos, collection.Password, collection.Direccion, collection.Tarjeta, collection.Imagen);
                //cen.New_(collection.Nombre, collection.Precio, collection.Descripcion, collection.Imagen, collection.Valor, collection.Stock, collection.Talla);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Articulo/Delete/5
        public ActionResult Delete(string id)
        {

            SessionInitialize();
            AdminCAD cad = new AdminCAD(session);
            AdminCEN cen = new AdminCEN(cad);

            AdminEN en = new AdminEN();

            en = cen.ReadOID(id);

            // CarritoCEN cenc = new CarritoCEN();
            //CarritoEN enc = new CarritoEN();
            //enc = en.Carrito;

            AssemblerAdmin ass = new AssemblerAdmin();
            Admin sol = ass.ConvertENToModelUI(en);

            SessionClose();
            return View(sol);
        }

        // POST: Articulo/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                AdminCEN cen = new AdminCEN();

                cen.Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Articulo/Resultadobusqueda/5
        public ActionResult Resultadobusqueda(IList<Admin> res)
        {

      
            return View(res);
        }
        // GET: Articulo/Filtrar/5
        ////////////////

        public ActionResult Filtrar()
        {

            FiltroAdmin res = new FiltroAdmin();
            

            //articuloAsembler.covert
            return View(res);
        }
        // POST: Articulo/Filtrar/5
        [HttpPost]
        public ActionResult Filtrar(FiltroAdmin collection)
        {
            try
            {
                AdminCEN cen = new AdminCEN();
                IList<AdminEN > res = null, aux = null;
                // TODO: Add delete logic here
                res = cen.ReadAll(0, int.MaxValue);

                
                if (collection.Nombrebol == true && collection.Nombre != null)
                {
                    //aux = cen.Filtronombre(collection.Nombre);
                    //res = res.Intersect(aux).ToList();
                }

                AssemblerAdmin ass = new AssemblerAdmin();
                IList<Admin> listart = ass.ConvertListENToModel(res);
                return View("Resultadobusqueda", listart);

            }
            catch
            {

                return View();
            }


        }

        }
}
