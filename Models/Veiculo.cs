﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeEstacionamento.Models
{
    [Table("Veiculos")]
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Placa { get; set; }
        [ForeignKey("TipoVeiculo")]
        public int IdTipoVeiculo { get; set; }
        public virtual TipoVeiculo TipoVeiculo { get; set; }
        public string? LocalEstacionado { get; set; }
        [ForeignKey("TipoDia")]
        public int IdTipoDia { get; set; }
        public virtual TipoDia TipoDia { get; set; }
        public DateTime? HoraEntrada { get; set; }
        public DateTime? HoraSaida { get; set; }
    }
}
