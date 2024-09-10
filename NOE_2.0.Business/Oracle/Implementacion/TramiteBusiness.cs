using NUEVO.NOE.Business.Oracle.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.UtilidadesOracles;
using NUEVO.NOE.Service.OracleService.Contrato;

namespace NUEVO.NOE.Business.Oracle.Implementacion
{
    public class TramiteBusiness : ITramiteBusiness
    {
        private readonly ITramiteService _tramiteService;

        public TramiteBusiness(ITramiteService tramiteService)
        {
            _tramiteService = tramiteService;
        }

        public async Task<ResponseDTO<List<Tramite>>> GetTramites(Tramite tramite)
        {
            var rsp = await _tramiteService.GetTramites(tramite);

            return rsp;
        }
    }
}
