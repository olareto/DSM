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

            System.Web.HttpContext.Current.Session["controller"] = "Producto";
            System.Web.HttpContext.Current.Session["action"] = "Index";
            System.Web.HttpContext.Current.Session["arg"] = null;


            return View(listart);
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            ProductoCAD cad = new ProductoCAD(session);

            ProductoCEN cen = new ProductoCEN(cad);
            ProductoEN en = cen.ReadOID(id);

            AssemblerProducto ass = new AssemblerProducto();
            Producto sol = ass.ConvertENToModelUI(en);


            IList<ComentarioEN> ten = en.Comentario;

            AssemblerComentario assc = new AssemblerComentario();
            IList<Comentario> solc = assc.ConvertListENToModel(ten);

            SessionClose();


            ViewData["controller"] = System.Web.HttpContext.Current.Session["controller"] as String;
            ViewData["action"] = System.Web.HttpContext.Current.Session["action"] as String;
            ViewData["arg"] = System.Web.HttpContext.Current.Session["arg"];
            ViewData["id_serie"] = id;
            ViewData["correo"] = System.Web.HttpContext.Current.Session["correo"] as String;







            // ViewData["action"] = "Details";
            ViewBag.coment = solc;
            return View(sol);
        }

        // GET: Articulo/Create
        public ActionResult Create()
        {
            ProductoEN en = new ProductoEN();
            AssemblerProducto ass = new AssemblerProducto();
            Producto sol = ass.ConvertENToModelUI(en);
            ViewData["controller"] = System.Web.HttpContext.Current.Session["controller"] as String;
            ViewData["action"] = System.Web.HttpContext.Current.Session["action"] as String;
            ViewData["arg"] = System.Web.HttpContext.Current.Session["arg"];
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

                cen.New_(collection.Nombre, collection.Precio, collection.Descripcion, collection.Imagen, (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum)collection.Valoracion, collection.Stock, collection.descriplarga, collection.imagran, collection.Talla);



                


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
            
            ProductoCEN cen = new ProductoCEN();

            ProductoEN en = new ProductoEN();
            en = cen.ReadOID(id);

            // SessionInitializeTransaction();

            //IProducto productoCAD = new productoCAD(session);

            // ProductoEN en = new Pro;
            AssemblerProducto ass = new AssemblerProducto();
            Producto sol = ass.ConvertENToModelUI(en);

            ViewData["controller"] = System.Web.HttpContext.Current.Session["controller"] as String;
            ViewData["action"] = System.Web.HttpContext.Current.Session["action"] as String;
            ViewData["arg"] = System.Web.HttpContext.Current.Session["arg"];

            



            return View(sol);
        }

        // POST: Articulo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Producto collection)
        {
            try
            {

                string action = System.Web.HttpContext.Current.Session["action"] as String;
                string controller = System.Web.HttpContext.Current.Session["controller"] as String;
                Object arg = System.Web.HttpContext.Current.Session["arg"];

                // TODO: Add update logic here
                ProductoCEN cen = new ProductoCEN();
                cen.Modify(id,collection.Nombre, collection.Precio, collection.Descripcion, collection.Imagen, (SMPGenNHibernate.Enumerated.SMP.ValoracionEnum)collection.Valoracion, collection.Stock, collection.descriplarga, collection.imagran, collection.Talla);

                //cen.New_(collection.Nombre, collection.Precio, collection.Descripcion, collection.Imagen, collection.Valor, collection.Stock, collection.Talla);
                
                return RedirectToAction(action,controller, arg);
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
                string action = System.Web.HttpContext.Current.Session["action"] as String;
                string controller = System.Web.HttpContext.Current.Session["controller"] as String;
                Object arg = System.Web.HttpContext.Current.Session["arg"];


                // TODO: Add delete logic here
                ProductoCEN cen = new ProductoCEN();

                cen.Destroy(id);
                return RedirectToAction(action, controller, arg);
                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Articulo/Resultadobusqueda/5
        public ActionResult Resultadobusqueda()
        {
            System.Web.HttpContext.Current.Session["controller"] = "Producto";
            System.Web.HttpContext.Current.Session["action"] = "Resultadobusqueda";
            System.Web.HttpContext.Current.Session["arg"] = null;

            IList<Producto> res = System.Web.HttpContext.Current.Session["resu"] as IList<Producto>;
            if (res == null)
            {
                res = new List<Producto>();
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

            FiltroProducto res = new FiltroProducto();

            ViewData["controller"] = System.Web.HttpContext.Current.Session["controller"] as String;
            ViewData["action"] = System.Web.HttpContext.Current.Session["action"] as String;
            ViewData["arg"] = System.Web.HttpContext.Current.Session["arg"];
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


                System.Web.HttpContext.Current.Session["resu"] = listart;

                return RedirectToAction("Resultadobusqueda", "Producto",null);
               
               // return View("Resultadobusqueda", listart);

            }
            catch
            {

                return View();
            }


        }

        }
}
