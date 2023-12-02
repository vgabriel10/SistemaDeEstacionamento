using Microsoft.EntityFrameworkCore;
using SistemaDeEstacionamento.Models.DTO;

namespace SistemaDeEstacionamento.Models.DAO
{
    public class EstacionamentoDAO : DbContext , IEstacionamentoDAO 
    {
        private readonly BaseEstacionamentoContext _dbContext;

        public EstacionamentoDAO(BaseEstacionamentoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void RegistrarEntradaVeiculo(VeiculosNoEstacionamentoDTO dadosVeiculo)
        {
            var cliente = new Cliente {
                Nome = dadosVeiculo.NomeCliente,
                Cpf = dadosVeiculo.Cpf,
                Telefone = dadosVeiculo.Telefone,
                Veiculo = new Veiculo {
                    IdTipo = dadosVeiculo.TipoVeiculo,
                    Nome = dadosVeiculo.NomeVeiculo,
                    Placa = dadosVeiculo.Placa
                }
            };
            _dbContext.Cliente.Add(cliente);
            _dbContext.SaveChanges();
        }

        public void RegistrarSaidaVeiculo()
        {
            throw new NotImplementedException();
        }

        public void TodosVeiculosNoEstacionamento()
        {
            throw new NotImplementedException();
        }
    }
}
