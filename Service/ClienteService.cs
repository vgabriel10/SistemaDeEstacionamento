using Microsoft.EntityFrameworkCore;
using SistemaDeEstacionamento.Service;

namespace SistemaDeEstacionamento.Models.DAO
{
    public class ClienteService : IClienteService
    {
        #region Injeção de dependencia
        private readonly IClienteDAO _clienteDAO;

        public ClienteService(IClienteDAO clienteDAO)
        {
            _clienteDAO = clienteDAO;
        }
        #endregion

        public void AdicionarCliente(string nome, string? cpf, string? telefone, string placa, string veiculo)
        {
            throw new NotImplementedException();
        }

        public Cliente BuscarClientePelaPlaca(string placa)
        {
            throw new NotImplementedException();
        }

        public Cliente BuscarClientePeloCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public Cliente BuscarClientePeloNome(string nome)
        {
            throw new NotImplementedException();
        }

        public Cliente EditarCliente()
        {
            throw new NotImplementedException();
        }

        public bool ExcluirCliente()
        {
            throw new NotImplementedException();
        }

        public List<Cliente> RetornarTodosClientes()
        {
            return _clienteDAO.RetornarTodosClientes();
        }

        

    }
}
