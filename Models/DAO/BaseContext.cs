using Microsoft.EntityFrameworkCore;

namespace SistemaDeEstacionamento.Models.DAO
{
    public class BaseContext : DbContext
    {
        public BaseContext() : base("Estacionamento") { }
        public DbSet<Cliente> Cliente { get; set; }
    }
}
