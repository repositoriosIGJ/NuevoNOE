using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;

namespace NUEVO.NOE.Business.Contrato
{
    public interface IRolesBusiness
    {

        Task<ResponseDTO<List<RolDTO>>> GetRoles();

        Task<ResponseDTO<List<RolDTO>>> GetRolesAssignedToUser(int userId);

        Task<ResponseDTO<List<RolDTO>>> GetRolesNotAssignedToUser(int userId);

        Task<ResponseDTO<List<RolDTO>>> GetRolesNotAssignedToUserByDepartamento(int userId, int departamentoId);

        Task<ResponseDTO<RolDTO>> GetRolById(int id);

        Task<ResponseDTO<bool>> AddRol(RolDTO rolDTO);

        Task<ResponseDTO<RolDTO>> UpdateRol(RolDTO rolDTO);

        Task<ResponseDTO<bool>> DeleteRol(int id);


    }
}
