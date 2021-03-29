using Domain.Models.Clt;
using Domain.Models.Impostos;

namespace Domain.Service
{
    public class CalcularValoresCltService
    {
        public void Calcular(ValoresCLT valores)
        {
            CalcularValorTotalRendimentoCLT(valores);
        }

        private void CalcularValorTotalRendimentoCLT(ValoresCLT valores)
        {
            var fgts = valores.ValorFGTS;

            var tercoFerias = valores.ProporcionalFeriasDecimoTerceiro;

            valores.AdicionarBeneficio(new(fgts, "FGTS"));

            valores.AdicionarBeneficio(new(tercoFerias, "1/3 Férias: "));

            var vlTotalBeneficios = valores.ValorTotalBeneficios();

            CalcularValorINSS(valores);

            CalcularValorIRFF(valores);

            CalcularValorMensalFeriasDecimoTerceiro(valores);

            vlTotalBeneficios -= (valores.ValorCobrancaInss + valores.ValorCobrancaIrff);

            valores.AdicionarBeneficio(new(vlTotalBeneficios, "Valor total: "));
        }

        private void CalcularValorMensalFeriasDecimoTerceiro(ValoresCLT valores)
        {
            var vlFerias = (valores.SalarioCLT / 12);

            valores.AdicionarBeneficio(new(vlFerias, "Ferias"));

            valores.AdicionarBeneficio(new(vlFerias, "Décimo Terceiro Salário"));
        }

        private void CalcularValorINSS(ValoresCLT valores)
        {
            var calculoInss = new CalculoInss(valores.SalarioCLT);

            var AliquotaInss = calculoInss.ValorAliquota;

            var ValorCobrancaInss = calculoInss.ValorCobrancaINSS();

            valores.DefinirValoresInss(AliquotaInss, ValorCobrancaInss);
        }

        private void CalcularValorIRFF(ValoresCLT valores)
        {
            var impostoRetidoNaFonte = new CalculoIRFF(valores.SalarioCLT, valores.ValorCobrancaInss);

            var AliquotaIrff = impostoRetidoNaFonte.ValorAliquota;

            var ValorCobrancaIrff = impostoRetidoNaFonte.ValorCobrancaIRFF();

            valores.DefinirValoresIrff(AliquotaIrff, ValorCobrancaIrff);
        }
    }
}