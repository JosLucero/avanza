using System.Collections.Generic;

namespace AppAvanza.Domain.Entities
{
    public class Nivel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string ObjetivoCentral { get; set; } = string.Empty;

        public ICollection<HitoDeDominio> HitosDeDominio { get; set; } = new List<HitoDeDominio>();
        public ICollection<ActividadSemanal> ActividadesSemanales { get; set; } = new List<ActividadSemanal>();
        public ICollection<Aprendiz> AprendicesEnEsteNivel { get; set; } = new List<Aprendiz>();
    }
}
