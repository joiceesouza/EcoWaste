public class ColetaResponseDto
{
    public int Id { get; set; }
    public string ResiduoTipo { get; set; } = string.Empty;
    public decimal QuantidadeKg { get; set; }
    public DateTime DataHora { get; set; }
}