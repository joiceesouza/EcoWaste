namespace EcoWaste.Core.Entities
{
    public class PontoColeta
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;

        public required string TiposResiduosAceitos { get; set; }
        public ICollection<PontoColetaResiduo> PontoColetaResiduos { get; set; } = new List<PontoColetaResiduo>();

    }
}