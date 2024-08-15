using AutoMapper;
using NUEVO.NOE.Business.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;
using NUEVO.NOE.Repository.Seguridad.Contrato;

namespace NUEVO.NOE.Business.Implementacion
{
    public class FuncionBusiness : IFuncionBusiness

    {
        private readonly IMapper _mapper;

        public readonly IFuncionRepository _funcionRepository;

        public FuncionBusiness(IMapper mapper, IFuncionRepository funcionRepository)
        {
            _mapper = mapper;
            _funcionRepository = funcionRepository;
        }


        public async Task<ResponseDTO<bool>> AddFuncion(FuncionDTO funcionDTO)
        {
            var rsp = await _funcionRepository.AddFuncion(funcionDTO);

            return rsp;

        }

        public async Task<ResponseDTO<bool>> DeleteFuncion(int id)
        {
            var rsp = await _funcionRepository.DeleteFuncion(id);

            return rsp;
        }

        public Task<ResponseDTO<FuncionDTO>> GetFuncionById(int id)
        {
            var rsp = _funcionRepository.GetFuncionById(id);
            return rsp;
        }

        public async Task<ResponseDTO<List<FuncionDTO>>> GetFunciones()
        {
            var rsp = await _funcionRepository.GetFunciones();

            return rsp;
        }

        public Task<ResponseDTO<List<FuncionDTO>>> GetFuncionesAssignedToRol(int rolId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<List<FuncionDTO>>> GetFuncionNotAssignedToRol(int rolId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO<FuncionDTO>> UpdateFuncion(FuncionDTO funcionDTO)
        {
            var rsp = await _funcionRepository.UpdateFuncion(funcionDTO);

            return rsp;
        }
    }
}
