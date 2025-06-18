using AppAvanza.Domain.Enums;

namespace AppAvanza.Domain.Entities
{
    public class ActividadSemanal
    {
        public int Id { get; set; }
        public DiaSemana DiaSemana { get; set; }
        public int NivelId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string DescripcionPractica { get; set; } = string.Empty;
        public string LogroEsperado { get; set; } = string.Empty;

        public Nivel Nivel { get; set; } = null!;
    }
}
