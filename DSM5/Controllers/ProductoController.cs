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
    public class ProductoController : BasicController
    {
        // GET: Articulo
        public ActionResult Index()
        {
            ProductoCEN cen = new ProductoCEN();
            IList<ProductoEN> enlinst=cen.ReadAll(0, 6);
            AssemblerProducto ass = new AssemblerProducto();
            IList<Producto> listart = ass.ConvertListENToModel(enlinst);

            //articuloAsembler.covert
            return View(listart);
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int id)
        {
            ProductoCEN cen = new ProductoCEN();

            ProductoEN en = new ProductoEN();
            
            en = cen.ReadOID(id);
            AssemblerProducto ass = new AssemblerProducto();
            Producto sol=ass.ConvertENToModelUI(en);
            
            return View(sol);
        }

        // GET: Articulo/Create
        public ActionResult Create()
        {
            ProductoEN en = new ProductoEN();
            AssemblerProducto ass = new AssemblerProducto();
            Producto sol = ass.ConvertENToModelUI(en);
            return View(sol);
        }

        // POST: Articulo/Create
        [HttpPost]
        public ActionResult Create(Producto collection)
        {
            try
            {
                // TODO: Add insert logic here
                ProductoCEN cen = new ProductoCEN();
                
                cen.New_(collection.Nombre, collection.Precio, collection.Descripcion, collection.Imagen, (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum)collection.Valoracion, collection.Stock, collection.Talla);
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
            
            ProductoCEN cen = new ProductoCEN();

            ProductoEN en = new ProductoEN();
            en = cen.ReadOID(id);

            // SessionInitializeTransaction();

            //IProducto productoCAD = new productoCAD(session);

            // ProductoEN en = new Pro;
            AssemblerProducto ass = new AssemblerProducto();
            Producto sol = ass.ConvertENToModelUI(en);
            return View(sol);
        }

        // POST: Articulo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Producto collection)
        {
            try
            {
                // TODO: Add update logic here
                ProductoCEN cen = new ProductoCEN();
                cen.Modify(id, collection.Nombre, collection.Precio, collection.Descripcion, collection.Imagen, (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum)collection.Valoracion, collection.Stock, collection.Talla);
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

            ProductoCEN cen = new ProductoCEN();

            ProductoEN en = new ProductoEN();
            en = cen.ReadOID(id);
            AssemblerProducto ass = new AssemblerProducto();
            Producto sol = ass.ConvertENToModelUI(en);
            return View(sol);
        }

        // POST: Articulo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ProductoCEN cen = new ProductoCEN();

                cen.Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Articulo/Resultadobusqueda/5
        public ActionResult Resultadobusqueda(IList<Producto> res)
        {

      
            return View(res);
        }
        // GET: Articulo/Filtrar/5
        ////////////////

        public ActionResult Filtrar()
        {

            FiltroProducto res = new FiltroProducto();
            

            //articuloAsembler.covert
            return View(res);
        }
        // POST: Articulo/Filtrar/5
        [HttpPost]
        public ActionResult Filtrar(FiltroProducto collection)
        {
            try
            {
                ProductoCEN cen = new ProductoCEN();
                IList<ProductoEN> res = null, aux = null;
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
                if (collection.tallabol == true && collection.Talla != null)
                {
                    aux = cen.Filtrotalla(collection.Talla);
                    res = res.Intersect(aux).ToList();
                }

                if (collection.Valoracionbol == true && collection.Valoracion > 0 && collection.Valoracion < 6)
                {
                    aux = cen.Filtrovalor((SMPGenNHibernate.Enumerated.SMP.ValoracionEnum)collection.Valoracion);
                    res = res.Intersect(aux).ToList();
                }
                AssemblerProducto ass = new AssemblerProducto();
                IList<Producto> listart = ass.ConvertListENToModel(res);
                return View("Resultadobusqueda", listart);

            }
            catch
            {

                return View();
            }


        }

        }
}
