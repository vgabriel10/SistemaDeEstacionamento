using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeEstacionamento.Models
{
    [Table("TiposVeiculos")]
    public class TipoVeiculo
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
