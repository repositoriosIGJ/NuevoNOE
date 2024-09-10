using NUEVO.NOE.Model.UtilidadesOracles;
using NUEVO.NOE.Model;
using NUEVO.NOE.DTO;


namespace NUEVO.NOE.BLAZORWEB.ClientServices.Contrato
{
    public interface IUtilidadesDBOracle
    {
        Task<IEnumerable<TipoTramite>> GetTipoTramites();
        Task<IEnumerable<TipoSocietario>> GetTipoSocietario();

        Task<ResponseDTO<List<PersoneriaCiviles>>> GetPersoneriaCiviles(FiltrosDatosCiviles filtros);

    }
}
