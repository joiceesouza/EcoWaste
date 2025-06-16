namespace EcoWaste.Core.Entities;

public class Coleta
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;

    public int ResiduoId { get; set; }
    public int UsuarioId { get; set; }
    public double QuantidadeKg { get; set; }
    public DateTime DataHora { get; set; }

    // Relacionamentos opcionais:
    public Residuo? Residuo { get; set; }
}