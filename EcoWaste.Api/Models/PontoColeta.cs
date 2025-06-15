public class PontoColeta
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public List<Residuo> TiposResiduosAceitos { get; set; } = new();
}
