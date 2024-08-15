using NUEVO.NOE.Business.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;
using NUEVO.NOE.Repository.Seguridad.Contrato;

namespace NUEVO.NOE.Business.Implementacion
{
    public class RolesBusiness : IRolesBusiness
    {
        private readonly IRolRepository _rolRepository;

        private readonly IUsuarioRepository _usuarioRepository;

        public RolesBusiness(IRolRepository rolRepository, IUsuarioRepository usuarioRepository)
        {
            _rolRepository = rolRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ResponseDTO<bool>> AddRol(RolDTO rolDTO)
        {
            var rst = await _rolRepository.AddRol(rolDTO);

            return rst;
        }



        public async Task<ResponseDTO<bool>> DeleteRol(int id)
        {
            var rst = await _rolRepository.DeleteRol(id);
            return rst;
        }



        public async Task<ResponseDTO<RolDTO>> GetRolById(int id)
        {
            var rst = await _rolRepository.GetRolById(id);
            return rst;
        }

        public async Task<ResponseDTO<List<RolDTO>>> GetRoles()
        {
            var rst = await _rolRepository.GetRoles();
            return rst;
        }

        public async Task<ResponseDTO<List<RolDTO>>> GetRolesAssignedToUser(int userId)
        {
            var roles = await _rolRepository.GetRolesAssignedToUser(userId);

            return roles;
        }

        public async Task<ResponseDTO<List<RolDTO>>> GetRolesNotAssignedToUser(int userId)
        {
            var rolesNotAssigned = await _rolRepository.GetRolesNotAssignedToUser(userId);

            return rolesNotAssigned;
        }

        public async Task<ResponseDTO<List<RolDTO>>> GetRolesNotAssignedToUserByDepartamento(int userId, int departamentoId)
        {
            var rolesNotAssignedByDepto = await _rolRepository.GetRolesNotAssignedToUserByDepartamento(userId, departamentoId);

            return rolesNotAssignedByDepto;
        }

        public async Task<ResponseDTO<RolDTO>> UpdateRol(RolDTO rol)
        {
            var rst = await _rolRepository.UpdateRol(rol);
            return rst;
        }


    }
}
