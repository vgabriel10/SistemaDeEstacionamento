using Microsoft.EntityFrameworkCore;

namespace SistemaDeEstacionamento.Models.DAO
{
    public class ClienteDAO : DbContext , IClienteDAO 
    {

        //private readonly DbContext _dbContext;

        //public ClienteDAO(DbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        public List<Cliente> RetornarTodosClientes()
        {
            throw new NotImplementedException();
        }
    }
}
