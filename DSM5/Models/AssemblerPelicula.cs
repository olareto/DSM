﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMPGenNHibernate.EN.SMP;


namespace DSM5.Models
{
    public class AssemblerPelicula
    {
        public Pelicula ConvertENToModelUI(PeliculaEN en)
        {
            Pelicula pel = new Pelicula();
            pel.id = en.Id;
            pel.Nombre = en.Nombre;
            pel.Valoracion = (int)en.Valoracion;
            pel.Imagen = en.Imagen;
            pel.descripcion = en.Descripcion;
            pel.desclar = en.Descriplarga;
            pel.fecha = en.Anyo;
            pel.genero = en.Genero;
            pel.imagran = en.Imagran;
            pel.link = en.Link;
            return pel;


        }
        public IList<Pelicula> ConvertListENToModel(IList<PeliculaEN> ens)
        {
            IList<Pelicula> arts = new List<Pelicula>();
            foreach (PeliculaEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
    }
}