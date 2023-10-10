namespace DevProjectAPI.Infrastructure.DTO
{
    public class ReturnBaseDTO
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
    public class ReturnDTO : ReturnBaseDTO
    {
        public object? ResultObject { get; set; }
    }
}

