using System;

namespace AppAvanza.Domain.Entities
{
    public class ElementoParkingFrustracion
    {
        public int Id { get; set; }
        public int AprendizId { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public bool Aparcado { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Aprendiz Aprendiz { get; set; } = null!;
    }
}
