public class Coleta
{
    public int Id { get; set; }
    public DateTime DataHora { get; set; } = DateTime.UtcNow;
    public int ResiduoId { get; set; }
    public Residuo? Residuo { get; set; }
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
    public decimal QuantidadeKg { get; set; }
}
