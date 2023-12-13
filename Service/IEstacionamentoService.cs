using SistemaDeEstacionamento.Models;
using SistemaDeEstacionamento.Models.DTO;

namespace SistemaDeEstacionamento.Service
{
    public interface IEstacionamentoService
    {
        public void RegistrarEntradaVeiculo(VeiculosNoEstacionamentoDTO dadosVeiculo);
        public void RegistrarSaidaVeiculo();
        public void TodosVeiculosNoEstacionamento();
        public List<TipoVeiculo> TiposVeiculos();
        public List<VeiculosNoEstacionamentoDTO> RetornarVeiculosEstacionados();
        public List<TipoDia> RetornaTiposDias();
    }
}
