using Microsoft.EntityFrameworkCore;
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

        public void AdicionarNovoTipoVeiculo(string nome, float valor)
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

        public void AlterarValorTipoVeiculo(int tipoVeiculo, int dia, float valor)
        {
            ValorVeiculo valorVeiculo = _dbContext.ValorVeiculo.Where(vv => vv.IdTipoVeiculo == tipoVeiculo && vv.IdDia == dia).FirstOrDefault();
            valorVeiculo.ValorHora = valor;
            _dbContext.Update(valorVeiculo);
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
    }
}
