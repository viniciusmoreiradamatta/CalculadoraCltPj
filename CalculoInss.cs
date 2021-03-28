namespace calcularPjClt
{
    public class CalculoInss : CalculoImpostos
    {
        public CalculoInss(decimal faixaSalarial)
        {
            FaixaSalarial = faixaSalarial;
            DefinirValorDeAliquotas();
        }

        public int HorasSemanais { get; set; }
        public decimal ValorIrff { get; private set; }

        private void DefinirValorDeAliquotas()
        {
            DefinirValoraAliquota();
        }

        public decimal ValorCobrancaINSS() =>
            (FaixaSalarial / 100) * ValorAliquota;

        protected override void DefinirValoraAliquota()
        {
            if (FaixaSalarial >= 1100.01M && FaixaSalarial <= 2203.45M)
                ValorAliquota = 7.5M;
            else if (FaixaSalarial >= 2203.49M && FaixaSalarial <= 3305.22M)
                ValorAliquota = 12;
            else if (FaixaSalarial >= 3305.23M && FaixaSalarial <= 6433.57M)
                ValorAliquota = 14;
        }
    }
}