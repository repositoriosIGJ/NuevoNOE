using NUEVO.NOE.BLAZORWEB.ClientServices.Contrato;
using NUEVO.NOE.Model.UtilidadesOracles;
using System.Net.Http.Json;

namespace NUEVO.NOE.BLAZORWEB.ClientServices.Implementacion
{
    public class UtilidadesDBOracle : IUtilidadesDBOracle
    {
        private readonly HttpClient _httpClient;

        public UtilidadesDBOracle(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<TipoSocietario>> GetTipoSocietario()
        {
            var rspGetTiposSocietarios = await _httpClient.GetFromJsonAsync<List<TipoSocietario>>("http://localhost:32674/api/tiposocietario/GetTiposSocietarios");

            return rspGetTiposSocietarios;
        }

        public async Task<IEnumerable<TipoTramite>> GetTipoTramites()
        {

            var rspGetTipoTramites = await _httpClient.GetFromJsonAsync<List<TipoTramite>>("http://localhost:32674/api/TipoTramite");

            return rspGetTipoTramites;
        }
    }
}
