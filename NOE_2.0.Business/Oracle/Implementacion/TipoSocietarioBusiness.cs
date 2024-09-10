using NUEVO.NOE.Business.Oracle.Contrato;
using NUEVO.NOE.Model.UtilidadesOracles;
using NUEVO.NOE.Service.OracleService.Contrato;

namespace NUEVO.NOE.Business.Oracle.Implementacion
{
    public class TipoSocietarioBusiness : ITipoSocietarioBusiness

    {
        private readonly ITipoSocietarioService _tipoSocietarioservice;


        public TipoSocietarioBusiness(ITipoSocietarioService tipoSocietarioservice)
        {
            _tipoSocietarioservice = tipoSocietarioservice;
        }

        public async Task<TipoSocietario> GetTipoSocietarioPorCodigo(string codigo)
        {
            var rst = await _tipoSocietarioservice.GetByCodigoTipoSocietario(codigo);

            return rst;
        }

        public async Task<IEnumerable<TipoSocietario>> GetTipoSocietarioPorTipo(string tipo)
        {
            var rst = await _tipoSocietarioservice.GetByTipo(tipo);

            return rst;
        }

        public async Task<IEnumerable<TipoSocietario>> GetTiposSocietarios()
        {
            var rst = await _tipoSocietarioservice.GetTiposSocietarios();

            return rst;
        }

        public async Task<IEnumerable<TipoSocietario>> GetTiposSocietariosCodigosSinCeroALaIzq()
        {
            var rst = await _tipoSocietarioservice.GetCodigosSinCeroALaIzq();

            return rst;
        }


    }
}
