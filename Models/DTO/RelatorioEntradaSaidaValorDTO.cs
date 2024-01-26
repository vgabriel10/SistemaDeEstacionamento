
namespace SistemaDeEstacionamento.Models.DTO
{
    public class RelatorioEntradaSaidaValorDTO
    {
        public string Tipo { get; set; }
        public DateTime DataPagamento { get; set; }
        public string FormaPagamento { get; set; }
        public decimal Valor { get; set; }
    }
}
