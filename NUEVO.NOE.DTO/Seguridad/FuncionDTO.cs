namespace NUEVO.NOE.Model.Seguridad;

public partial class FuncionDTO
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public bool? Inhabilitado { get; set; } = false;

    public string? Url { get; set; }

    public string? Tooltip { get; set; }
}
