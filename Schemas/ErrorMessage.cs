namespace ClientsApi.Schemas
{
    public class ErrorMessage
    {
        public string Field { get; set; }
        public string Message { get; set; }
        public string Validation { get; set; }
    }
}