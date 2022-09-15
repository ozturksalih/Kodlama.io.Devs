namespace Application.Features.Users.Dtos
{
    public class LoggedUserDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}