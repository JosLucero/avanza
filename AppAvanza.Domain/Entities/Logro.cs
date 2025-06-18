using System;

namespace AppAvanza.Domain.Entities
{
    public class Logro
    {
        public int Id { get; set; }
        public int AprendizId { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }

        public Aprendiz Aprendiz { get; set; } = null!;
    }
}
