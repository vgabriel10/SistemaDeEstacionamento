using Microsoft.EntityFrameworkCore;

namespace SistemaDeEstacionamento.Models.DAO
{
    public class ClienteDAO : DbContext , IClienteDAO 
    {
        private readonly BaseEstacionamentoContext _dbContext;

        public ClienteDAO(BaseEstacionamentoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Cliente> RetornarTodosClientes()
        {
            var clientes = _dbContext.Cliente.ToList();
            //var veiculos = _dbContext.Veiculo.ToList();
            return clientes;
        }
    }
}
