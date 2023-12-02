using SistemaDeEstacionamento.Models;
using SistemaDeEstacionamento.Models.DTO;

namespace SistemaDeEstacionamento.Service
{
    public interface IEstacionamentoService
    {
        public void RegistrarEntradaVeiculo(VeiculosNoEstacionamentoDTO dadosVeiculo);
        public void RegistrarSaidaVeiculo();
        public void TodosVeiculosNoEstacionamento();
    }
}
