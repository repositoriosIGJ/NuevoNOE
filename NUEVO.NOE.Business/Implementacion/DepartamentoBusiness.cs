using NUEVO.NOE.Business.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;
using NUEVO.NOE.Repository.Seguridad.Contrato;

namespace NUEVO.NOE.Business.Implementacion
{
    public class DepartamentoBusiness : IDepartamentoBusiness
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        public DepartamentoBusiness(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        public async Task<ResponseDTO<List<Departamento>>> GetDepartamentos()
        {
            var rsp = await _departamentoRepository.GetDepartamentos();

            return rsp;
        }
    }
}
