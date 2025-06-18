using AppAvanza.Domain.Enums;
using System.Collections.Generic;

namespace AppAvanza.Domain.Entities
{
    public class HitoDeDominio
    {
        public int Id { get; set; }
        public int NivelId { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public AreaHito Area { get; set; }

        public Nivel Nivel { get; set; } = null!;
        public ICollection<ProgresoHito> ProgresosHitos { get; set; } = new List<ProgresoHito>();
    }
}
