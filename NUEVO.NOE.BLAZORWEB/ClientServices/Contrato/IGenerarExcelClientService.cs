using NUEVO.NOE.DTO;

namespace NUEVO.NOE.BLAZORWEB.ClientServices.Contrato
{
    public interface IGenerarExcelClientService
    {
        Task<ResponseDTO<byte[]>> GenerateExcel<T>(List<T> items, string url);
    }
}
