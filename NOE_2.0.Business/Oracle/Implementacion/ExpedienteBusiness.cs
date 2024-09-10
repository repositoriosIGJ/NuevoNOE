using NUEVO.NOE.Business.Oracle.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.UtilidadesOracles;
using NUEVO.NOE.Service.OracleService.Contrato;

namespace NUEVO.NOE.Business.Oracle.Implementacion
{
    public class ExpedienteBusiness : IExpedienteBusiness
    {
        private readonly IExpedienteService _expedienteService;

        public ExpedienteBusiness(IExpedienteService expedienteService)
        {
            _expedienteService = expedienteService;
        }

        public Task<ResponseDTO<List<Expediente>>> GetExpedientes(Expediente expediente)
        {
            var rsp = _expedienteService.GetExpedientes(expediente);

            return rsp;
        }
    }
}
