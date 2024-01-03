using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeEstacionamento.Models
{
    [Table("Lembretes")]
    public class Lembrete
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
    }
}
