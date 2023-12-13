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
                    Placa = dadosVeiculo.Placa,
                    HoraEntrada = dadosVeiculo.HoraEntrada
                }
            };
            _dbContext.Cliente.Add(cliente);
            _dbContext.SaveChanges();
        }

        public void RegistrarSaidaVeiculo()
        {
            throw new NotImplementedException();
        }

        public List<VeiculosNoEstacionamentoDTO> RetornarVeiculosEstacionados()
        {
            //List<VeiculosNoEstacionamentoDTO> veiculosEstacionados = new List<VeiculosNoEstacionamentoDTO>();
            var veiculosEstacionados = (from v in _dbContext.Veiculo
                         join c in _dbContext.Cliente on v.Id equals c.IdVeiculo
                         select new VeiculosNoEstacionamentoDTO
                         {
                            NomeCliente = c.Nome,
                            Cpf = c.Cpf,
                            Placa = v.Placa,
                            NomeVeiculo = v.Nome

                         }).ToList();

            //foreach(var veiculo in consulta)
            //{
            //    veiculosEstacionados.Add(veiculo.)
            //}
            return veiculosEstacionados;
        }

        public List<TipoDia> RetornaTiposDias()
        {
            return _dbContext.TipoDia.ToList();
        }

        public List<TipoVeiculo> TiposVeiculos()
        {
            return _dbContext.TipoVeiculo.ToList();
        }

        public void TodosVeiculosNoEstacionamento()
        {
            throw new NotImplementedException();
        }
    }
}
