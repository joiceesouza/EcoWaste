namespace EcoWaste.Core.DTOs
{
    public class PontoColetaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public List<string> TiposResiduosAceitos { get; set; } = new();
    }
}