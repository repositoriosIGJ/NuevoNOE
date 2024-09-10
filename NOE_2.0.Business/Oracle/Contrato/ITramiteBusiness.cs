using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.UtilidadesOracles;

namespace NUEVO.NOE.Business.Oracle.Contrato
{
    public interface ITramiteBusiness
    {
        Task<ResponseDTO<List<Tramite>>> GetTramites(Tramite tramite);
    }
}
