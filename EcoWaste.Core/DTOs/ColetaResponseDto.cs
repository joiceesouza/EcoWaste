namespace EcoWaste.Core.DTOs;

public class ColetaResponseDto
{
    public string Descricao { get; set; } = string.Empty;

    public string ResiduoTipo { get; set; } = string.Empty;
    public double QuantidadeKg { get; set; }
    public DateTime DataHora { get; set; }
    public int Id { get; set; }
}