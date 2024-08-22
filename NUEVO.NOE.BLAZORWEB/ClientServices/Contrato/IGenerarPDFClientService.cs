using NUEVO.NOE.DTO;

namespace NUEVO.NOE.BLAZORWEB.ClientServices.Contrato
{
    public interface IGenerarPDFClientService
    {
        Task<ResponseDTO<byte[]>> GeneratePDFHtmlFormat<T>(List<T> items, string url);
    }
}
