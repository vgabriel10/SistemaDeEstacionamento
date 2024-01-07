using Microsoft.EntityFrameworkCore;
using SistemaDeEstacionamento.Helpers;
using SistemaDeEstacionamento.Models.DTO;
using SistemaDeEstacionamento.Service;
using System.Globalization;

namespace SistemaDeEstacionamento.Models.DAO
{
    public class FaturamentoService : IFaturamentoService
    {
        #region Injeção de dependencia 
        private readonly IFaturamentoDAO _faturamentoDAO;

        public FaturamentoService(IFaturamentoDAO faturamentoDAO)
        {
            _faturamentoDAO = faturamentoDAO;
        }


        #endregion
        public void AdicionarNovoTipoVeiculo(string nome, decimal valor)
        {
            _faturamentoDAO.AdicionarNovoTipoVeiculo(nome,valor);
        }

        public void AdicionarValorDia(string dia)
        {
            _faturamentoDAO.AdicionarValorDia(dia);
        }

        public void AlterarValorDia(int dia)
        {
            _faturamentoDAO.AlterarValorDia(dia);
        }

        public void AlterarValorTipoVeiculo(int tipoVeiculo, int dia, decimal valor)
        {
            _faturamentoDAO.AlterarValorTipoVeiculo(tipoVeiculo,dia, valor);
        }

        public void RegistrarPagamentoPorHoraEstacionada(RegistrarSaidaDTO dadosVeiculoSaida)
        {
            decimal valorBruto = 0, valorTotal = 0, desconto = 0;
            decimal precoHora = RetornaPrecoVeiculoPorDia(dadosVeiculoSaida.TipoVeiculo, dadosVeiculoSaida.TipoDia);
            var tempoEstacionado = dadosVeiculoSaida.HoraSaida - dadosVeiculoSaida.HoraEntrada;
            dadosVeiculoSaida.TempoEstacionado = tempoEstacionado.ToString();
            double quantMinutos = tempoEstacionado.TotalMinutes;
            double quantHoras = quantMinutos / 60;
            if (quantHoras < 0 )
            {
                valorBruto = precoHora;
            }
            else
            {
                valorBruto = precoHora * (int)quantHoras;
            }
            if(dadosVeiculoSaida.Desconto != null && dadosVeiculoSaida.Desconto != 0)
            {
                desconto = (decimal)(dadosVeiculoSaida.Desconto / 100) * valorBruto;
            }
            dadosVeiculoSaida.ValorBruto = valorBruto;
            dadosVeiculoSaida.ValorTotal = valorBruto - desconto;
            _faturamentoDAO.RegistrarPagamentoPorHoraEstacionada(dadosVeiculoSaida);
        }

        public void ExcluirTipoVeiculo(int id)
        {
            _faturamentoDAO.ExcluirTipoVeiculo(id);
        }

        public List<ValorVeiculo> ListarPrecosVeiculos(int dia)
        {
            return _faturamentoDAO.ListarPrecosVeiculos(dia);
        }

        public decimal RetornaPrecoVeiculoPorDia(int idTipoVeiculo, int idTipoDia)
        {
            return _faturamentoDAO.RetornaPrecoVeiculoPorDia(idTipoVeiculo, idTipoDia);
        }

        public RegistrarSaidaDTO CalcularValorPorHora(RegistrarSaidaDTO dadosVeiculoSaida)
        {
            decimal valorBruto = 0, valorTotal = 0, desconto = 0;
            decimal precoHora = RetornaPrecoVeiculoPorDia(dadosVeiculoSaida.TipoVeiculo, dadosVeiculoSaida.TipoDia);
            var tempoEstacionado = dadosVeiculoSaida.HoraSaida - dadosVeiculoSaida.HoraEntrada;
            dadosVeiculoSaida.TempoEstacionado = tempoEstacionado.ToString();
            double quantMinutos = tempoEstacionado.TotalMinutes;
            double quantHoras = quantMinutos / 60;
            if (quantHoras <= 0)
            {
                valorBruto = precoHora;
            }
            else
            {
                valorBruto = precoHora * (int)quantHoras;
            }
            if (dadosVeiculoSaida.Desconto != null && dadosVeiculoSaida.Desconto != 0)
            {
                desconto = (decimal)(dadosVeiculoSaida.Desconto / 100) * valorBruto;
            }
            dadosVeiculoSaida.ValorBruto = valorBruto;
            dadosVeiculoSaida.ValorTotal = valorBruto - desconto;
            
            return dadosVeiculoSaida;
        }

        public void RegistrarPagamentoAvulso(RegistrarSaidaDTO dadosVeiculoSaida)
        {
            var tempoEstacionado = dadosVeiculoSaida.HoraSaida - dadosVeiculoSaida.HoraEntrada;
            dadosVeiculoSaida.TempoEstacionado = tempoEstacionado.ToString();
            _faturamentoDAO.RegistrarPagamentoAvulso(dadosVeiculoSaida);
        }

        public List<TipoPagamento> RetornarFormasPagamento()
        {
            return _faturamentoDAO.RetornarFormasPagamento();
        }

        public List<ClienteVeiculoValor> RetornarEntradaDeValoresPeloDia(DateTime diaAtual)
        {
            return _faturamentoDAO.RetornarEntradaDeValoresPeloDia(diaAtual);
        }
    }
}
