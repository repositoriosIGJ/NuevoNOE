namespace NUEVO.NOE.DTO
{
    public class ResponseDTO<T>
    {
        public T? Data { get; set; }

        public bool IsSuccess { get; set; }

        public string? Message { get; set; }
    }
}
