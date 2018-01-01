﻿using DSM5.Models;
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
    public class ComentarioController : BasicController
    {
        // GET: Articulo
        public ActionResult Index()
        {






            System.Web.HttpContext.Current.Session["controller"] = "Comentario";
            System.Web.HttpContext.Current.Session["action"] = "Index";
            System.Web.HttpContext.Current.Session["arg"] = null;


            ComentarioCEN cen = new ComentarioCEN();
            IList<ComentarioEN> enlinst=cen.ReadAll(0, 6);
            AssemblerComentario ass = new AssemblerComentario();
            IList<Comentario> listart = ass.ConvertListENToModel(enlinst);

            //articuloAsembler.covert
            return View(listart);
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int id)
        {


            ComentarioCEN cen = new ComentarioCEN();

            ComentarioEN en = new ComentarioEN();
            
            en = cen.ReadOID(id);
            AssemblerComentario ass = new AssemblerComentario();
            Comentario sol =ass.ConvertENToModelUI(en);
          
            ViewData["controller"] = System.Web.HttpContext.Current.Session["controller"] as String;
            ViewData["action"] = System.Web.HttpContext.Current.Session["action"] as String;
            ViewData["arg"] = System.Web.HttpContext.Current.Session["arg"];

            return View(sol);
        }

        // GET: Articulo/Create
        public ActionResult Create(int id)
        {
            ComentarioEN en = new ComentarioEN();
            AssemblerComentario ass = new AssemblerComentario();
            Comentario sol = ass.ConvertENToModelUI(en);

            ViewData["controller"] = System.Web.HttpContext.Current.Session["controller"] as String;
            ViewData["action"] = System.Web.HttpContext.Current.Session["action"] as String;
            ViewData["arg"] = System.Web.HttpContext.Current.Session["arg"];
            //ViewData["action"] = "Details";
            sol.id = id;
            return View(sol);
        }

        // POST: Articulo/Create
        [HttpPost]
        public ActionResult Create(int id,Comentario collection)
        {
            try
            {
                // TODO: Add insert logic here
                ComentarioCEN cen = new ComentarioCEN();
                
                string tipo= System.Web.HttpContext.Current.Session["controller"] as String;

                int e= cen.New_(collection.comentario, collection.autor, new DateTime(collection.fecha.Year, collection.fecha.Month, collection.fecha.Day));
                List<int> es=new List<int>();
                es.Add(e);
                if (tipo == "Capitulo")
                {
                    CapituloCEN ccen = new CapituloCEN();
                    ccen.Addcomentario(id, es);
                    cen.Addcap(e,id);
                }
                else if (tipo == "Pelicula")
                {
                    PeliculaCEN ccen = new PeliculaCEN();

                    ccen.Addcomentario(id, es);
                    cen.Addpel(e,id);
                }
                else if (tipo == "Producto"|| tipo == "Evento")
                {
                    ArticuloCEN ccen = new ArticuloCEN();

                    ccen.Addcomentario(id, es);
                    cen.Addart(e, id);
                }

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
        public ActionResult Edit( int id)
        {

            ComentarioCEN cen = new ComentarioCEN();

            ComentarioEN en = new ComentarioEN();
            en = cen.ReadOID(id);

            // SessionInitializeTransaction();

            //IProducto productoCAD = new productoCAD(session);

            // ProductoEN en = new Pro;
            AssemblerComentario ass = new AssemblerComentario();
            Comentario sol = ass.ConvertENToModelUI(en);



            ViewData["controller"] = System.Web.HttpContext.Current.Session["controller"] as String;
            ViewData["action"] = System.Web.HttpContext.Current.Session["action"] as String;
            ViewData["arg"] = System.Web.HttpContext.Current.Session["arg"];




            return View(sol);
        }

        // POST: Articulo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Comentario collection)
        {
            try
            {
                // TODO: Add update logic here

                ComentarioCEN cen = new ComentarioCEN();

                



                cen.Modify(collection.id, collection.comentario, collection.autor,new DateTime(collection.fecha.Year, collection.fecha.Month, collection.fecha.Day));
                //cen.New_(collection.Nombre, collection.Precio, collection.Descripcion, collection.Imagen, collection.Valor, collection.Stock, collection.Talla);
                //return RedirectToAction("Index");
                // int idbueno = sol.serie;

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


            ViewData["controller"] = System.Web.HttpContext.Current.Session["controller"] as String;
            ViewData["action"] = System.Web.HttpContext.Current.Session["action"] as String;
            ViewData["arg"] = System.Web.HttpContext.Current.Session["arg"];

            ComentarioCEN cen = new ComentarioCEN();

            ComentarioEN en = new ComentarioEN();
            en = cen.ReadOID(id);
            AssemblerComentario ass = new AssemblerComentario();
            Comentario sol = ass.ConvertENToModelUI(en);
            
            
            return View(sol);
        }

        // POST: Articulo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ComentarioCEN cen = new ComentarioCEN();
               
              
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


       

      


    }
}
