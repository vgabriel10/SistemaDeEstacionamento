using SistemaDeEstacionamento.Models.DTO;

namespace SistemaDeEstacionamento.Models.DAO
{
    public interface IEstacionamentoDAO
    {
        public void RegistrarEntradaVeiculo(VeiculosNoEstacionamentoDTO dadosVeiculo);
        public void RegistrarSaidaVeiculo();
        public void TodosVeiculosNoEstacionamento();
        public List<TipoVeiculo> TiposVeiculos();
        public List<VeiculosNoEstacionamentoDTO> RetornarVeiculosEstacionados();
        public List<TipoDia> RetornaTiposDias();
    }
}
