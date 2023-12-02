using SistemaDeEstacionamento.Models;

namespace SistemaDeEstacionamento.Service
{
    public interface IClienteService
    {
        public void AdicionarCliente(string nome, string? cpf, string? telefone, string placa, string veiculo);
        public Cliente BuscarClientePeloNome(string nome);
        public Cliente BuscarClientePeloCpf(string cpf);
        public Cliente BuscarClientePelaPlaca(string placa);
        public Cliente EditarCliente();
        public bool ExcluirCliente();
        public List<Cliente> RetornarTodosClientes();
    }
}
