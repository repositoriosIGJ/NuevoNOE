using NUEVO.NOE.DTO;
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

        public async Task<ResponseDTO<TipoSocietario>> GetByCodigoTipoSocietario(string codigo)
        {
            var rstGetBycodigo = await _httpClient.GetFromJsonAsync<ResponseDTO<TipoSocietario>>($"api/tiposocietario/GetByCodigoSocietario?codigo={codigo}");

            return rstGetBycodigo;
        }

        public async Task<ResponseDTO<IEnumerable<TipoSocietario>>> GetByTipo(string tipo)
        {
            var rstGetBytipo = await _httpClient.GetFromJsonAsync<ResponseDTO<IEnumerable<TipoSocietario>>>($"api/tiposocietario/GetByTipo?tipo={tipo}");

            return rstGetBytipo;
        }

        public async Task<ResponseDTO<IEnumerable<TipoSocietario>>> GetCodigosSinCeroALaIzq()
        {
            var rstGetTiposSocietarios = await _httpClient.GetFromJsonAsync<ResponseDTO<IEnumerable<TipoSocietario>>>("api/tiposocietario/GetCodigosSinCeroALaIzq");

            return rstGetTiposSocietarios;
        }




        public async Task<ResponseDTO<IEnumerable<TipoSocietario>>> GetTiposSocietarios()
        {
            var rstGetTiposSocietarios = await _httpClient.GetFromJsonAsync<ResponseDTO<IEnumerable<TipoSocietario>>>("api/tiposocietario/GetTiposSocietarios");

            return rstGetTiposSocietarios;
        }
    }
}
