
using System;
// Definición clase ListaEN
namespace SMPGenNHibernate.EN.SMP
{
public partial class ListaEN
{
/**
 *	Atributo estado
 */
private SMPGenNHibernate.Enumerated.SMP.Estado_videoEnum estado;



/**
 *	Atributo video
 */
private System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.VideoEN> video;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo usuario_1
 */
private SMPGenNHibernate.EN.SMP.UsuarioEN usuario_1;






public virtual SMPGenNHibernate.Enumerated.SMP.Estado_videoEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.VideoEN> Video {
        get { return video; } set { video = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual SMPGenNHibernate.EN.SMP.UsuarioEN Usuario_1 {
        get { return usuario_1; } set { usuario_1 = value;  }
}





public ListaEN()
{
        video = new System.Collections.Generic.List<SMPGenNHibernate.EN.SMP.VideoEN>();
}



public ListaEN(int id, SMPGenNHibernate.Enumerated.SMP.Estado_videoEnum estado, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.VideoEN> video, SMPGenNHibernate.EN.SMP.UsuarioEN usuario_1
               )
{
        this.init (Id, estado, video, usuario_1);
}


public ListaEN(ListaEN lista)
{
        this.init (Id, lista.Estado, lista.Video, lista.Usuario_1);
}

private void init (int id
                   , SMPGenNHibernate.Enumerated.SMP.Estado_videoEnum estado, System.Collections.Generic.IList<SMPGenNHibernate.EN.SMP.VideoEN> video, SMPGenNHibernate.EN.SMP.UsuarioEN usuario_1)
{
        this.Id = id;


        this.Estado = estado;

        this.Video = video;

        this.Usuario_1 = usuario_1;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ListaEN t = obj as ListaEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
