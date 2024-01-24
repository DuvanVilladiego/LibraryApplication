namespace Library.BLL
{
    public class BaseResponse<T>
    {
        public bool Status { get; set; }
        public String Message { get; set; }
        public T Data { get; set; }
        
    }
}
