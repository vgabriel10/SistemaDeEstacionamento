using System.ComponentModel.DataAnnotations;

namespace SistemaDeEstacionamento.Models.DTO
{
    public class RegistrarSaidaDTO
    {
        //int idVeiculo, int idCliente, DateTime horaSaida, string tipoPagamento, int desconto, float valorBruto, float valorTotal
        [Required]
        public int IdVeiculo { get; set; }
        public int TipoVeiculo { get; set; }
        [Required]
        public int IdCliente { get; set; }
        public int TipoDia { get; set; }
        public string TempoEstacionado { get; set; }
        public DateTime HoraEntrada { get; set; }
        [Required]
        public DateTime HoraSaida { get; set; }
        public int TipoPagamento { get; set; }
        public decimal? Desconto { get; set; }
        public decimal ValorBruto { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorAvulso { get; set; }

    }
}
