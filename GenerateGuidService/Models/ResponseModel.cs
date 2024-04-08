namespace GenerateGuidService.Models
{
    public class ResponseModel<T>
    {
        public int Code { get; set; }
        public T Message { get; set; }
    }
}
