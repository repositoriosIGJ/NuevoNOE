namespace NUEVO.NOE.Model.Seguridad;

public partial class DepartamentoDTO
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public string? Acronimo { get; set; }

    public virtual ICollection<AreaDTO> Areas { get; set; } = new List<AreaDTO>();

    public virtual ICollection<UsuarioDTO> Usuarios { get; set; } = new List<UsuarioDTO>();
}
