using SistemaDeEstacionamento.Models;

namespace SistemaDeEstacionamento.Service.Interfaces
{
    public interface ILembreteService
    {
        Task<List<Lembrete>> RetornarLembretes();
        Task<Lembrete> CriarLembrete(string lembrete);
        Task RemoverLembrete(int id);
    }
}
