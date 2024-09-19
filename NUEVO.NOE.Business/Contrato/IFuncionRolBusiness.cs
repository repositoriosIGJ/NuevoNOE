using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;

namespace NUEVO.NOE.Business.Contrato
{
    public interface IFuncionRolBusiness
    {
        Task<ResponseDTO<List<RolFuncionDTO>>> GetRolFunciones();

        Task<ResponseDTO<List<RolFuncionDTO>>> GetRolFuncionById(int idRol);

        Task<ResponseDTO<List<FuncionDTO>>> GetFuncionesAssignedToRol(int idRol);

        Task<ResponseDTO<List<FuncionDTO>>> GetFuncionesNotAssignedToRol(int idRol);

        Task<ResponseDTO<bool>> AddRolFuncion(RolFuncionDTO RolFuncionDto);

        Task<ResponseDTO<RolFuncionDTO>> UpdateRolFuncion(RolFuncionDTO oldRolFuncionDTO, RolFuncionDTO newRolFuncionDTO);

        Task<ResponseDTO<RolFuncionDTO>> DeleteRolFuncion(RolFuncionDTO rolFuncionDTO);
    }
}
