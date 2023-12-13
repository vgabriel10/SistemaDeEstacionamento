namespace SistemaDeEstacionamento.Models.DAO
{
    public interface IFaturamentoDAO
    {
        public List<ValorVeiculo> ListarPrecosVeiculos(int dia);
        public void AdicionarNovoTipoVeiculo(string nome, float valor);
        public void AlterarValorTipoVeiculo(int tipoVeiculo, int dia, float valor);
        public void ExcluirTipoVeiculo(int id);
        public void AdicionarValorDia(string dia);
        public void AlterarValorDia(int dia);
    }
}
