using Microsoft.EntityFrameworkCore;
using SistemaDeEstacionamento.Service;

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
        public void AdicionarNovoTipoVeiculo(string nome, float valor)
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

        public void AlterarValorTipoVeiculo(int tipoVeiculo, int dia, float valor)
        {
            _faturamentoDAO.AlterarValorTipoVeiculo(tipoVeiculo,dia, valor);
        }

        public void ExcluirTipoVeiculo(int id)
        {
            _faturamentoDAO.ExcluirTipoVeiculo(id);
        }

        public List<ValorVeiculo> ListarPrecosVeiculos(int dia)
        {
            return _faturamentoDAO.ListarPrecosVeiculos(dia);
        }
    }
}
