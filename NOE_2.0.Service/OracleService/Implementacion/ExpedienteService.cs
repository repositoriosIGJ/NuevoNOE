using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.UtilidadesOracles;
using NUEVO.NOE.Service.OracleService.Contrato;
using System.Net.Http.Json;

namespace NUEVO.NOE.Service.OracleService.Implementacion
{
    public class ExpedienteService : IExpedienteService
    {
        private readonly HttpClient _httpClient;

        public ExpedienteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:32674/");
        }

        public async Task<ResponseDTO<List<Expediente>>> GetExpedientes(Expediente expediente)
        {
            ResponseDTO<List<Expediente>> responseDTO = new();
            responseDTO.IsSuccess = false;

            var response = await _httpClient.PostAsJsonAsync("api/expediente/GetExpedientes", expediente);

            if (response.IsSuccessStatusCode)
            {
                responseDTO = await response.Content.ReadFromJsonAsync<ResponseDTO<List<Expediente>>>();

                return responseDTO;
            }
            else
            {
                responseDTO.Message = "error de respuesta con la API Oracle";
                return responseDTO;
            }
        }
    }
}
