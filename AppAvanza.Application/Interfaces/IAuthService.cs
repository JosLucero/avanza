using AppAvanza.Domain.Entities;
using AppAvanza.Application.Dtos.Auth;
using System.Threading.Tasks;

namespace AppAvanza.Application.Interfaces
{
    public interface IAuthService
    {
        Task<Usuario> RegistrarFacilitadorAsync(RegistroFacilitadorDto registroDto);
        Task<TokenDto?> LoginAsync(LoginDto loginDto);
    }
}
