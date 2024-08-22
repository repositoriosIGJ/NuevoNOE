using Microsoft.AspNetCore.Mvc;
using NUEVO.NOE.Model.UtilidadesOracles;
using NUEVO.NOE.Service.Contrato;

namespace NUEVO.NOE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerarExcelController : ControllerBase
    {
        private readonly IGenerarExcelService _generarExcelService;

        public GenerarExcelController(IGenerarExcelService generarExcelService)
        {
            _generarExcelService = generarExcelService;
        }

        [HttpPost("generateExcelTipoSocietario")]
        public async Task<IActionResult> GenerateExcelTipoSocietario(List<TipoSocietario> tiposSocietarios)
        {
            var excelBytes = await _generarExcelService.GenerateExcelAsync(tiposSocietarios);

            return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "TipoSocietario.xlsx");
        }


        [HttpPost("generateExcelTipoTramite")]
        public async Task<IActionResult> GenerateExcelTipoTramite(List<TipoTramite> tipoTramite)
        {
            var excelBytes = await _generarExcelService.GenerateExcelAsync(tipoTramite);

            return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "TipoSocietario.xlsx");
        }
    }
}
