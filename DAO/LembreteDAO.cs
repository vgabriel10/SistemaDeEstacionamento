using Microsoft.EntityFrameworkCore;
using SistemaDeEstacionamento.DAO.Interface;
using SistemaDeEstacionamento.Data;
using SistemaDeEstacionamento.Models;

namespace SistemaDeEstacionamento.DAO
{
    public class LembreteDAO : ILembreteDAO
    {
        private BaseEstacionamentoContext _dbContext;

        public LembreteDAO(BaseEstacionamentoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Lembrete> CriarLembrete(string lembrete)
        {
            var lembreteEntity = new Lembrete
            {
                Descricao = lembrete
            };

            await _dbContext.Lembrete.AddAsync(lembreteEntity);
            await _dbContext.SaveChangesAsync();

            return lembreteEntity;
        }

        public async Task RemoverLembrete(int id)
        {
            var lembrete = await _dbContext.Lembrete.SingleOrDefaultAsync(l => l.Id == id);
            _dbContext.Lembrete.Remove(lembrete);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<List<Lembrete>> RetornarLembretes()
        {
            return await _dbContext.Lembrete.ToListAsync();
        }
    }
}
