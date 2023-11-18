using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeEstacionamento.Models
{
    [Table("Veiculos")]
    public class Veiculo
    {
        public string Nome { get; set; }
        [Key]
        public string Placa { get; set; }
        [ForeignKey("TipoVeiculo")]
        public int IdTipo { get; set; }
        public virtual TipoVeiculo TipoVeiculo { get; set; }
    }
}
