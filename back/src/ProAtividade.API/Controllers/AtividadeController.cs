using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProAtividade.API.Data;
using ProAtividade.API.Models;

namespace ProAtividade.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtividadeController : ControllerBase
    {
        private readonly DataContext context;

        public AtividadeController(DataContext context)
        {
            this.context = context;
            
        }

        [HttpGet]
        public IEnumerable<Atividade> Get()
        {
            return this.context.Atividades;
        }

        [HttpGet("{id}")]
        public Atividade Get(int id)
        {
            return this.context.Atividades.FirstOrDefault(ati => ati.Id == id);
        }

        [HttpPost]
        public Atividade Post(Atividade atividade)
        {
            this.context.Atividades.Add(atividade);

            if (this.context.SaveChanges() > 0)
                return atividade;
            else
                throw new Exception("Você não conseguiu adicionar uma atividade.");
        }

        [HttpPut("{id}")]
        public Atividade Put(int id, Atividade atividade)
        {
            if (atividade.Id != id) throw new Exception("Você está tentando atualizar a atividade errada.");

            this.context.Update(atividade);

            if (this.context.SaveChanges() > 0)
                return this.context.Atividades.FirstOrDefault(ativ => ativ.Id == id);
            else
                return new Atividade();
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var atividade = this.context.Atividades.FirstOrDefault(ativ => ativ.Id == id);

            if (atividade == null)
                throw new Exception("Você está tentando excluir uma atividade que não existe.");

            this.context.Remove(atividade);

            return this.context.SaveChanges() > 0;
        }
    }
}