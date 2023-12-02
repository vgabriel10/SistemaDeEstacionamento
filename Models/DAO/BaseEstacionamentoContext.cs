using Microsoft.EntityFrameworkCore;

namespace SistemaDeEstacionamento.Models.DAO
{
    public class BaseEstacionamentoContext : DbContext
    {
        public BaseEstacionamentoContext(DbContextOptions<BaseEstacionamentoContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<TipoVeiculo> TipoVeiculo { get; set; }
        public DbSet<ValorVeiculo> ValorVeiculo { get; set; }
    }
}
