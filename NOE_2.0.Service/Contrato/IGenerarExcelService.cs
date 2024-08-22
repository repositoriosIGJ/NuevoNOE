namespace NUEVO.NOE.Service.Contrato
{
    public interface IGenerarExcelService
    {
        Task<byte[]> GenerateExcelAsync<T>(List<T> items);
    }
}
