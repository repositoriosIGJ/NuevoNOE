using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.UtilidadesOracles;

namespace NUEVO.NOE.Service.OracleService.Contrato
{
    public interface ITipoSocietarioService
    {
        Task<ResponseDTO<IEnumerable<TipoSocietario>>> GetTiposSocietarios();
        Task<ResponseDTO<IEnumerable<TipoSocietario>>> GetCodigosSinCeroALaIzq();
        Task<ResponseDTO<TipoSocietario>> GetByCodigoTipoSocietario(string codigo);
        Task<ResponseDTO<IEnumerable<TipoSocietario>>> GetByTipo(string tipo);
    }
}
