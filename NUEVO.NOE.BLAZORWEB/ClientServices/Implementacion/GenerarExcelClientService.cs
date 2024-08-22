using NUEVO.NOE.BLAZORWEB.ClientServices.Contrato;
using NUEVO.NOE.DTO;
using System.Net.Http.Json;

namespace NUEVO.NOE.BLAZORWEB.ClientServices.Implementacion
{
    public class GenerarExcelClientService : IGenerarExcelClientService
    {
        private readonly HttpClient _httpClient;

        public GenerarExcelClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseDTO<byte[]>> GenerateExcel<T>(List<T> items, string url)
        {
            ResponseDTO<byte[]> responseDTO = new();

            // Enviar la solicitud para generar el Excel
            var response = await _httpClient.PostAsJsonAsync(url, items);

            if (response.IsSuccessStatusCode)
            {
                // Leer el Excel como un array de bytes
                var excelBytes = await response.Content.ReadAsByteArrayAsync();
                responseDTO.Data = excelBytes;
                responseDTO.IsSuccess = true;
            }
            else
            {
                // Manejar el error y almacenar detalles en la respuesta
                responseDTO.IsSuccess = false;
                responseDTO.Message = $"Error: {response.StatusCode}, Details: {await response.Content.ReadAsStringAsync()}";
            }

            return responseDTO;
        }
    }
}
