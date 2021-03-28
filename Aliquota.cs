using System;

namespace calcularPjClt
{
    public class Aliquota
    {
        public Aliquota(decimal faixaSalarial)
        {
            FaixaSalarial = faixaSalarial;
            DefinirValorDeAliquotas();
        }

        public decimal FaixaSalarial { get; private set; }
        public decimal ValorInss { get; private set; }
        public decimal ValorIrff { get; private set; }

        private void DefinirValorDeAliquotas()
        {
            DefinirValorAliquotaInss();
            DefinirValorAliquotaIrff();
        }
        private void DefinirValorAliquotaInss()
        {
            if (FaixaSalarial >= 1100.01M && FaixaSalarial <= 2203.45M)
                ValorInss = 7.5M;
            else if (FaixaSalarial >= 2203.49M && FaixaSalarial <= 3305.22M)
                ValorInss = 12;
            else if (FaixaSalarial >= 3305.23M && FaixaSalarial <= 6433.57M)
                ValorInss = 14;
        }
        private void DefinirValorAliquotaIrff()
        {
            if (FaixaSalarial >= 1903.99M && FaixaSalarial <= 2826.66M)
                ValorIrff = 7.5M;

            if (FaixaSalarial >= 2826.66M && FaixaSalarial <= 3751.05M)
                ValorIrff = 15;

            if (FaixaSalarial >= 3751.06M && FaixaSalarial <= 4664.68M)
                ValorIrff = 22;

            else if (FaixaSalarial <= 4664.68M)
                ValorIrff = 27.5M;
        }

        public decimal ValorCobrancaIRFF() =>
            Math.Round((FaixaSalarial * 100) / ValorIrff, 2);

        public decimal ValorCobrancaINSS() =>
            Math.Round((FaixaSalarial * 100) / ValorInss, 2);
    }
}
