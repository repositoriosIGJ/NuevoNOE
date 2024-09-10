using AutoMapper;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model;
using NUEVO.NOE.Model.UtilidadesOracles;
using NUEVO.NOE.Repository.DatosCiviles.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace NUEVO.NOE.Repository.DatosCiviles.Implementacion
{
    public class DatosCivilesRepository : IDatosCivilesRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public DatosCivilesRepository(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        public async Task<ResponseDTO<List<PersoneriaCiviles>>> GetDatosCiviles(FiltrosDatosCiviles filtro)
        {
            ResponseDTO<List<PersoneriaCiviles>> response = new();
            response.IsSuccess = false;

            try
            {
                // Realizamos la solicitud POST con los filtros
                var respuesta = await _httpClient.PostAsJsonAsync($"api/datosciviles", filtro);

                // Verificamos si la respuesta es exitosa
                if (respuesta.IsSuccessStatusCode)
                {
                    // Leemos el contenido de la respuesta como JSON y lo deserializamos
                    var jsonResponse = await respuesta.Content.ReadFromJsonAsync<List<PersoneriaCiviles>>();

                    response.IsSuccess = true;
                    response.Data = jsonResponse;
                    response.Message = "ok";
                }
                else
                {
                    response.Message = $"Error en la solicitud: {respuesta.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            };
            return response;
        }
    }
}
