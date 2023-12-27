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

        public void RegistrarSaidaVeiculo(int id, DateTime horaSaida)
        {
            _estacionamentoDAO.RegistrarSaidaVeiculo(id, horaSaida);
        }

        public Cliente RetornarClientePorCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public Cliente RetornarClientePorId(int id)
        {
            return _estacionamentoDAO.RetornarClientePorId(id);
        }

        public int RetornarIdDiaPeloNome(string dia)
        {
            return _estacionamentoDAO.RetornarIdDiaPeloNome(dia);
        }

        public List<DadosEntradaSaidaVeiculoDTO> RetornarUltimos50Veiculos()
        {
            return _estacionamentoDAO.RetornarUltimos50Veiculos();
        }

        public Veiculo RetornarVeiculoPorId(int id)
        {
            return _estacionamentoDAO.RetornarVeiculoPorId(id);
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
