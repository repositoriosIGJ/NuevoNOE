using NUEVO.NOE.Model.UtilidadesOracles;
using NUEVO.NOE.Service.OracleService.Contrato;
using System.Net.Http.Json;

namespace NUEVO.NOE.Service.OracleService.Implementacion
{
    public class TipoSocietarioService : ITipoSocietarioService
    {
        private readonly HttpClient _httpClient;

        public TipoSocietarioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:32674/");
        }

        public async Task<TipoSocietario> GetByCodigoTipoSocietario(string codigo)
        {
            var rstGetBycodigo = await _httpClient.GetFromJsonAsync<TipoSocietario>($"api/tiposocietario/GetByCodigoSocietario?codigo={codigo}");

            return rstGetBycodigo;
        }

        public async Task<IEnumerable<TipoSocietario>> GetByTipo(string tipo)
        {
            var rstGetBytipo = await _httpClient.GetFromJsonAsync<IEnumerable<TipoSocietario>>($"api/tiposocietario/GetByTipo?tipo={tipo}");

            return rstGetBytipo;
        }

        public async Task<List<TipoSocietario>> GetCodigosSinCeroALaIzq()
        {
            var rstGetTiposSocietarios = await _httpClient.GetFromJsonAsync<List<TipoSocietario>>("api/tiposocietario/GetCodigosSinCeroALaIzq");

            return rstGetTiposSocietarios;
        }




        public async Task<IEnumerable<TipoSocietario>> GetTiposSocietarios()
        {
            var rstGetTiposSocietarios = await _httpClient.GetFromJsonAsync<List<TipoSocietario>>("api/tiposocietario/GetTiposSocietarios");

            return rstGetTiposSocietarios;
        }
    }
}
