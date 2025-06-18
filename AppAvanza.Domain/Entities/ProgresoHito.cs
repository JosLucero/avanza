using System;

namespace AppAvanza.Domain.Entities
{
    public class ProgresoHito
    {
        public int Id { get; set; }
        public int AprendizId { get; set; }
        public int HitoDeDominioId { get; set; }
        public bool Completado { get; set; }
        public DateTime? FechaCompletado { get; set; }

        public Aprendiz Aprendiz { get; set; } = null!;
        public HitoDeDominio HitoDeDominio { get; set; } = null!;
    }
}
