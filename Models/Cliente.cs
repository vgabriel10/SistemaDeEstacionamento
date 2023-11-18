using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeEstacionamento.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }
        [ForeignKey("Veiculo")]
        public string Placa { get; set; }
        public virtual Veiculo Veiculo { get; set; }
    }
}
