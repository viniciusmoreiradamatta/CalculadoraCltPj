namespace Domain.Models.Impostos
{
    public class CalculoIRFF : ImpostoBase
    {
        public CalculoIRFF(decimal FaixaSalarial, decimal vlInss)
        {
            base.FaixaSalarial = FaixaSalarial;
            this.ValorInss = vlInss;
            DefinirValoraAliquota();
        }

        public decimal ValorInss { get; private set; }
        public decimal ValorDeducao { get; private set; }

        public decimal ValorCobrancaIRFF()
        {
            var inss = ValorInss;

            var baseCalculo = FaixaSalarial - inss;

            var total = (baseCalculo / 100) * ValorAliquota;

            return total - ValorDeducao;
        }

        protected override void DefinirValoraAliquota()
        {
            if (FaixaSalarial >= 1903.99M && FaixaSalarial <= 2826.66M)
            {
                ValorAliquota = 7.5M;
                ValorDeducao = 142.80M;
            }
            else if (FaixaSalarial >= 2826.66M && FaixaSalarial <= 3751.05M)
            {
                ValorAliquota = 15;
                ValorDeducao = 354.80M;
            }
            else if (FaixaSalarial >= 3751.06M && FaixaSalarial <= 4664.68M)
            {
                ValorAliquota = 22;
                ValorDeducao = 636.13M;
            }
            else if (FaixaSalarial <= 4664.68M)
            {
                ValorAliquota = 27.5M;
                ValorDeducao = 869.36M;
            }
        }
    }
}