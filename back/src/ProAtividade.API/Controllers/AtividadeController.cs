using Microsoft.AspNetCore.Mvc;
using ProAtividade.Domain.Entities;
using ProAtividade.Domain.Interfaces.Services;

namespace ProAtividade.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtividadeController : ControllerBase
    {
        public IAtividadeService AtividadeService { get; }

        public AtividadeController(IAtividadeService atividadeService)
        {
            this.AtividadeService = atividadeService;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var atividades = await this.AtividadeService.PegarTodasAtividadesAsync();
                if (atividades == null) return NoContent();

                return Ok(atividades);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar as Atividades. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var atividade = await this.AtividadeService.PegarTodasAtividadePorIdAsync(id);
                if (atividade == null) return NoContent();

                return Ok(atividade);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar a Atividade com id: {id}. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Atividade model)
        {
            try
            {
                var atividade = await this.AtividadeService.AdicionarAtividade(model);
                if (atividade == null) return NoContent();

                return Ok(atividade);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar a Atividade. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Atividade model)
        {
            try
            {
                if (model.Id != id) 
                    this.StatusCode(StatusCodes.Status409Conflict,
                        $"Você está tentando atualizar a atividade errada.");

                var atividade = await this.AtividadeService.AtualizarAtividade(model);
                if (atividade == null) return NoContent();

                return Ok(atividade);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar a Atividade com id: {id}. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var atividade = await this.AtividadeService.PegarTodasAtividadePorIdAsync(id);
                if (atividade == null) 
                    this.StatusCode(StatusCodes.Status409Conflict,
                        $"Você está tentando excluir a atividade que não existe.");

                if (await this.AtividadeService.DeletarAtividade(id))
                {
                    return Ok(new {message = "Deletado"});
                }
                else
                {
                    return BadRequest("Ocorreu um problema não específico ao tentar deletar a atividade.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar excluir a Atividade com id: {id}. Erro: {ex.Message}");
            }
        }
    }
}