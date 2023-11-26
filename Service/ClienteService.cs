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
        public void AdicionarCliente()
        {
            _clienteDAO.RetornarTodosClientes();
            //throw new NotImplementedException();
        }

        public Cliente BuscarCliente()
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
    }
}
