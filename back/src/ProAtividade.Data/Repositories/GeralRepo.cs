using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProAtividade.Data.Context;
using ProAtividade.Domain.Interfaces.Repositories;

namespace ProAtividade.Data.Repositories
{
    public class GeralRepo : IGeralRepo
    {
        public DataContext Context { get; }

        public GeralRepo(DataContext context)
        {
            this.Context = context;
        }

        public void Adicionar<T>(T entity) where T : class
        {
            this.Context.Add(entity);
        }

        public void Atualizar<T>(T entity) where T : class
        {
            this.Context.Update(entity);
        }

        public void Excluir<T>(T entity) where T : class
        {
            this.Context.Remove(entity);
        }

        public void ExcluirVarias<T>(T[] entityArray) where T : class
        {
            this.Context.RemoveRange(entityArray);
        }

        public async Task<bool> SalvarMudancasAsync()
        {
            return await this.Context.SaveChangesAsync() > 0;
        }
    }
}