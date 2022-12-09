namespace VendingMachineBackend.Dtos
{
    public class Result<T> where T : class
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Value { get; set; }

        public Result(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public Result(bool success, string message, T value)
        {
            Success = success;
            Message = message;
            Value = value;
        }
    }    
}
