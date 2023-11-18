using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeEstacionamento.Models
{
    [Table("ValorVeiculo")]
    public class ValorVeiculo 
    {
        [Key]
        public int IdTipo { get; set; }
        public int Dia { get; set; }
        public float ValorHora { get; set; }
        public float? Promocao { get; set; }
    }
}
