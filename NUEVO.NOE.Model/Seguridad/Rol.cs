namespace NUEVO.NOE.Model.Seguridad;

public partial class Rol
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public int? IdDepartamento { get; set; }

    public bool? Inhabilitado { get; set; }

    public Departamento? Departamento { get; set; }
}
