using System;
using System.Collections.Generic;
using System.Linq;

namespace calcularPjClt
{
    public class CalculoValoresCLT
    {
        public CalculoValoresCLT(decimal salarioCLT, int percentualImposto, List<Beneficio> beneficios)
        {
            SalarioCLT = salarioCLT;
            PercentualImposto = percentualImposto;
            Beneficios = beneficios;
            CalcularValorTotalRendimentoCLT();
        }

        public decimal SalarioCLT { get; private set; }
        public decimal AliquotaInss { get; private set; }
        public decimal ValorCobrancaInss { get; private set; }
        public decimal AliquotaIrff { get; private set; }
        public decimal ValorCobrancaIrff { get; private set; }
        public int PercentualImposto { get; private set; }
        public List<Beneficio> Beneficios { get; set; }

        private void CalcularValorIRFF()
        {
            var impostoRetidoNaFonte = new CalculoIRFF(SalarioCLT, ValorCobrancaInss);

            AliquotaIrff = impostoRetidoNaFonte.ValorAliquota;

            ValorCobrancaIrff = impostoRetidoNaFonte.ValorCobrancaIRFF();
        }

        private void CalcularValorINSS()
        {
            var inss = new CalculoInss(SalarioCLT);

            AliquotaInss = inss.ValorAliquota;
            ValorCobrancaInss = inss.ValorCobrancaINSS();
        }

        public decimal CalcularValorFGTS() => ((SalarioCLT / 100) * 8);

        public decimal CalcularValorMensalFeriasDecimoTerceiro()
        {
            var vlFerias = (SalarioCLT / 12);

            Beneficios.Add(new(vlFerias, "Ferias"));
            Beneficios.Add(new(vlFerias, "Décimo Terceiro Salário"));

            return vlFerias;
        }

        public decimal CalcularUmTercoFerias() =>
            Math.Round((CalcularValorMensalFeriasDecimoTerceiro() / 3), 2);

        public void CalcularValorTotalRendimentoCLT()
        {
            var fgts = CalcularValorFGTS();
            var tercoFerias = CalcularUmTercoFerias();

            Beneficios.Add(new(fgts, "FGTS"));
            Beneficios.Add(new(tercoFerias, "1/3 Férias: "));

            var vlTotalBeneficios = Beneficios.Sum(c => c.Valor) + SalarioCLT;

            CalcularValorINSS();
            CalcularValorIRFF();

            vlTotalBeneficios -= (ValorCobrancaInss + ValorCobrancaIrff);
            Beneficios.Add(new(vlTotalBeneficios, "Valor total: "));
        }
    }
}