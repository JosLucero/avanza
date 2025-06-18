using System.Collections.Generic;

namespace AppAvanza.Domain.Entities
{
    public class Aprendiz
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int FacilitadorId { get; set; }
        public int NivelActualId { get; set; }

        public Usuario Facilitador { get; set; } = null!;
        public Nivel NivelActual { get; set; } = null!;
        public ICollection<ProgresoHito> ProgresosHitos { get; set; } = new List<ProgresoHito>();
        public ICollection<RegistroDiario> RegistrosDiarios { get; set; } = new List<RegistroDiario>();
        public ICollection<ElementoParkingFrustracion> ElementosParking { get; set; } = new List<ElementoParkingFrustracion>();
        public ICollection<Logro> Logros { get; set; } = new List<Logro>();
    }
}
