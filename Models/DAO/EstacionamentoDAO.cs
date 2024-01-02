using Microsoft.EntityFrameworkCore;
using SistemaDeEstacionamento.Models.DTO;
using System.Linq;

namespace SistemaDeEstacionamento.Models.DAO
{
    public class EstacionamentoDAO : DbContext , IEstacionamentoDAO 
    {
        private readonly BaseEstacionamentoContext _dbContext;

        public EstacionamentoDAO(BaseEstacionamentoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Vaga informacoesSobreVagas()
        {
            //return _dbContext.Vaga.FirstOrDefault();
            Vaga infoVaga = _dbContext.Vaga.FirstOrDefault();
            if (infoVaga != null)
            {
                infoVaga.VagasOcupadas = _dbContext.Veiculo.Where(v => v.HoraSaida == null).ToList().Count;
                infoVaga.VagasDisponiveis = infoVaga.TotalVagas - infoVaga.VagasOcupadas;
            }
            return infoVaga;


        }

        public void RegistrarEntradaVeiculo(VeiculosNoEstacionamentoDTO dadosVeiculo)
        {
            var cliente = new Cliente {
                Nome = dadosVeiculo.NomeCliente,
                Cpf = dadosVeiculo.Cpf,
                Telefone = dadosVeiculo.Telefone,
                Veiculo = new Veiculo {
                    IdTipoVeiculo = dadosVeiculo.TipoVeiculo,
                    Nome = dadosVeiculo.NomeVeiculo,
                    Placa = dadosVeiculo.Placa,
                    HoraEntrada = dadosVeiculo.HoraEntrada,
                    IdTipoDia = dadosVeiculo.TipoDia
                }
            };
            _dbContext.Cliente.Add(cliente);
            _dbContext.SaveChanges();
        }

        public void RegistrarSaidaVeiculo(int id, DateTime horaSaida)
        {
            Veiculo veiculo = _dbContext.Veiculo.Where(v => v.Id == id).FirstOrDefault();
            veiculo.HoraSaida = horaSaida;
            _dbContext.Update(veiculo);
            _dbContext.SaveChanges();

        }

        public Cliente RetornarClientePorCpf(string cpf)
        {
            return _dbContext.Cliente.Where(c => c.Cpf == cpf).FirstOrDefault();
        }

        public Cliente RetornarClientePorId(int id)
        {
            return _dbContext.Cliente.Where(c => c.Id == id).FirstOrDefault();
        }

        public int RetornarIdDiaPeloNome(string dia)
        {
            return _dbContext.TipoDia.Where(x => x.Dia.Contains(dia))
                .Select(x => x.Id)
                .FirstOrDefault();
        }

        public List<DadosEntradaSaidaVeiculoDTO> RetornarUltimos50Veiculos()
        {
            var listaVeiculos = (from v in _dbContext.Veiculo
                                 join c in _dbContext.Cliente on v.Id equals c.IdVeiculo
                                 select new DadosEntradaSaidaVeiculoDTO
                                 {
                                     IdVeiculo = v.Id,
                                     IdCliente = c.Id,
                                     NomeCliente = c.Nome,
                                     Cpf = c.Cpf,
                                     Placa = v.Placa,
                                     NomeVeiculo = v.Nome,
                                     HoraEntrada = (DateTime)v.HoraEntrada,
                                     HoraSaida = (DateTime)v.HoraSaida,
                                     Local = v.LocalEstacionado
                                 }).Take(50).ToList();
            return listaVeiculos;
        }

        public Veiculo RetornarVeiculoPorId(int id)
        {
            return _dbContext.Veiculo.Where(v => v.Id == id).FirstOrDefault();
        }

        public List<VeiculosNoEstacionamentoDTO> RetornarVeiculosEstacionados()
        {
            var veiculosEstacionados = (from v in _dbContext.Veiculo
                         join c in _dbContext.Cliente on v.Id equals c.IdVeiculo
                         where v.HoraSaida == null
                         select new VeiculosNoEstacionamentoDTO
                         {
                            IdVeiculo = v.Id,
                            IdCliente = c.Id,
                            NomeCliente = c.Nome,
                            Cpf = c.Cpf,
                            Placa = v.Placa,
                            NomeVeiculo = v.Nome,
                            HoraEntrada = (DateTime)v.HoraEntrada,
                            Local = v.LocalEstacionado
                         }).ToList();
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
