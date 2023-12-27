
namespace SistemaDeEstacionamento.Models.DTO
{
    public class DadosEntradaSaidaVeiculoDTO
    {
        public int IdVeiculo { get; set; }
        public int IdCliente { get; set; }
        public int TipoDia { get; set; }
        public string NomeCliente { get; set; }
        public string NomeCliente2 { get; set; }
        public string? Cpf { get; set; }
        public string Telefone { get; set; }
        public string Local { get; set; }
        public int TipoVeiculo { get; set; }
        public string NomeVeiculo { get; set; }
        public string Placa { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime? HoraSaida { get; set; }

    }
}

