using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;

namespace NUEVO.NOE.Business.Contrato
{
    public interface IFuncionBusiness
    {
        Task<ResponseDTO<List<FuncionDTO>>> GetFunciones();

        Task<ResponseDTO<List<FuncionDTO>>> GetFuncionesAssignedToRol(int rolId);

        Task<ResponseDTO<List<FuncionDTO>>> GetFuncionNotAssignedToRol(int rolId);

        Task<ResponseDTO<FuncionDTO>> GetFuncionById(int id);

        Task<ResponseDTO<bool>> AddFuncion(FuncionDTO funcionDTO);

        Task<ResponseDTO<FuncionDTO>> UpdateFuncion(FuncionDTO funcionDTO);

        Task<ResponseDTO<bool>> DeleteFuncion(int id);
    }
}
