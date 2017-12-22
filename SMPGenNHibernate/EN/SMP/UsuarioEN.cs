
using System;
// Definición clase UsuarioEN
namespace SMPGenNHibernate.EN.SMP
{
public partial class UsuarioEN
{
/**
 *	Atributo carrito
 */
private SMPGenNHibernate.EN.SMP.CarritoEN carrito;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo apellidos
 */
private string apellidos;



/**
 *	Atributo contrasenya
 */
private String contrasenya;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo direccion
 */
private string direccion;



/**
 *	Atributo tarjeta
 */
private string tarjeta;



/**
 *	Atributo lista
 */
private System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ListaEN> lista;



/**
 *	Atributo imagen
 */
private string imagen;






public virtual SMPGenNHibernate.EN.SMP.CarritoEN Carrito {
        get { return carrito; } set { carrito = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}



public virtual String Contrasenya {
        get { return contrasenya; } set { contrasenya = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual string Tarjeta {
        get { return tarjeta; } set { tarjeta = value;  }
}



public virtual System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ListaEN> Lista {
        get { return lista; } set { lista = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}





public UsuarioEN()
{
        lista = new System.Collections.Generic.List<SMPGenNHibernate.EN.SMP.ListaEN>();
}



public UsuarioEN(string email, SMPGenNHibernate.EN.SMP.CarritoEN carrito, string nombre, string apellidos, String contrasenya, string direccion, string tarjeta, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.ListaEN> lista, string imagen
                 )
{
        this.init (Email, carrito, nombre, apellidos, contrasenya, direccion, tarjeta, lista, imagen);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (Email, usuario.Carrito, usuario.Nombre, usuario.Apellidos, usuario.Contrasenya, usuario.Direccion, usuario.Tarjeta, usuario.Lista, usuario.Imagen);
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
        UsuarioEN t = obj as UsuarioEN;
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
