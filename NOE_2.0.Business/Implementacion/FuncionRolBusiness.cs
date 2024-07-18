using NUEVO.NOE.Business.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;
using NUEVO.NOE.Repository.Seguridad.Contrato;

namespace NUEVO.NOE.Business.Implementacion
{
    public class FuncionRolBusiness : IFuncionRolBusiness
    {
        private readonly IFuncionRolRepository _funcionRolRepository;

        public FuncionRolBusiness(IFuncionRolRepository funcionRolRepository)
        {
            _funcionRolRepository = funcionRolRepository;
        }

        public async Task<ResponseDTO<bool>> AddRolFuncion(RolFuncionDTO RolFuncionDto)
        {
            var rst = await _funcionRolRepository.AddRolFuncion(RolFuncionDto);

            return rst;
        }

        public async Task<ResponseDTO<RolFuncionDTO>> DeleteRolFuncion(RolFuncionDTO rolFuncionDTO)
        {
            var rst = await _funcionRolRepository.DeleteRolFuncion(rolFuncionDTO);

            return rst;
        }

        public async Task<ResponseDTO<List<FuncionDTO>>> GetFuncionesAssignedToRol(int idRol)
        {
            var rst = await _funcionRolRepository.GetFuncionesAssignedToRol(idRol);

            return rst;
        }

        public async Task<ResponseDTO<List<FuncionDTO>>> GetFuncionesNotAssignedToRol(int idRol)
        {
            var rst = await _funcionRolRepository.GetFuncionesNotAssignedToRol(idRol);

            return rst;
        }

        public async Task<ResponseDTO<List<RolFuncionDTO>>> GetRolFuncionById(int idRol)
        {
            var rsp = await _funcionRolRepository.GetRolFuncionById(idRol);

            return rsp;
        }

        public Task<ResponseDTO<List<RolFuncionDTO>>> GetRolFunciones()
        {
            var rsp = _funcionRolRepository.GetRolFunciones();

            return rsp;
        }

        public async Task<ResponseDTO<RolFuncionDTO>> UpdateRolFuncion(RolFuncionDTO oldRolFuncionDTO, RolFuncionDTO newRolFuncionDTO)
        {
            var rst = await _funcionRolRepository.UpdateRolFuncion(oldRolFuncionDTO, newRolFuncionDTO);

            return rst;
        }
    }
}
