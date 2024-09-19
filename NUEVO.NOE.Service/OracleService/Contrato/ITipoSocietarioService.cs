using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.UtilidadesOracles;

namespace NUEVO.NOE.Service.OracleService.Contrato
{
    public interface ITipoSocietarioService
    {
        Task<ResponseDTO<IEnumerable<TipoSocietario>>> GetTiposSocietarios();
        Task<IEnumerable<TipoSocietario>> GetCodigosSinCeroALaIzq();
        Task<TipoSocietario> GetByCodigoTipoSocietario(string codigo);
        Task<IEnumerable<TipoSocietario>> GetByTipo(string tipo);
    }
}
