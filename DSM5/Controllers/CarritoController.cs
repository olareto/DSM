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
    public class CarritoController : BasicController
    {
        // GET: Articulo
        public ActionResult Index()
        {


          

            if(System.Web.HttpContext.Current.Session["carrito"] != null)
            {
                int id = (int)System.Web.HttpContext.Current.Session["carrito"];
                return RedirectToAction("Details", "Carrito", new { id = id });
            }
            else
            {
                return RedirectToAction("Index", "Usuario", null);
            }
    
          
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int id)
        {


            SessionInitialize();
            CarritoCAD cad = new CarritoCAD(session);

            CarritoCEN cen = new CarritoCEN(cad);
            CarritoEN en = cen.ReadOID(id);

            AssemblerCarrito ass = new AssemblerCarrito();
            Carrito sol = ass.ConvertENToModelUI(en);


            IList<Lineas_pedidoEN> ten = en.Lineas_pedido;

            AssemblerLineas_pedido assc = new AssemblerLineas_pedido();
            IList<Lineas_pedido> solc = assc.ConvertListENToModel(ten);

            SessionClose();
            ViewData["correo"] = System.Web.HttpContext.Current.Session["correo"] as string;
            ViewData["carrito"] = id;
            // ViewData["action"] = "Details";
            ViewBag.coment = solc;

            return View(sol);
        }


        public ActionResult addlinea(int id,int idpro)
        {


            SessionInitialize();
            CarritoCAD cad = new CarritoCAD(session);

            CarritoCEN cen = new CarritoCEN(cad);
            CarritoEN en = cen.ReadOID(id);

            EventoCEN cene = new EventoCEN();
            EventoEN ene = cene.ReadOID(idpro);
            ProductoCEN cenp = new ProductoCEN();
            ProductoEN enp = cenp.ReadOID(idpro);


            AssemblerCarrito ass = new AssemblerCarrito();
            Carrito sol = ass.ConvertENToModelUI(en);

            
            IList<Lineas_pedidoEN> ten = en.Lineas_pedido;

            AssemblerLineas_pedido assc = new AssemblerLineas_pedido();
            IList<Lineas_pedido> solc = assc.ConvertListENToModel(ten);
            
            Lineas_pedidoCEN den = new Lineas_pedidoCEN();
            string tipo=null;
            Boolean si = false;
            double precio=0;
            foreach (Lineas_pedido linea in solc)
            {
                if (linea.articulo== idpro)
                {
                    si = true;
                    if (linea.stock!=linea.cantidad)
                    {
                        den.Modify(linea.id, (linea.cantidad + 1));
                    }
                    
                    tipo = linea.tipo;
                    precio = linea.precio;

                    

                }
            }

            if (si == false)
            {
                int h = den.New_(id, 1);

                if (ene != null)
                {
                    den.Addevento(h, idpro);
                    tipo = "Evento";
                    precio = ene.Precio;
                }
                else
                {
                    den.Addproducto(h, idpro);
                    tipo = "Producto";
                    precio = enp.Precio;
                }
                List<int> lista = new List<int>();
                lista.Add(h);
                cen.Addlinea(id, lista);
                
                
                
               



            }
            SessionClose();


            precio = precio + sol.Precio;
            CarritoCEN fin = new CarritoCEN();
            fin.Modify(id,  precio);



            ViewData["correo"] = System.Web.HttpContext.Current.Session["correo"] as string;
            // ViewData["action"] = "Details";
            return RedirectToAction("Details", tipo,new { id= idpro });

           
        }
        public ActionResult delllinea(int id, int idpro)
        {


            SessionInitialize();
            CarritoCAD cad = new CarritoCAD(session);

            CarritoCEN cen = new CarritoCEN(cad);
            CarritoEN en = cen.ReadOID(id);

            EventoCEN cene = new EventoCEN();
            EventoEN ene = cene.ReadOID(idpro);
            ProductoCEN cenp = new ProductoCEN();
            ProductoEN enp = cenp.ReadOID(idpro);


            AssemblerCarrito ass = new AssemblerCarrito();
            Carrito sol = ass.ConvertENToModelUI(en);


            IList<Lineas_pedidoEN> ten = en.Lineas_pedido;

            AssemblerLineas_pedido assc = new AssemblerLineas_pedido();
            IList<Lineas_pedido> solc = assc.ConvertListENToModel(ten);

            Lineas_pedidoCEN den = new Lineas_pedidoCEN();
            IList<int> vamos = new List<int>();
            vamos.Add(idpro);
            int cantidad=1;
            double precio=0;
            foreach (Lineas_pedido linea in solc)
            {
                if (linea.id == idpro)
                {
                    cantidad = linea.cantidad;
                    cen.Modify(sol.id, sol.Precio + linea.precio);
                    precio = linea.precio;
                    //den.Modify(linea.id, (linea.cantidad - 1));

                }
            }

           

            SessionClose();

            precio = sol.Precio - precio ;
            CarritoCEN fin = new CarritoCEN();
            fin.Modify(id, precio);

            //cen.Dellinea(id, vamos);
            if (cantidad == 1)
            {
                den.Destroy(idpro);

            }
            else
            {
                cantidad = cantidad - 1;
                den.Modify(idpro, cantidad);

            }

            ViewData["correo"] = System.Web.HttpContext.Current.Session["correo"] as string;
            // ViewData["action"] = "Details";
            return RedirectToAction("Details", "Carrito", new { id = id });


        }
        public ActionResult compra(int id)
        {


            SessionInitialize();
            CarritoCAD cad = new CarritoCAD(session);

            CarritoCEN cen = new CarritoCEN(cad);
            CarritoEN en = cen.ReadOID(id);

            AssemblerCarrito ass = new AssemblerCarrito();
            Carrito sol = ass.ConvertENToModelUI(en);


            IList<Lineas_pedidoEN> ten = en.Lineas_pedido;

            AssemblerLineas_pedido assc = new AssemblerLineas_pedido();
            IList<Lineas_pedido> solc = assc.ConvertListENToModel(ten);

            IList<int> vamos = new List<int>();
           
       
            foreach (Lineas_pedido linea in solc)
            {
                vamos.Add(linea.id);
                EventoCEN cene = new EventoCEN();
                ProductoCEN cenp = new ProductoCEN();
                if (linea.tipo== "Producto")
                {
                    ProductoEN enp = cenp.ReadOID(linea.articulo);
                    int cant = enp.Stock - linea.cantidad;
                    cenp.Modify(linea.articulo,enp.Nombre, enp.Precio, enp.Descripcion, enp.Imagen, enp.Valor, cant, enp.Descriplarga, enp.Imagran, enp.Talla);
                }
                else{
                    EventoEN ene = cene.ReadOID(linea.articulo);
                    int cant = ene.Stock - linea.cantidad;
                    cene.Modify(linea.articulo, ene.Nombre, ene.Precio, ene.Descripcion, ene.Imagen, ene.Valor, cant, ene.Descriplarga, ene.Imagran, ene.Tipo);
                }
            
               


            }



            SessionClose();

            
            CarritoCEN fin = new CarritoCEN();
            fin.Modify(id, 0);
            fin.Dellinea(id,vamos);




            //cen.Dellinea(id, vamos);
           
                

           
            

            ViewData["correo"] = System.Web.HttpContext.Current.Session["correo"] as string;
            // ViewData["action"] = "Details";
            return RedirectToAction("Details", "Carrito", new { id = id });


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
         
            ViewData["correo"] = System.Web.HttpContext.Current.Session["correo"] as string;
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


        // GET: Articulo/mostrar_cap/5
        

    }
}
