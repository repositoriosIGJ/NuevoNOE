using NUEVO.NOE.Model.UtilidadesOracles;

namespace NUEVO.NOE.Service.OracleService.Contrato
{
    public interface ITipoSocietarioService
    {
        Task<IEnumerable<TipoSocietario>> GetTiposSocietarios();
        Task<List<TipoSocietario>> GetCodigosSinCeroALaIzq();
        Task<TipoSocietario> GetByCodigoTipoSocietario(string codigo);
        Task<IEnumerable<TipoSocietario>> GetByTipo(string tipo);
    }
}
