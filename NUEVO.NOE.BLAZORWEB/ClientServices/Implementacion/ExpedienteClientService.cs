using NUEVO.NOE.BLAZORWEB.ClientServices.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;
using NUEVO.NOE.Model.UtilidadesOracles;
using System.Net.Http.Json;

namespace NUEVO.NOE.BLAZORWEB.ClientServices.Implementacion
{
    public class ExpedienteClientService : IExpedienteClientService
    {
        private readonly HttpClient _httpClient;

        public ExpedienteClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<List<Expediente>>> GetExpediente(Expediente expediente)
        {
            ResponseDTO<List<Expediente>> result = new();

            var respuesta = await _httpClient.PostAsJsonAsync("api/Expediente/GetExpedientes", expediente);

            if (respuesta.IsSuccessStatusCode)
            {

                //la respuesta la deserializo en responseDTO para el return
                result = await respuesta.Content.ReadFromJsonAsync<ResponseDTO<List<Expediente>>>();
            }
            else
            {
                var errorContent = await respuesta.Content.ReadAsStringAsync();
                // almaceno el  error content en el Message de la respuesta
                result.Message = $"Error: {respuesta.StatusCode}, Details: {errorContent}";
            }


            return result;
        }
    }
}
