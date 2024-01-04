using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeEstacionamento.Models
{
    [Table("TiposPagamentos")]
    public class TipoPagamento
    {
        [Key]
        public int Id { get; set; }
        public string FormaPagamento { get; set; }
        
    }
}
