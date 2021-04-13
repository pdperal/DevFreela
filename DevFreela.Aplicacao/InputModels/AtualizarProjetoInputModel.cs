namespace DevFreela.Aplicacao.InputModels
{
    public class AtualizarProjetoInputModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int IdCliente { get; set; }
        public decimal CustoTotal { get; set; }
    }
}