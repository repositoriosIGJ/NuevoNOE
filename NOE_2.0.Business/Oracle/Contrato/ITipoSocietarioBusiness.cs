using NUEVO.NOE.Model.UtilidadesOracles;

namespace NUEVO.NOE.Business.Oracle.Contrato
{
    public interface ITipoSocietarioBusiness
    {
        Task<IEnumerable<TipoSocietario>> GetTiposSocietarios();
        Task<IEnumerable<TipoSocietario>> GetTiposSocietariosCodigosSinCeroALaIzq();
        Task<TipoSocietario> GetTipoSocietarioPorCodigo(string codigo);
        Task<IEnumerable<TipoSocietario>> GetTipoSocietarioPorTipo(string tipo);
    }
}
