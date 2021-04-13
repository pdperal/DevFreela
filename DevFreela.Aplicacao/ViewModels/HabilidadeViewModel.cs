namespace DevFreela.Aplicacao.ViewModels
{
    public class HabilidadeViewModel
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }

        public HabilidadeViewModel(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
