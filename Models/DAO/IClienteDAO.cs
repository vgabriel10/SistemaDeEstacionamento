namespace SistemaDeEstacionamento.Models.DAO
{
    public interface IClienteDAO
    {
        //public Cliente AdicionarCliente
        public List<Cliente> RetornarTodosClientes();
    }
}
