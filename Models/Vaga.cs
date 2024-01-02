using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeEstacionamento.Models
{
    [Table("Vagas")]
    [Keyless] // Usar para tabelas sem chave primaria
    public class Vaga
    {
        public int TotalVagas { get; set; }
        public int VagasDisponiveis { get; set; }
        public int VagasOcupadas { get; set; }
    }
}
