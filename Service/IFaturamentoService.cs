using SistemaDeEstacionamento.Models;
using SistemaDeEstacionamento.Models.DTO;

namespace SistemaDeEstacionamento.Service
{
    public interface IFaturamentoService
    {
        public List<ValorVeiculo> ListarPrecosVeiculos(int dia);
        public decimal RetornaPrecoVeiculoPorDia(int idTipoVeiculo, int idTipoDia);
        public void AdicionarNovoTipoVeiculo(string nome, decimal valor);
        public void AlterarValorTipoVeiculo(int tipoVeiculo, int dia, decimal valor);
        public void ExcluirTipoVeiculo(int id);
        //public TipoDia RetornarValorTipoVeiculoPorDia(int tipoVeiculo, DateTime data);
        public void AdicionarValorDia(string dia);
        public void AlterarValorDia(int dia);
        public RegistrarSaidaDTO CalcularValorPorHora(RegistrarSaidaDTO dadosVeiculoSaida);
        public void RegistrarPagamentoPorHoraEstacionada(RegistrarSaidaDTO dadosVeiculoSaida);
        public void RegistrarPagamentoAvulso(RegistrarSaidaDTO dadosVeiculoSaida);
    }
}
