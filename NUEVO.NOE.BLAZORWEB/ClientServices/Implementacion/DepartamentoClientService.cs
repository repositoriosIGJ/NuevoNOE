using NUEVO.NOE.BLAZORWEB.ClientServices.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;
using System.Net.Http.Json;

namespace NUEVO.NOE.BLAZORWEB.ClientServices.Implementacion
{
    public class DepartamentoClientService : IDepartamentoClientService
    {
        private readonly HttpClient _httpClient;

        public DepartamentoClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<List<Departamento>>> GetDepartamentos()
        {
            var rsp = await _httpClient.GetFromJsonAsync<ResponseDTO<List<Departamento>>>("api/Departamento");

            return rsp;
        }
    }
}
