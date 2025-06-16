namespace EcoWaste.Core.Entities
{
    public class Residuo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public ICollection<Coleta>? Coletas { get; set; }
        public ICollection<PontoColetaResiduo> PontoColetaResiduos { get; set; }
    }
}
