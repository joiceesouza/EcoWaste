namespace EcoWaste.Core.Entities
{
    public class Residuo
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;

        public ICollection<Coleta>? Coletas { get; set; } = new List<Coleta>();
        public List<PontoColetaResiduo> PontoColetaResiduos { get; set; } = new List<PontoColetaResiduo>();
    }
}
