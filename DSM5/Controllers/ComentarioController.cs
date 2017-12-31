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
    public class ComentarioController : BasicController
    {
        // GET: Articulo
        public ActionResult Index()
        {
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
           
            return View(sol);
        }

        // GET: Articulo/Create
        public ActionResult Create(int id,string tipo)
        {
            ComentarioEN en = new ComentarioEN();
            AssemblerComentario ass = new AssemblerComentario();
            Comentario sol = ass.ConvertENToModelUI(en);
            ViewData["id_serie"] = id;
            ViewData["controller"] = tipo;
            ViewData["action"] = "Details";
            sol.id = id;
            return View(sol);
        }

        // POST: Articulo/Create
        [HttpPost]
        public ActionResult Create(int id, string tipo,Comentario collection)
        {
            try
            {
                // TODO: Add insert logic here
                ComentarioCEN cen = new ComentarioCEN();
                CapituloCEN ccen = new CapituloCEN();


                int e= cen.New_(collection.comentario, collection.autor, new DateTime(collection.fecha.Year, collection.fecha.Month, collection.fecha.Day));
                List<int> es=new List<int>();
                es.Add(e);
                ccen.Addcomentario(id,es);
                
                return RedirectToAction("Details", tipo, new { id = id });
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

                ComentarioEN en = new ComentarioEN();
                en = cen.ReadOID(id);
                AssemblerComentario ass = new AssemblerComentario();
                Comentario sol = ass.ConvertENToModelUI(en);
                cen.Modify(collection.id, collection.comentario, collection.autor,new DateTime(collection.fecha.Year, collection.fecha.Month, collection.fecha.Day));
                //cen.New_(collection.Nombre, collection.Precio, collection.Descripcion, collection.Imagen, collection.Valor, collection.Stock, collection.Talla);
                //return RedirectToAction("Index");
               // int idbueno = sol.serie;
                
                return RedirectToAction("mostrar_cap", "Temporada" );
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Articulo/Delete/5
        public ActionResult Delete(int id)
        {

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
                ComentarioEN en = new ComentarioEN();
                en = cen.ReadOID(id);
                AssemblerComentario ass = new AssemblerComentario();
                Comentario sol = ass.ConvertENToModelUI(en);
               // int idbueno = sol.serie;
                cen.Destroy(id);
                return RedirectToAction("mostrar_cap", "Temporada");
            }
            catch
            {
                return View();
            }
        }


       

      


    }
}
