using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeEstacionamento.Models
{
    [Table("TiposDias")]
    public class TipoDia
    {
        [Key]
        public int Id { get; set; }
        public string Dia { get; set; }
        
    }
}
