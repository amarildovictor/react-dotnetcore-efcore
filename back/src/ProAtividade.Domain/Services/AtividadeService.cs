using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProAtividade.Domain.Entities;
using ProAtividade.Domain.Interfaces.Repositories;
using ProAtividade.Domain.Interfaces.Services;

namespace ProAtividade.Domain.Services
{
    public class AtividadeService : IAtividadeService
    {
        public IAtividadeRepo AtividadeRepo { get; }
        
        public AtividadeService(IAtividadeRepo atividadeRepo)
        {
            this.AtividadeRepo = atividadeRepo;
            
        }
        public async Task<Atividade> AdicionarAtividade(Atividade model)
        {
            if (await this.AtividadeRepo.PegaPorTituloAsync(model.Titulo) != null)
                throw new Exception("Já existe uma atividade com esse título.");
            
            if (await this.AtividadeRepo.PegaPorIdAsync(model.Id) == null)
            {
                this.AtividadeRepo.Adicionar(model);

                if(await this.AtividadeRepo.SalvarMudancasAsync())
                    return model;
            }

            return null;
        }

        public async Task<Atividade> AtualizarAtividade(Atividade model)
        {
            if (model.DataConclusao != null)
                throw new Exception("Não se pode alterar atividade já concluída.");
            
            if (await this.AtividadeRepo.PegaPorIdAsync(model.Id) != null)
            {
                this.AtividadeRepo.Atualizar(model);

                if(await this.AtividadeRepo.SalvarMudancasAsync())
                    return model;
            }

            return null;
        }

        public async Task<bool> ConcluirAtividade(Atividade model)
        {
            if (model != null)
            {
                model.Concluir();
                this.AtividadeRepo.Atualizar(model);
                return await this.AtividadeRepo.SalvarMudancasAsync();
            }

            return false;
        }

        public async Task<bool> DeletarAtividade(int atividadeId)
        {
            var atividade = await this.AtividadeRepo.PegaPorIdAsync(atividadeId);

            if (atividade == null)
                throw new Exception("Atividade que você tentou excluir não existe.");

            this.AtividadeRepo.Excluir(atividade);

            return await this.AtividadeRepo.SalvarMudancasAsync();
        }

        public async Task<Atividade> PegarTodasAtividadePorIdAsync(int atividadeId)
        {
            try
            {
                var atividade = await this.AtividadeRepo.PegaPorIdAsync(atividadeId);

                if (atividade == null) return null;

                return atividade;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Atividade[]> PegarTodasAtividadesAsync()
        {
            try
            {
                var atividades = await this.AtividadeRepo.PegaTodasAsync();

                if (atividades == null) return null;

                return atividades;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}