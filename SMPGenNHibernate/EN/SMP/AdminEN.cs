
using System;
// Definición clase AdminEN
namespace SMPGenNHibernate.EN.SMP
{
public partial class AdminEN                                                                        : SMPGenNHibernate.EN.SMP.UsuarioEN


{
public AdminEN() : base ()
{
}



public AdminEN(string email,
               SMPGenNHibernate.EN.SMP.CarritoEN carrito, string nombre, string apellidos, String contrasenya, string direccion, string tarjeta, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ListaEN> lista, string imagen
               )
{
        this.init (Email, carrito, nombre, apellidos, contrasenya, direccion, tarjeta, lista, imagen);
}


public AdminEN(AdminEN admin)
{
        this.init (Email, admin.Carrito, admin.Nombre, admin.Apellidos, admin.Contrasenya, admin.Direccion, admin.Tarjeta, admin.Lista, admin.Imagen);
}

private void init (string email
                   , SMPGenNHibernate.EN.SMP.CarritoEN carrito, string nombre, string apellidos, String contrasenya, string direccion, string tarjeta, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ListaEN> lista, string imagen)
{
        this.Email = email;


        this.Carrito = carrito;

        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Contrasenya = contrasenya;

        this.Direccion = direccion;

        this.Tarjeta = tarjeta;

        this.Lista = lista;

        this.Imagen = imagen;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdminEN t = obj as AdminEN;
        if (t == null)
                return false;
        if (Email.Equals (t.Email))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Email.GetHashCode ();
        return hash;
}
}
}
