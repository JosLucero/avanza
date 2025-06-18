using AppAvanza.Domain.Enums;
using System.Collections.Generic;

namespace AppAvanza.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public RolUsuario Rol { get; set; }

        // Propiedad de navegación para los aprendices asociados a este facilitador
        public ICollection<Aprendiz> Aprendices { get; set; } = new List<Aprendiz>();
    }
}
