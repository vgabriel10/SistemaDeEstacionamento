using SistemaDeEstacionamento.Models;

namespace SistemaDeEstacionamento.Service.Interfaces
{
    public interface IRelatorioService
    {
        public string GerarRelatorioEntradasSaidasPdf(DateTime dataInicio, DateTime dataFinal);
    }
}
