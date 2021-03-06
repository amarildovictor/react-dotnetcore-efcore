using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAtividade.Data.Context;
using ProAtividade.Domain.Entities;
using ProAtividade.Domain.Interfaces.Repositories;

namespace ProAtividade.Data.Repositories
{
    public class AtividadeRepo : GeralRepo, IAtividadeRepo
    {
        public DataContext Context { get; }
        public AtividadeRepo(DataContext context) : base(context)
        {
            this.Context = context;
        }

        public async Task<Atividade> PegaPorIdAsync(int id)
        {
            IQueryable<Atividade> query = this.Context.Atividades;

            query = query.AsNoTracking()
                         .OrderBy(ativ => ativ.Id)
                         .Where(ativ => ativ.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Atividade> PegaPorTituloAsync(string titulo)
        {
            IQueryable<Atividade> query = this.Context.Atividades;

            query = query.AsNoTracking()
                         .OrderBy(ativ => ativ.Id);

            return await query.FirstOrDefaultAsync(ativ => ativ.Titulo == titulo);
        }

        public async Task<Atividade[]> PegaTodasAsync()
        {
            IQueryable<Atividade> query = this.Context.Atividades;

            query = query.AsNoTracking()
                         .OrderBy(ativ => ativ.Id);

            return await query.ToArrayAsync();
        }
    }
}