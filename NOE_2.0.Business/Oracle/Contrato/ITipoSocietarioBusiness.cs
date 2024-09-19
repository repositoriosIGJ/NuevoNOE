using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.UtilidadesOracles;

namespace NUEVO.NOE.Business.Oracle.Contrato
{
    public interface ITipoSocietarioBusiness
    {
        Task<ResponseDTO<IEnumerable<TipoSocietario>>> GetTiposSocietarios();
        Task<ResponseDTO<IEnumerable<TipoSocietario>>> GetTiposSocietariosCodigosSinCeroALaIzq();
        Task<ResponseDTO<TipoSocietario>> GetTipoSocietarioPorCodigo(string codigo);
        Task<ResponseDTO<IEnumerable<TipoSocietario>>> GetTipoSocietarioPorTipo(string tipo);
    }
}

