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

        public List<VeiculosNoEstacionamentoDTO> RetornarVeiculosEstacionados()
        {
            return _estacionamentoDAO.RetornarVeiculosEstacionados();
        }

        public List<TipoDia> RetornaTiposDias()
        {
            return _estacionamentoDAO.RetornaTiposDias();
        }

        public List<TipoVeiculo> TiposVeiculos()
        {
            return _estacionamentoDAO.TiposVeiculos();
        }

        public void TodosVeiculosNoEstacionamento()
        {
            throw new NotImplementedException();
        }
        
    }
}
