using SistemaDeEstacionamento.Models;

namespace SistemaDeEstacionamento.Service
{
    public interface IRelatorioService
    {
        public string GerarRelatorioEntradasSaidasPdf(DateTime dataInicio, DateTime? dataFinal);
    }
}
