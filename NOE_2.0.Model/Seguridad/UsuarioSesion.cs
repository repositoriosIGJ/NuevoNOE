using NUEVO.NOE.Model.Seguridad;

namespace NUEVO.NOE.DTO.Seguridad
{
    public class UsuarioSesion
    {
        public Usuario? Usuario { get; set; }
        public List<UsuarioRol>? UsuarioRol { get; set; }
        public List<RolFuncion>? RolFuncion { get; set; }

    }
}
