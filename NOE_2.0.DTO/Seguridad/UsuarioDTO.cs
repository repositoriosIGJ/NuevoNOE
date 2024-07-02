namespace NUEVO.NOE.Model.Seguridad;

public partial class UsuarioDTO
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? Documento { get; set; }

    public string? UserName { get; set; }

    public int? IdDpto { get; set; }

    public DateTime? Ultimoacceso { get; set; }

    public bool? Bloqueado { get; set; }

    public int? Nrointentos { get; set; }

    public bool? Baja { get; set; }

    public string? Ipbloqueo { get; set; }

    public string? NameActiveDirectory { get; set; }

    public virtual DepartamentoDTO? Departamento { get; set; }
}
