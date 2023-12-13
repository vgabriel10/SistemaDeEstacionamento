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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Adicionar registros iniciais
            modelBuilder.Entity<TipoDia>().HasData(
                new TipoDia { Id = 1,Dia = "Domingo" },
                new TipoDia { Id = 2, Dia = "Segunda Feira" },
                new TipoDia { Id = 3, Dia = "Terça Feira" },
                new TipoDia { Id = 4, Dia = "Quarta Feira" },
                new TipoDia { Id = 5, Dia = "Quinta Feira" },
                new TipoDia { Id = 6, Dia = "Sexta Feira" },
                new TipoDia { Id = 7, Dia = "Sábado" },
                new TipoDia { Id = 8, Dia = "Feriado" }
            );
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<TipoVeiculo> TipoVeiculo { get; set; }
        public DbSet<ValorVeiculo> ValorVeiculo { get; set; }
        public DbSet<ClienteVeiculoValor> ClienteVeiculoValor { get; set; }
        public DbSet<TipoDia> TipoDia { get; set; }
    }
}
