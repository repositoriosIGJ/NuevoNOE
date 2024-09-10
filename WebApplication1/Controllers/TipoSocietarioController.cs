using Microsoft.AspNetCore.Mvc;
using NUEVO.NOE.Business.Oracle.Contrato;
using NUEVO.NOE.Model.UtilidadesOracles;

namespace NUEVO.NOE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoSocietarioController : ControllerBase
    {
        private readonly ITipoSocietarioBusiness _tipoSocietarioBusiness;

        public TipoSocietarioController(ITipoSocietarioBusiness tipoSocietarioBusiness)
        {
            _tipoSocietarioBusiness = tipoSocietarioBusiness;
        }

        [HttpGet("GetTiposSocietarios")]
        public async Task<IEnumerable<TipoSocietario>> GetTiposSocietarios()
        {

            var tiposSocietarios = await _tipoSocietarioBusiness.GetTiposSocietarios();

            return tiposSocietarios;
        }


        [HttpGet("GetTiposSocietariosCodigosSinCeroALaIzq")]
        public async Task<IEnumerable<TipoSocietario>> GetTiposSocietariosCodigosSinCeroALaIzq()
        {
            var rst = await _tipoSocietarioBusiness.GetTiposSocietariosCodigosSinCeroALaIzq();

            return rst;
        }

        [HttpGet("GetTipoSocietarioPorCodigo")]
        public async Task<TipoSocietario> GetTipoSocietarioPorCodigo(string codigo)
        {
            var rst = await _tipoSocietarioBusiness.GetTipoSocietarioPorCodigo(codigo);

            return rst;
        }


        [HttpGet("GetTipoSocietarioPorTipo")]
        public async Task<IEnumerable<TipoSocietario>> GetTipoSocietarioPorTipo(string tipo)
        {
            var rst = await _tipoSocietarioBusiness.GetTipoSocietarioPorTipo(tipo);

            return rst;
        }

    }
}
