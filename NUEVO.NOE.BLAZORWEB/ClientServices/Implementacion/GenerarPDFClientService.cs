using NUEVO.NOE.BLAZORWEB.ClientServices.Contrato;
using NUEVO.NOE.DTO;
using System.Net.Http.Json;

namespace NUEVO.NOE.BLAZORWEB.ClientServices.Implementacion
{
    public class GenerarPDFClientService : IGenerarPDFClientService
    {
        private readonly HttpClient _httpClient;

        public GenerarPDFClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseDTO<byte[]>> GeneratePDFHtmlFormat<T>(List<T> items, string url)
        {
            ResponseDTO<byte[]> responseDTO = new();

            // Enviar la solicitud para generar el PDF
            var response = await _httpClient.PostAsJsonAsync(url, items);

            if (response.IsSuccessStatusCode)
            {
                // Leer el PDF como un array de bytes
                var pdfBytes = await response.Content.ReadAsByteArrayAsync();
                responseDTO.Data = pdfBytes;
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
