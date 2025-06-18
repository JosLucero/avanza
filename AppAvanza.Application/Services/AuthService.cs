using AppAvanza.Application.Dtos.Auth;
using AppAvanza.Application.Interfaces;
using AppAvanza.Domain.Entities;
using AppAvanza.Domain.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AppAvanza.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUsuarioRepository usuarioRepository, IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
        }

        public async Task<Usuario> RegistrarFacilitadorAsync(RegistroFacilitadorDto registroDto)
        {
            if (await _usuarioRepository.ExistsByEmailAsync(registroDto.Email))
            {
                throw new ArgumentException("El correo electrónico ya está registrado.");
            }

            var usuario = new Usuario
            {
                Nombre = registroDto.Nombre,
                Email = registroDto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registroDto.Password),
                Rol = RolUsuario.Facilitador
            };

            await _usuarioRepository.AddAsync(usuario);
            return usuario;
        }

        public async Task<TokenDto?> LoginAsync(LoginDto loginDto)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(loginDto.Email);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, usuario.PasswordHash))
            {
                return null;
            }

            var jwtSettings = _configuration.GetSection("JwtSettings");
            var keyString = jwtSettings["Key"];
            if (string.IsNullOrEmpty(keyString))
            {
                throw new InvalidOperationException("JWT Key is not configured.");
            }
            var key = Encoding.ASCII.GetBytes(keyString);

            var durationInMinutesString = jwtSettings["DurationInMinutes"];
            if (string.IsNullOrEmpty(durationInMinutesString) || !double.TryParse(durationInMinutesString, out double durationInMinutes))
            {
                throw new InvalidOperationException("JWT DurationInMinutes is not configured or invalid.");
            }

            var issuer = jwtSettings["Issuer"];
            if (string.IsNullOrEmpty(issuer))
            {
                throw new InvalidOperationException("JWT Issuer is not configured.");
            }

            var audience = jwtSettings["Audience"];
            if (string.IsNullOrEmpty(audience))
            {
                throw new InvalidOperationException("JWT Audience is not configured.");
            }

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim(JwtRegisteredClaimNames.Name, usuario.Nombre),
                new Claim(ClaimTypes.Role, usuario.Rol.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(durationInMinutes),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(securityToken);

            return new TokenDto
            {
                AccessToken = tokenString,
                ExpiresIn = tokenDescriptor.Expires.Value
            };
        }
    }
}
