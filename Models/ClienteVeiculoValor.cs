using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeEstacionamento.Models
{
    [Table("ClientesVeiculosValores")]
    public class ClienteVeiculoValor
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }    
        [ForeignKey("TipoVeiculo")]
        public int? IdTipoVeiculo { get; set; }
        public virtual TipoVeiculo TipoVeiculo { get; set; }
        [ForeignKey("Veiculo")]
        public int? IdVeiculo { get; set; }
        public virtual Veiculo Veiculo { get; set; }
        public DateTime DataDePagamento { get; set; }
        public string TempoEstacionado { get; set; }
        public decimal ValorBruto { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
