namespace DevFreela.Core.Entidades
{
    public class HabilidadeUsuario : EntidadeBase
    {
        public int IdUsuario { get; private set; }
        public int IdHabilidade { get; private set; }

        public HabilidadeUsuario(int idUsuario, int idHabilidade)
        {
            IdUsuario = idUsuario;
            IdHabilidade = idHabilidade;
        }
    }
}