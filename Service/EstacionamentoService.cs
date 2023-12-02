using Microsoft.EntityFrameworkCore;
using SistemaDeEstacionamento.Models.DTO;
using SistemaDeEstacionamento.Service;

namespace SistemaDeEstacionamento.Models.DAO
{
    public class EstacionamentoService : IEstacionamentoService
    {
        #region Injeção de dependencia
        private readonly IClienteDAO _clienteDAO;
        private readonly IEstacionamentoDAO _estacionamentoDAO;

        public EstacionamentoService(IClienteDAO clienteDAO, IEstacionamentoDAO estacionamentoDAO)
        {
            _clienteDAO = clienteDAO;
            _estacionamentoDAO = estacionamentoDAO;
        }
        #endregion

        public void RegistrarEntradaVeiculo(VeiculosNoEstacionamentoDTO dadosVeiculo)
        {
            _estacionamentoDAO.RegistrarEntradaVeiculo(dadosVeiculo);
            //throw new NotImplementedException();
        }

        public void RegistrarSaidaVeiculo()
        {
            throw new NotImplementedException();
        }

        public void TodosVeiculosNoEstacionamento()
        {
            throw new NotImplementedException();
        }
        
    }
}
