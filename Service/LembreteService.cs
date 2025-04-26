using SistemaDeEstacionamento.DAO.Interface;
using SistemaDeEstacionamento.Models;
using SistemaDeEstacionamento.Service.Interfaces;

namespace SistemaDeEstacionamento.Service
{
    public class LembreteService : ILembreteService
    {
        private readonly ILembreteDAO _lembreteDAO;

        public LembreteService(ILembreteDAO lembreteDAO)
        {
            _lembreteDAO = lembreteDAO;
        }

        public async Task<Lembrete> CriarLembrete(string lembrete)
        {
            var lembreteEntity = await _lembreteDAO.CriarLembrete(lembrete);
            return lembreteEntity;
        }

        public async Task RemoverLembrete(int id)
        {
            await _lembreteDAO.RemoverLembrete(id);
        }

        public async Task<List<Lembrete>> RetornarLembretes()
        {
            var lembretes = await _lembreteDAO.RetornarLembretes();
            return lembretes;
        }
    }
}
