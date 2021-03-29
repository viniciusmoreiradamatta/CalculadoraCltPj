namespace Domain.Models.Impostos
{
    public abstract class ImpostoBase
    {
        public decimal FaixaSalarial { get; protected set; }
        public decimal ValorAliquota { get; protected set; }

        protected abstract void DefinirValoraAliquota();
    }
}