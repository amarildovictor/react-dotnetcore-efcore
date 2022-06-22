namespace ProAtividade.Domain.Entities
{
    public class Atividade
    {
        public Atividade()
        {
            DataCriacao = DateTime.Now;
            DataConclusao = null;
        } 

        public Atividade(int id, string titulo, string descricao) : this()
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
        }

        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataConclusao { get; set; }

        public Prioridade Prioridade { get; set; }

        public void Concluir()
        {
            if (DataConclusao == null)
                DataConclusao = DateTime.Now;
            else
                throw new Exception($"Atividade já concluída em: {DataConclusao?.ToString("dd/MMyyy hh:mm")}");
        }
    }
}