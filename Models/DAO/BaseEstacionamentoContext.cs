using Microsoft.EntityFrameworkCore;

namespace SistemaDeEstacionamento.Models.DAO
{
    public class BaseEstacionamentoContext : DbContext
    {
        public BaseEstacionamentoContext(DbContextOptions<BaseEstacionamentoContext> options) : base(options)
        {

        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<TipoVeiculo> TipoVeiculo { get; set; }
        public DbSet<ValorVeiculo> ValorVeiculo { get; set; }
    }
}
