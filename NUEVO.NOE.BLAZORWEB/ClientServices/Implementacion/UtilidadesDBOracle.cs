using NUEVO.NOE.BLAZORWEB.ClientServices.Contrato;
using NUEVO.NOE.Model.UtilidadesOracles;
using System.Net.Http.Json;
using NUEVO.NOE.Model;
using NUEVO.NOE.DTO;
using DocumentFormat.OpenXml.Office2016.Excel;

namespace NUEVO.NOE.BLAZORWEB.ClientServices.Implementacion
{
    public class UtilidadesDBOracle : IUtilidadesDBOracle
    {
        private readonly HttpClient _httpClient;

        public UtilidadesDBOracle(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<List<PersoneriaCiviles>>> GetPersoneriaCiviles(FiltrosDatosCiviles filtros)
        {

            // Realizar la llamada a la API usando POST
            var respuesta = await _httpClient.PostAsJsonAsync($"api/datosciviles", filtros);

            // Verificar si la respuesta fue exitosa
            if (respuesta.IsSuccessStatusCode)
            {
                // Leer y deserializar la respuesta en un ResponseDTO
                var responseDTO = await respuesta.Content.ReadFromJsonAsync<ResponseDTO<List<PersoneriaCiviles>>>();

                // Retornar el objeto deserializado
                return responseDTO;
            }

            // Manejo de error en caso de que la respuesta no sea exitosa
            return new ResponseDTO<List<PersoneriaCiviles>>
            {
                IsSuccess = false,
                Message = "Error al obtener los datos"
            };
        }

        public async Task<IEnumerable<TipoSocietario>> GetTipoSocietario()
        {
            var rspGetTiposSocietarios = await _httpClient.GetFromJsonAsync<List<TipoSocietario>>("http://localhost:32674/api/TipoSocietario");

            return rspGetTiposSocietarios;
        }

        public async Task<IEnumerable<TipoTramite>> GetTipoTramites()
        {

            var rspGetTipoTramites = await _httpClient.GetFromJsonAsync<List<TipoTramite>>("http://localhost:32674/api/TipoTramite");

            return rspGetTipoTramites;
        }
    }
}
