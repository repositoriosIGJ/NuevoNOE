namespace NUEVO.NOE.Model.Seguridad;

public partial class UsuarioRolDTO
{
    public int? Usrid { get; set; }

    public int? Rolid { get; set; }

    public DateTime? Fechaalta { get; set; }

    public virtual RolDTO? Rol { get; set; }

    public virtual UsuarioDTO? Usr { get; set; }
}
