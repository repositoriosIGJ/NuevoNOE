namespace NUEVO.NOE.Model.Seguridad;

public partial class RolFuncion
{
    public int? Rolid { get; set; }

    public int? Funid { get; set; }

    public virtual Funcion? Funcion { get; set; }

    public virtual Rol? Rol { get; set; }
}
