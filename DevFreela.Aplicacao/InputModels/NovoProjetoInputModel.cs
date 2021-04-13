namespace DevFreela.Aplicacao.InputModels
{
    public class NovoProjetoInputModel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int IdCliente { get; set; }
        public int IdFreelancer { get; set; }
        public decimal CustoTotal { get; set; }
    }
}