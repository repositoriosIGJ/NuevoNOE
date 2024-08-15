using NUEVO.NOE.BLAZORWEB.ClientServices.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;
using System.Net.Http.Json;

namespace NUEVO.NOE.BLAZORWEB.ClientServices.Implementacion
{
    public class FuncionClientService : IFuncionesClientService
    {
        private HttpClient _httpClient;

        public FuncionClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<bool>> AddFuncion(FuncionDTO funcionDTO)
        {
            ResponseDTO<bool> rstAddFuncion = new();

            //envio los datos para el insert
            var respuestaAddRol = await _httpClient.PostAsJsonAsync("api/Funcion/AddFuncion", funcionDTO);

            if (respuestaAddRol.IsSuccessStatusCode)
            {

                //la respuesta la deserializo en responseDTO para el return
                rstAddFuncion = await respuestaAddRol.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            }
            else
            {
                var errorContent = await respuestaAddRol.Content.ReadAsStringAsync();
                // almaceno el  error content en el Message de la respuesta
                rstAddFuncion.Message = $"Error: {respuestaAddRol.StatusCode}, Details: {errorContent}";
            }


            return rstAddFuncion;
        }

        public Task<ResponseDTO<bool>> DeleteFuncion(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<FuncionDTO>> GetFuncionById(int id)
        {
            var rspfuncion = _httpClient.GetFromJsonAsync<ResponseDTO<FuncionDTO>>($"api/Funcion/GetFuncionById?id={id}");
            return rspfuncion;
        }

        public async Task<ResponseDTO<List<FuncionDTO>>> GetFunciones()
        {
            var rspFunciones = await _httpClient.GetFromJsonAsync<ResponseDTO<List<FuncionDTO>>>("api/Funcion/GetAllFunciones");


            return rspFunciones;
        }

        public async Task<ResponseDTO<List<FuncionDTO>>> GetFuncionesAssignedToRol(int rolId)
        {
            var rspFuncionesAssignedToRol = await _httpClient.GetFromJsonAsync<ResponseDTO<List<FuncionDTO>>>($"api/FuncionRol/GetFuncionesAssignedToRol?idRol={rolId}");


            return rspFuncionesAssignedToRol;
        }

        public async Task<ResponseDTO<List<FuncionDTO>>> GetFuncionNotAssignedToRol(int rolId)
        {
            var rspFuncionesNotAssignedToRol = await _httpClient.GetFromJsonAsync<ResponseDTO<List<FuncionDTO>>>($"api/FuncionRol/GetFuncionesNotAssignedToRol?idRol={rolId}");


            return rspFuncionesNotAssignedToRol;
        }

        public async Task<ResponseDTO<FuncionDTO>> UpdateFuncion(FuncionDTO funcionDTO)
        {
            ResponseDTO<FuncionDTO> rstUpdateRol = new();

            //envio los datos para el insert
            var respuestaEditFuncion = await _httpClient.PutAsJsonAsync("api/Funcion/UpdateFuncion", funcionDTO);

            if (respuestaEditFuncion.IsSuccessStatusCode)
            {

                //la respuesta la deserializo en responseDTO para el return
                rstUpdateRol = await respuestaEditFuncion.Content.ReadFromJsonAsync<ResponseDTO<FuncionDTO>>();
            }
            else
            {
                var errorContent = await respuestaEditFuncion.Content.ReadAsStringAsync();
                // almaceno el  error content en el Message de la respuesta
                rstUpdateRol.Message = $"Error: {respuestaEditFuncion.StatusCode}, Details: {errorContent}";
            }


            return rstUpdateRol;
        }
    }
}
