using SistemaDeEstacionamento.Models;

namespace SistemaDeEstacionamento.Service
{
    public interface IClienteService
    {
        public void AdicionarCliente();
        public Cliente BuscarCliente();
        public Cliente EditarCliente();
        public bool ExcluirCliente();
    }
}
