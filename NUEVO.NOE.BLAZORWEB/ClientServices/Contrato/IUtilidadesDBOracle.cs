using NUEVO.NOE.Model.UtilidadesOracles;

namespace NUEVO.NOE.BLAZORWEB.ClientServices.Contrato
{
    public interface IUtilidadesDBOracle
    {
        Task<IEnumerable<TipoTramite>> GetTipoTramites();
        Task<IEnumerable<TipoSocietario>> GetTipoSocietario();
    }
}
