namespace aroshopapi
{
    public class AuthenticationSettings
    {
        public string JwtKey { get; set; }
        public string JwtIssuer { get; set;}
        public int JwtExpiryDays { get; set; }
    }
}
