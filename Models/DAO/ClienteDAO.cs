using Microsoft.EntityFrameworkCore;

namespace SistemaDeEstacionamento.Models.DAO
{
    public class ClienteDAO : DbContext
    {
        
        public List<Cliente> RetornarTodosClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            //var db = new BaseEstacionamentoContext();
            //clientes = db.Cliente.ToList();
            
            return clientes;
        }
    }
}
