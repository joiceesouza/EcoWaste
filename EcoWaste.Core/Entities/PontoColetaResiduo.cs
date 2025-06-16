namespace EcoWaste.Core.Entities
{
    public class PontoColetaResiduo
    {
        public int PontoColetaId { get; set; }
        public PontoColeta PontoColeta { get; set; }

        public int ResiduoId { get; set; }
        public Residuo Residuo { get; set; }
    }
}