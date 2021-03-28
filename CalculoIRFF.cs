namespace calcularPjClt
{
    public class CalculoIRFF : CalculoImpostos
    {
        public CalculoIRFF(decimal FaixaSalarial, decimal vlInss)
        {
            base.FaixaSalarial = FaixaSalarial;
            this.ValorInss = vlInss;
            DefinirValoraAliquota();
        }

        public decimal ValorInss { get; private set; }

        public decimal ValorCobrancaIRFF()
        {
            var inss = ValorInss;

            var baseCalculo = FaixaSalarial - inss;

            var total = (baseCalculo / 100) * ValorAliquota;

            return total - 142.80M;
        }

        protected override void DefinirValoraAliquota()
        {
            if (FaixaSalarial >= 1903.99M && FaixaSalarial <= 2826.66M)
                ValorAliquota = 7.5M;
            else if (FaixaSalarial >= 2826.66M && FaixaSalarial <= 3751.05M)
                ValorAliquota = 15;
            else if (FaixaSalarial >= 3751.06M && FaixaSalarial <= 4664.68M)
                ValorAliquota = 22;
            else if (FaixaSalarial <= 4664.68M)
                ValorAliquota = 27.5M;
        }
    }
}