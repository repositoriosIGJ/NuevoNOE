using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.UtilidadesOracles;
using NUEVO.NOE.Service.OracleService.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace NUEVO.NOE.Service.OracleService.Implementacion
{
    public class DestinosService : IDestinosService
    {
        private HttpClient _httpClient;


        public DestinosService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<List<Destino>>> GetDestinos()
        {
            var destinos = await _httpClient.GetFromJsonAsync<ResponseDTO<List<Destino>>>("/api/destino/getDestinos");
            return destinos;
        }
    }
}
