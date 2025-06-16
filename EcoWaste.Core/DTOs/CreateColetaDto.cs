namespace EcoWaste.Core.DTOs;

public class CreateColetaDto
{
    public string Descricao { get; set; } = string.Empty;

    public int ResiduoId { get; set; }
    public double QuantidadeKg { get; set; }
}