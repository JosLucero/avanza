using System;

namespace AppAvanza.Domain.Entities
{
    public class RegistroDiario
    {
        public int Id { get; set; }
        public int AprendizId { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; } = string.Empty;

        public Aprendiz Aprendiz { get; set; } = null!;
    }
}
