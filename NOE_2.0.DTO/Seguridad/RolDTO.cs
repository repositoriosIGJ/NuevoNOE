namespace NUEVO.NOE.Model.Seguridad;

public partial class RolDTO
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public int? IdDepartamento { get; set; }

    public bool? Inhabilitado { get; set; }

    public bool EsAsignado { get; set; }


    public Departamento? Departamento { get; set; }
}
