using System;

namespace AppAvanza.Application.Dtos.Auth
{
    public class TokenDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public DateTime ExpiresIn { get; set; }
    }
}
