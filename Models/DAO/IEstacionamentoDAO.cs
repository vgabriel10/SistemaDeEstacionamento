using SistemaDeEstacionamento.Models.DTO;

namespace SistemaDeEstacionamento.Models.DAO
{
    public interface IEstacionamentoDAO
    {
        public void RegistrarEntradaVeiculo(VeiculosNoEstacionamentoDTO dadosVeiculo);
        public void RegistrarSaidaVeiculo(int id, DateTime horaSaida);
        public void TodosVeiculosNoEstacionamento();
        public List<TipoVeiculo> TiposVeiculos();
        public List<VeiculosNoEstacionamentoDTO> RetornarVeiculosEstacionados();
        public List<DadosEntradaSaidaVeiculoDTO> RetornarUltimos50Veiculos();
        public List<TipoDia> RetornaTiposDias();
        public Veiculo RetornarVeiculoPorId(int id);
        public Cliente RetornarClientePorId(int id);
        public Cliente RetornarClientePorCpf(string cpf);
        public int RetornarIdDiaPeloNome(string dia);
        public Vaga informacoesSobreVagas();
        public List<Lembrete> RetornarLembretes();
    }
}
