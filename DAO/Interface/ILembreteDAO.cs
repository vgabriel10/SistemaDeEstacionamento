using SistemaDeEstacionamento.Models;

namespace SistemaDeEstacionamento.DAO.Interface
{
    public interface ILembreteDAO
    {
        Task<List<Lembrete>> RetornarLembretes();
        Task<Lembrete> CriarLembrete(string lembrete);
        Task RemoverLembrete(int id);
    }
}
