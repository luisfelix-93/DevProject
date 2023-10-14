namespace DevProjectAPI.Infrastructure.Entities
{
    public class Token
    {
        public const string TokenType = "Bearer";
        public string? AccessToken { get; set; }
        public string? UserName { get; set; }
        public DateTime? DateTimeExpiration { get; set; }
        public long TotalSecondsExpiration { get; set; }
    }
}
