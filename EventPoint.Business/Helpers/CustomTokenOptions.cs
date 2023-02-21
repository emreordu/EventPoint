namespace EventPoint.Business.Helpers
{
    public class CustomTokenOptions
    {
        public int AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}