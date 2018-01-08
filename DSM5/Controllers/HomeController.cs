using System;
using DSM5.Models;
using System.Collections.Generic;
using SMPGenNHibernate.CAD.SMP;
using SMPGenNHibernate.CEN.SMP;
using SMPGenNHibernate.EN.SMP;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSM5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           // if (System.Web.HttpContext.Current.Session["log"] != null && (bool)System.Web.HttpContext.Current.Session["log"]) {

               // IList<Pelicula> resu = new List<Pelicula>();
              //  ViewBag.peli = resu;
               // IList<Serie> resus = new List<Serie>();
               // ViewBag.serie = resus;

            //}
          //  else { 
            PeliculaCEN cen = new PeliculaCEN();
            IList<PeliculaEN> enlinst = cen.ReadAll(0, int.MaxValue);
            AssemblerPelicula ass = new AssemblerPelicula();
            IList<Pelicula> listart = ass.ConvertListENToModel(enlinst);

            int max = listart.Count;
            Random aleatorio = new Random();

            int uno = aleatorio.Next(1, max);
            int dos = aleatorio.Next(1, max);
            while (dos == uno)
            {
                dos = aleatorio.Next(1, max);
            }
            int tres = aleatorio.Next(1, max);
            while (dos == tres || uno == tres)
            {
                tres = aleatorio.Next(1, max);
            }

            int cuatro = aleatorio.Next(1, max);
            while (dos == cuatro || uno == cuatro || tres==cuatro)
            {
                cuatro = aleatorio.Next(1, max);
            }


            IList<Pelicula> resu = new List<Pelicula>();
            resu.Add(listart.ElementAt(uno));
            resu.Add(listart.ElementAt(dos));
            resu.Add(listart.ElementAt(tres));
            resu.Add(listart.ElementAt(cuatro));
            ViewBag.peli = resu;



            SerieCEN cens = new SerieCEN();
            IList<SerieEN> enlinsts = cens.ReadAll(0, int.MaxValue);
            AssemblerSerie asss = new AssemblerSerie();
            IList<Serie> listarts = asss.ConvertListENToModel(enlinsts);
            int maxs = listarts.Count;
            Random aleatorios = new Random();

            int unos = aleatorios.Next(1, maxs);
            int doss = aleatorios.Next(1, maxs);
            while (doss == unos)
            {
                doss = aleatorios.Next(1, maxs);
            }
            int tress = aleatorios.Next(1, maxs);
            while (doss == tress || unos == tress)
            {
                tress = aleatorios.Next(1, maxs);
            }
            int cuatross = aleatorios.Next(1, maxs);
            while (doss == cuatross || unos == cuatross ||tress==cuatross)
            {
                cuatross = aleatorios.Next(1, maxs);
            }


            IList<Serie> resus = new List<Serie>();
            resus.Add(listarts.ElementAt(unos));
            resus.Add(listarts.ElementAt(doss));
            resus.Add(listarts.ElementAt(tress));
            resus.Add(listarts.ElementAt(cuatross));
            ViewBag.serie = resus;

        
          //  }


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}