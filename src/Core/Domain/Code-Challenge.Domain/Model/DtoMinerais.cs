using Code_Challenge.Domain.Emuns;

namespace Code_Challenge.Domain.Model
{
    public class DtoMinerais
    {
        public DateTime DataSaida { get; set; }
        public DateTime? DataRetorno { get; set; }
        public List<TipoCargueiro> TipoCargueiro { get; set; }
        public double ValorTotalCarga { get; set; }
        public int QuantidadeCarga { get; set; }
    }
}
