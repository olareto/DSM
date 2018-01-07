
using System;
// Definición clase AdminEN
namespace SMPGenNHibernate.EN.SMP
{
public partial class AdminEN                                                                        : SMPGenNHibernate.EN.SMP.UsuarioEN


{
/**
 *	Atributo lista_0
 */
private System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ListaEN> lista_0;



/**
 *	Atributo carrito_0
 */
private SMPGenNHibernate.EN.SMP.CarritoEN carrito_0;






public virtual System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ListaEN> Lista_0 {
        get { return lista_0; } set { lista_0 = value;  }
}



public virtual SMPGenNHibernate.EN.SMP.CarritoEN Carrito_0 {
        get { return carrito_0; } set { carrito_0 = value;  }
}





public AdminEN() : base ()
{
        lista_0 = new System.Collections.Generic.List<SMPGenNHibernate.EN.SMP.ListaEN>();
}



public AdminEN(string email, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ListaEN> lista_0, SMPGenNHibernate.EN.SMP.CarritoEN carrito_0
               , SMPGenNHibernate.EN.SMP.CarritoEN carrito, string nombre, string apellidos, String contrasenya, string direccion, string tarjeta, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ListaEN> lista, string imagen
               )
{
        this.init (Email, lista_0, carrito_0, carrito, nombre, apellidos, contrasenya, direccion, tarjeta, lista, imagen);
}


public AdminEN(AdminEN admin)
{
        this.init (Email, admin.Lista_0, admin.Carrito_0, admin.Carrito, admin.Nombre, admin.Apellidos, admin.Contrasenya, admin.Direccion, admin.Tarjeta, admin.Lista, admin.Imagen);
}

private void init (string email
                   , System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ListaEN> lista_0, SMPGenNHibernate.EN.SMP.CarritoEN carrito_0, SMPGenNHibernate.EN.SMP.CarritoEN carrito, string nombre, string apellidos, String contrasenya, string direccion, string tarjeta, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ListaEN> lista, string imagen)
{
        this.Email = email;


        this.Lista_0 = lista_0;

        this.Carrito_0 = carrito_0;

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
