using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.UtilidadesOracles;
using NUEVO.NOE.Service.OracleService.Contrato;
using System.Net.Http.Json;

namespace NUEVO.NOE.Service.OracleService.Implementacion
{
    public class TipoTramiteService : ITipoTramiteService
    {

        private readonly HttpClient _httpClient;

        public TipoTramiteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:32674/");
        }

        public async Task<ResponseDTO<IEnumerable<TipoTramite>>> GetTiposTramites()
        {
            var rstGetBycodigo = await _httpClient.GetFromJsonAsync<ResponseDTO<IEnumerable<TipoTramite>>>($"api/tipotramite/GetAllTipoTramites");

            return rstGetBycodigo;
        }

        public async Task<ResponseDTO<TipoTramite>> GetTramitesbyCodigoTramite(string codigo)
        {
            var rstGetBycodigo = await _httpClient.GetFromJsonAsync<ResponseDTO<TipoTramite>>($"api/tipotramite/GetTipoTramitebyCodigo?codigo={codigo}");

            return rstGetBycodigo;
        }
    }
}
