using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;

namespace NUEVO.NOE.Repository.Seguridad.Contrato
{
    public interface IRolRepository
    {
        Task<ResponseDTO<List<RolDTO>>> GetRoles();

        Task<ResponseDTO<RolDTO>> GetRolById(int id);

        Task<ResponseDTO<bool>> AddRol(RolDTO rolDTO);

        Task<ResponseDTO<RolDTO>> UpdateRol(RolDTO rolDTO);

        Task<ResponseDTO<bool>> DeleteRol(int id);


    }
}

