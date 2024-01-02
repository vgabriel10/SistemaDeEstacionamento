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

            modelBuilder.Entity<TipoVeiculo>().HasData(
                new TipoVeiculo { Id = 1, Nome = "Moto", Situacao = true },
                new TipoVeiculo { Id = 2, Nome = "Carro", Situacao = true }
            );

            modelBuilder.Entity<ValorVeiculo>().HasData(
                new ValorVeiculo { Id = 1, IdDia = 1,IdTipoVeiculo = 1, ValorHora = 5 },
                new ValorVeiculo { Id= 2, IdDia = 2, IdTipoVeiculo = 1, ValorHora = 5 },
                new ValorVeiculo {Id = 3, IdDia = 3, IdTipoVeiculo = 1, ValorHora = 5 },
                new ValorVeiculo {Id = 4, IdDia = 4, IdTipoVeiculo = 1, ValorHora = 5 },
                new ValorVeiculo {Id = 5, IdDia = 5, IdTipoVeiculo = 1, ValorHora = 5 },
                new ValorVeiculo {Id = 6, IdDia = 6, IdTipoVeiculo = 1, ValorHora = 5 },
                new ValorVeiculo {Id = 7, IdDia = 7, IdTipoVeiculo = 1, ValorHora = 5 },
                new ValorVeiculo {Id = 8, IdDia = 8, IdTipoVeiculo = 1, ValorHora = 5 },

                new ValorVeiculo { Id = 9, IdDia = 1, IdTipoVeiculo = 2, ValorHora = 10 },
                new ValorVeiculo { Id = 10, IdDia = 2, IdTipoVeiculo = 2, ValorHora = 10 },
                new ValorVeiculo { Id = 11, IdDia = 3, IdTipoVeiculo = 2, ValorHora = 10 },
                new ValorVeiculo { Id = 12, IdDia = 4, IdTipoVeiculo = 2, ValorHora = 10 },
                new ValorVeiculo { Id = 13, IdDia = 5, IdTipoVeiculo = 2, ValorHora = 10 },
                new ValorVeiculo { Id = 14, IdDia = 6, IdTipoVeiculo = 2, ValorHora = 10 },
                new ValorVeiculo { Id = 15, IdDia = 7, IdTipoVeiculo = 2, ValorHora = 10 },
                new ValorVeiculo { Id = 16, IdDia = 8, IdTipoVeiculo = 2, ValorHora = 10 }
            );
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<TipoVeiculo> TipoVeiculo { get; set; }
        public DbSet<ValorVeiculo> ValorVeiculo { get; set; }
        public DbSet<ClienteVeiculoValor> ClienteVeiculoValor { get; set; }
        public DbSet<TipoDia> TipoDia { get; set; }
        public DbSet<Vaga> Vaga { get; set; }
    }
}
