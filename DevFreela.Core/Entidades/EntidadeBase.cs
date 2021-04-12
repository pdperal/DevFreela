namespace DevFreela.Core.Entidades
{
    public abstract class EntidadeBase
    {
        public int Id { get; private set; }
        protected EntidadeBase() { }
    }
}
