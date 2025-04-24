using SistemaDeEstacionamento.Models;

namespace SistemaDeEstacionamento.DAO.Interface
{
    public interface IClienteDAO
    {
        //public Cliente AdicionarCliente
        public List<Cliente> RetornarTodosClientes();
    }
}
