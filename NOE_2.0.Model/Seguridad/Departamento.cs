namespace NUEVO.NOE.Model.Seguridad;

public partial class Departamento
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public string? Acronimo { get; set; }

    public virtual ICollection<Area> Areas { get; set; } = new List<Area>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
