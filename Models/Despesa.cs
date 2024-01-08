using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeEstacionamento.Models
{
    [Table("Despesas")]
    public class Despesa
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataDePagamento { get; set; }
        [ForeignKey("TipoPagamento")]
        public int IdTipoPagamento { get; set; }
        public virtual TipoPagamento TipoPagamento { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
