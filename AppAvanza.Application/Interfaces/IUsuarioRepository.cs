using AppAvanza.Domain.Entities;
using System.Threading.Tasks;

namespace AppAvanza.Application.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetByEmailAsync(string email);
        Task AddAsync(Usuario usuario);
        Task<bool> ExistsByEmailAsync(string email);
    }
}
