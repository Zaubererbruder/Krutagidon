namespace Assets.Scripts.Krutagidon
{
    public interface IStat<T>
    {
        public void Add(T val);
        public void Sub(T val);
    }
}
