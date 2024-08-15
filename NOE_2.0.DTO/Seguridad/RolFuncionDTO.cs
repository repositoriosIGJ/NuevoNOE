namespace NUEVO.NOE.Model.Seguridad;

public partial class RolFuncionDTO
{
    public int? Rolid { get; set; }

    public int? Funid { get; set; }

    public virtual FuncionDTO? Funcion { get; set; }

    public virtual RolDTO? Rol { get; set; }
}
