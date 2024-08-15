namespace NUEVO.NOE.Model.Seguridad;

public partial class UsuarioDTO
{
    public Usuario? Usuario { get; set; }
    public List<UsuarioRol>? UsuarioRol { get; set; }
    public List<RolFuncion>? RolFuncion { get; set; }
}
