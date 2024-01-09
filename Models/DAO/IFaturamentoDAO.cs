using SistemaDeEstacionamento.Models.DTO;

namespace SistemaDeEstacionamento.Models.DAO
{
    public interface IFaturamentoDAO
    {
        public List<ValorVeiculo> ListarPrecosVeiculos(int dia);
        public decimal RetornaPrecoVeiculoPorDia(int idTipoVeiculo, int idTipoDia);
        public void AdicionarNovoTipoVeiculo(string nome, decimal valor);
        public void AlterarValorTipoVeiculo(int tipoVeiculo, int dia, decimal valor);
        public void ExcluirTipoVeiculo(int id);
        public void AdicionarValorDia(string dia);
        public void AlterarValorDia(int dia);
        //public float CalcularValorPorHora(int tipoVeiculo, int tipoDia, DateTime horaEntrada, DateTime horaSaida, int desconto = 0);
        public void RegistrarPagamentoPorHoraEstacionada(RegistrarSaidaDTO dadosVeiculoSaida);
        public void RegistrarPagamentoAvulso(RegistrarSaidaDTO dadosVeiculoSaida);
        public List<TipoPagamento> RetornarFormasPagamento();
        public List<ClienteVeiculoValor> RetornarEntradaDeValoresPeloDia(DateTime diaAtual);
        public List<Despesa> RetornarSaidaDeValoresPeloDia(DateTime diaAtual);
    }
}
