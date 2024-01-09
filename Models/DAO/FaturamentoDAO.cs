using Microsoft.EntityFrameworkCore;
using SistemaDeEstacionamento.Models.DTO;
using System.Security.Cryptography;

namespace SistemaDeEstacionamento.Models.DAO
{
    public class FaturamentoDAO : DbContext, IFaturamentoDAO
    {
        private readonly BaseEstacionamentoContext _dbContext;

        public FaturamentoDAO(BaseEstacionamentoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AdicionarNovoTipoVeiculo(string nome, decimal valor)
        {
            var tipoVeiculo = new TipoVeiculo
            {
                Nome = nome,
                Situacao = true
            };
            _dbContext.TipoVeiculo.Add(tipoVeiculo);
            _dbContext.SaveChanges();
            var todosDias = _dbContext.TipoDia.ToList();
            //var valorVeiculo = new ValorVeiculo();
            foreach (var dia in todosDias)
            {
                var valorVeiculo = new ValorVeiculo();
                valorVeiculo.IdTipoVeiculo = tipoVeiculo.Id;
                valorVeiculo.IdDia = dia.Id;
                valorVeiculo.ValorHora = valor;
                _dbContext.ValorVeiculo.Add(valorVeiculo);
                _dbContext.SaveChanges();
            }
        }

        public void AdicionarValorDia(string dia)
        {
            throw new NotImplementedException();
        }

        public void AlterarValorDia(int dia)
        {
            ValorVeiculo precoDia = _dbContext.ValorVeiculo.Where(vv => vv.IdDia == dia).FirstOrDefault();
            //precoDia.ValorHora =  
        }

        public void AlterarValorTipoVeiculo(int tipoVeiculo, int dia, decimal valor)
        {
            ValorVeiculo valorVeiculo = _dbContext.ValorVeiculo.Where(vv => vv.IdTipoVeiculo == tipoVeiculo && vv.IdDia == dia).FirstOrDefault();
            valorVeiculo.ValorHora = valor;
            _dbContext.Update(valorVeiculo);
            _dbContext.SaveChanges();

        }

        public void RegistrarPagamentoPorHoraEstacionada(RegistrarSaidaDTO dadosVeiculoSaida)
        {
            _dbContext.ClienteVeiculoValor.Add(new ClienteVeiculoValor
            {
                IdCliente = dadosVeiculoSaida.IdCliente,
                IdVeiculo = dadosVeiculoSaida.IdVeiculo,
                IdTipoVeiculo = dadosVeiculoSaida.TipoVeiculo,
                TempoEstacionado = dadosVeiculoSaida.TempoEstacionado,
                DataDePagamento = DateTime.Now,
                IdTipoPagamento = dadosVeiculoSaida.TipoPagamento,
                ValorBruto = dadosVeiculoSaida.ValorBruto,
                ValorTotal = dadosVeiculoSaida.ValorTotal  
            });
            _dbContext.SaveChanges();
        }

        public void RegistrarPagamentoAvulso(RegistrarSaidaDTO dadosVeiculoSaida)
        {
            _dbContext.ClienteVeiculoValor.Add(new ClienteVeiculoValor
            {
                IdCliente = dadosVeiculoSaida.IdCliente,
                IdVeiculo = dadosVeiculoSaida.IdVeiculo,
                IdTipoVeiculo = dadosVeiculoSaida.TipoVeiculo,
                TempoEstacionado = dadosVeiculoSaida.TempoEstacionado,
                DataDePagamento = DateTime.Now,
                IdTipoPagamento = dadosVeiculoSaida.TipoPagamento,
                ValorBruto = dadosVeiculoSaida.ValorAvulso,
                ValorTotal = dadosVeiculoSaida.ValorAvulso
            });
            _dbContext.SaveChanges();
        }

        public void ExcluirTipoVeiculo(int id)
        {
            TipoVeiculo tipoVeiculo = _dbContext.TipoVeiculo.Where(tp => tp.Id == id).FirstOrDefault();
            tipoVeiculo.Situacao = false;
            _dbContext.Update(tipoVeiculo);
            _dbContext.SaveChanges();
        }

        public List<ValorVeiculo> ListarPrecosVeiculos(int dia)
        {
            return _dbContext.ValorVeiculo.Where(vv => vv.IdDia == dia && vv.TipoVeiculo.Situacao == true).ToList();
        }

        public decimal RetornaPrecoVeiculoPorDia(int idTipoVeiculo, int idTipoDia)
        {
            decimal valor = _dbContext.ValorVeiculo.Where(vv => vv.IdTipoVeiculo == idTipoVeiculo && vv.IdDia == idTipoDia)
                .Select(vv => vv.ValorHora).FirstOrDefault();
            return valor;
        }

        public List<TipoPagamento> RetornarFormasPagamento()
        {
            return _dbContext.TipoPagamento.ToList();
        }

        public List<ClienteVeiculoValor> RetornarEntradaDeValoresPeloDia(DateTime diaAtual)
        {
            List<ClienteVeiculoValor> entradasNoDia = _dbContext.ClienteVeiculoValor.Where(x => x.DataDePagamento.Date == diaAtual.Date).ToList();
            return entradasNoDia;
        }

        public List<Despesa> RetornarSaidaDeValoresPeloDia(DateTime diaAtual)
        {
            List<Despesa> saidasNoDia = _dbContext.Despesa.Where(x => x.DataDePagamento.Date == diaAtual.Date).ToList();
            return saidasNoDia;
        }
    }
}
