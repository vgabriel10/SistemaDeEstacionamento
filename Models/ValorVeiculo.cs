using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeEstacionamento.Models
{
    [Table("ValorVeiculo")]
    public class ValorVeiculo 
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("TipoVeiculo")]
        public int IdTipoVeiculo { get; set; }
        public virtual TipoVeiculo TipoVeiculo { get; set; }
        [ForeignKey("TipoDia")]
        public int IdDia { get; set; }
        public virtual TipoDia TipoDia { get; set; }
        public decimal ValorHora { get; set; }
        public decimal? Promocao { get; set; }
    }
}
