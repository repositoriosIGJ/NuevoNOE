using Microsoft.AspNetCore.Mvc;
using NUEVO.NOE.Model.UtilidadesOracles;
using NUEVO.NOE.Service;

namespace NUEVO.NOE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerarPDFController : ControllerBase
    {
        private readonly GenerarPDFService _pdfService;

        public GenerarPDFController(GenerarPDFService pdfService)
        {
            _pdfService = pdfService;
        }

        [HttpPost("generatePDFTipoTramite")]
        public async Task<IActionResult> GeneratePDFForTipoTramite([FromBody] List<TipoTramite> tipoTramites)
        {
            var pdf = await _pdfService.GeneratePDFHtmlAsync(tipoTramites);
            return File(pdf, "application/pdf", "TipoTramite.pdf");
        }

        [HttpPost("generatePDFTipoSocietario")]
        public async Task<IActionResult> GeneratePDFForTipoSocietario([FromBody] List<TipoSocietario> tiposSocietarios)
        {
            var pdf = await _pdfService.GeneratePDFHtmlAsync(tiposSocietarios);
            return File(pdf, "application/pdf", "TipoTramite.pdf");
        }

    }
}
